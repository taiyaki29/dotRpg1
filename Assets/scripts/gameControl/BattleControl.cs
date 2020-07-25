using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public enum BattleStatus { START, PLAYERTURN, PLAYERTURNSKILL, PLAYERMOTION, ENEMYTURN, WIN, LOSE, NO_BATTLE, WAIT, CHOOSENEWSKILL }

public class BattleControl : MonoBehaviour
{
    public BattleStatus battleStatus;

    public GameObject otherButtons;
    public GameObject playerController;
    public GameObject battleTextHolder;

    RectTransform otherButtonsTransform;
    RectTransform playerControllerTransform;
    RectTransform battleTextHolderTransform;

    public GameObject battleTextGameObject;
    Text battleText;

    public GameObject mainRpgcontrol;
    MainRpgController mainRpgcontroller;

    public GameObject player;
    MainPlayerStatus mainPlayerStatus;

    public GameObject skill;
    public GameObject tmpSkill;
    public GameObject normalAttack;
    Skills skills;
    Skills enemySkill;
    Skills normalAttackSkill;

    public GameObject enemy1HPSlider;
    public GameObject enemy2HPSlider;
    public GameObject enemy3HPSlider;

    public GameObject enemy1HPSliderBG;
    public GameObject enemy2HPSliderBG;
    public GameObject enemy3HPSliderBG;

    public GameObject enemy1HPSliderBorder;
    public GameObject enemy2HPSliderBorder;
    public GameObject enemy3HPSliderBorder;

    Image enemy1HPSliderBGImage;
    Image enemy2HPSliderBGImage;
    Image enemy3HPSliderBGImage;

    Image enemy1HPSliderBorderImage;
    Image enemy2HPSliderBorderImage;
    Image enemy3HPSliderBorderImage;

    Slider enemy1HP;
    Slider enemy2HP;
    Slider enemy3HP;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    RectTransform enemy1Transform;
    RectTransform enemy2Transform;
    RectTransform enemy3Transform;

    public EnemyStatus enemy1Status;
    public EnemyStatus enemy2Status;
    public EnemyStatus enemy3Status;

    public GameObject chosen1;
    public GameObject chosen2;
    public GameObject chosen3;

    public EnemyStatus chosenEnemy;
    public EnemyStatus[] allEnemys;

    public int criticalChanceAdjuster = 1000;

    int enemyNumber;
    int remainingEnemyNumber;

    int stageNumber;

    string actionAttack = "<color=#ffffffff>▶︎攻撃\nスキル\n防御\n逃げる</color>";
    string actionSkill = "<color=#ffffffff>攻撃\n▶︎スキル\n防御\n逃げる</color>";
    string actionDefend = "<color=#ffffffff>攻撃\nスキル\n▶︎防御\n逃げる</color>";
    string actionFlee = "<color=#ffffffff>攻撃\nスキル\n防御\n▶︎逃げる</color>";

    public string[] playerActions = new string[7]; 
    public int actionNumber = 0; // player choice

    public int skillNumber = 0; // player choice
    public int newSkillNumber = 0;
    public int chosenNewSkillNumber = 0;

    public bool playerAlive = true;

    bool isPlayerDefending = false;

    Color invisible;
    Color normal;
    Color black;
    
    void Start(){
        battleStatus = BattleStatus.NO_BATTLE;
        Debug.Log("battle start");
        
        mainRpgcontroller = mainRpgcontrol.GetComponent<MainRpgController>();
        mainPlayerStatus = player.GetComponent<MainPlayerStatus>();
        skills = skill.GetComponent<Skills>();
        enemySkill = skill.GetComponent<Skills>();
        normalAttackSkill = normalAttack.GetComponent<Skills>();

        battleText = battleTextGameObject.GetComponent<Text>();
        enemy1Status = enemy1.GetComponent<EnemyStatus>();
        enemy2Status = enemy2.GetComponent<EnemyStatus>();
        enemy3Status = enemy3.GetComponent<EnemyStatus>();

        enemy1Transform = enemy1.GetComponent<RectTransform>();
        enemy2Transform = enemy2.GetComponent<RectTransform>();
        enemy3Transform = enemy3.GetComponent<RectTransform>();

        enemy1HP = enemy1HPSlider.GetComponent<Slider>();
        enemy2HP = enemy2HPSlider.GetComponent<Slider>();
        enemy3HP = enemy3HPSlider.GetComponent<Slider>();

        otherButtonsTransform = otherButtons.GetComponent<RectTransform>();
        playerControllerTransform = playerController.GetComponent<RectTransform>();
        battleTextHolderTransform = battleTextHolder.GetComponent<RectTransform>();

        enemy1HPSliderBGImage = enemy1HPSliderBG.GetComponent<Image>();
        enemy2HPSliderBGImage = enemy2HPSliderBG.GetComponent<Image>();
        enemy3HPSliderBGImage = enemy3HPSliderBG.GetComponent<Image>();

        enemy1HPSliderBorderImage = enemy1HPSliderBorder.GetComponent<Image>();
        enemy2HPSliderBorderImage = enemy2HPSliderBorder.GetComponent<Image>();
        enemy3HPSliderBorderImage = enemy3HPSliderBorder.GetComponent<Image>();

        stageNumber = mainRpgcontroller.stageNumber;

        chosen1.SetActive(false);
        chosen2.SetActive(false);
        chosen3.SetActive(false);

        invisible = new Color(1.0f, 1.0f, 1.0f, 0f);
        normal = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        black = new Color(0f, 0f, 0f, 1.0f);

        isPlayerDefending = false;
    }

    // Update is called once per frame
    void Update(){
        
    }

    void FixedUpdate(){
        if(battleStatus == BattleStatus.NO_BATTLE && mainRpgcontroller.mainRpgStatus == MainRpgStatus.BATTLE){
            battleStatus = BattleStatus.START;
        }
        else if(battleStatus == BattleStatus.PLAYERTURN && mainRpgcontroller.mainRpgStatus == MainRpgStatus.BATTLE){
            battleText.text = playerActions[actionNumber];
        }
        else if(battleStatus == BattleStatus.PLAYERTURNSKILL && mainRpgcontroller.mainRpgStatus == MainRpgStatus.BATTLE){
            battleText.text = playerActions[skillNumber];
        }
        else if(battleStatus == BattleStatus.CHOOSENEWSKILL && mainRpgcontroller.mainRpgStatus == MainRpgStatus.BATTLE){
            battleText.text = playerActions[newSkillNumber];
        }

        if(battleStatus == BattleStatus.LOSE){
            StartCoroutine(playerLoseMotion());
        }

    }

    public void startBattle(){
        StartCoroutine(setStartBattle());
    }

    public IEnumerator setStartBattle(){
        actionNumber = 0;
        skillNumber = 0;
        setChooseAtionText();
        enemyNumber = UnityEngine.Random.Range(1,4);
        if(enemyNumber == 1){
            enemy1Status.spawnEnemy(stageNumber);

            enemy1Status.enemyImage.color = normal;
            enemy1HPSliderBGImage.color = normal;
            enemy1HPSliderBorderImage.color = black;

            enemy1HP.maxValue = enemy1Status.enemyMaxHp;

            enemy1HP.value = enemy1Status.enemyMaxHp;

            enemy1.SetActive(true);
            enemy2.SetActive(false);
            enemy3.SetActive(false);

            battleText.text = "<color=#ffffffff>" + enemy1Status.enemyName + "が襲いかかってきた。"+ "</color>";
        }
        else if(enemyNumber == 2){
            enemy1Status.spawnEnemy(stageNumber);
            enemy2Status.spawnEnemy(stageNumber);

            enemy1Status.enemyImage.color = normal;
            enemy2Status.enemyImage.color = normal;

            enemy1HPSliderBGImage.color = normal;
            enemy1HPSliderBorderImage.color = black;
            enemy2HPSliderBGImage.color = normal;
            enemy2HPSliderBorderImage.color = black;

            enemy1HP.maxValue = enemy1Status.enemyMaxHp;
            enemy2HP.maxValue = enemy2Status.enemyMaxHp;

            enemy1HP.value = enemy1Status.enemyMaxHp;
            enemy2HP.value = enemy2Status.enemyMaxHp;

            enemy1.SetActive(true);
            enemy2.SetActive(true);
            enemy3.SetActive(false);

            if(enemy1Status.enemyName != enemy2Status.enemyName){
                battleText.text = "<color=#ffffffff>" + enemy1Status.enemyName + "と\n" + enemy2Status.enemyName + "が襲いかかってきた。"+ "</color>";
            }
            else {
                battleText.text = "<color=#ffffffff>" + enemy1Status.enemyName + "達が襲いかかってきた。"+ "</color>";
            }
        }
        else if(enemyNumber == 3){
            enemy1Status.spawnEnemy(stageNumber);
            enemy2Status.spawnEnemy(stageNumber);
            enemy3Status.spawnEnemy(stageNumber);

            enemy1Status.enemyImage.color = normal;
            enemy2Status.enemyImage.color = normal;
            enemy3Status.enemyImage.color = normal;

            enemy1HPSliderBGImage.color = normal;
            enemy1HPSliderBorderImage.color = black;
            enemy2HPSliderBGImage.color = normal;
            enemy2HPSliderBorderImage.color = black;
            enemy3HPSliderBGImage.color = normal;
            enemy3HPSliderBorderImage.color = black;

            enemy1HP.maxValue = enemy1Status.enemyMaxHp;
            enemy2HP.maxValue = enemy2Status.enemyMaxHp;
            enemy3HP.maxValue = enemy3Status.enemyMaxHp;

            enemy1HP.value = enemy1Status.enemyMaxHp;
            enemy2HP.value = enemy2Status.enemyMaxHp;
            enemy3HP.value = enemy3Status.enemyMaxHp;

            enemy1.SetActive(true);
            enemy2.SetActive(true);
            enemy3.SetActive(true);

            if(enemy1Status.enemyName != enemy2Status.enemyName && enemy2Status.enemyName != enemy3Status.enemyName){
                battleText.text = "<color=#ffffffff>" + enemy1Status.enemyName + "と\n" + enemy2Status.enemyName + "と\n" + enemy3Status.enemyName + "が襲いかかってきた。"+ "</color>";
            }
            else if(enemy1Status.enemyName == enemy2Status.enemyName && enemy2Status.enemyName == enemy3Status.enemyName){
                battleText.text = "<color=#ffffffff>" + enemy1Status.enemyName  + "の大群が襲いかかってきた。"+ "</color>";
            }
            else if(enemy1Status.enemyName == enemy2Status.enemyName){
                battleText.text = "<color=#ffffffff>" + enemy1Status.enemyName + "達と\n" + enemy3Status.enemyName + "が襲いかかってきた。"+ "</color>";
            }
            else if(enemy2Status.enemyName == enemy3Status.enemyName){
                battleText.text = "<color=#ffffffff>" + enemy2Status.enemyName + "達と\n" + enemy1Status.enemyName + "が襲いかかってきた。"+ "</color>";
            }
            else if(enemy1Status.enemyName == enemy3Status.enemyName){
                battleText.text = "<color=#ffffffff>" + enemy1Status.enemyName + "達と\n" + enemy2Status.enemyName + "が襲いかかってきた。"+ "</color>";
            }
        }

        yield return new WaitForSeconds(1.5f * mainRpgcontroller.gameTextSpeed);
        battleText.text = playerActions[0];
        battleStatus = BattleStatus.PLAYERTURN;
    }

    public void chooseAction(){
        // attack
        if(actionNumber == 0){
            // usePlayerSkill.setSkill(0);
            StartCoroutine(playerAttackMotion(normalAttackSkill));
        }
        // skill
        else if(actionNumber == 1){
            battleStatus = BattleStatus.PLAYERTURNSKILL;
            setChooseSkillText();
        }
        // defend
        else if(actionNumber == 2){
            StartCoroutine(playerDefendMotion(2));
        }
        // flee
        else if(actionNumber == 3){
            StartCoroutine(playerFleeMotion(2));
        }
    }

    public void chooseSkill(){
        Skills playerSkill = mainPlayerStatus.playerSkills[0];
        if(skillNumber == 0) playerSkill = mainPlayerStatus.playerSkills[0];
        else if(skillNumber == 1) playerSkill = mainPlayerStatus.playerSkills[1];
        else if(skillNumber == 2) playerSkill = mainPlayerStatus.playerSkills[2];
        else if(skillNumber == 3) playerSkill = mainPlayerStatus.playerSkills[3];
        else if(skillNumber == 4) playerSkill = mainPlayerStatus.playerSkills[4];
        else if(skillNumber == 5) playerSkill = mainPlayerStatus.playerSkills[5];
        if(playerSkill.MpCost <= mainPlayerStatus.playerCurrentMp){
            StartCoroutine(playerAttackMotion(playerSkill));
        }
        else{
            StartCoroutine(notEnoughMP());
        }
    }

    public IEnumerator notEnoughMP(){
        battleStatus = BattleStatus.WAIT;
        battleText.text = "<color=#ffffffff>MPが足りない！</color>";
        yield return new WaitForSeconds(1f * mainRpgcontroller.gameTextSpeed);
        setChooseSkillText();
        battleStatus= BattleStatus.PLAYERTURNSKILL;
    }

    public void returnToChooseAction(){
        battleStatus = BattleStatus.PLAYERTURN;
        setChooseAtionText();
    }

    public void setChooseAtionText(){
        actionNumber = 0;
        playerActions[0] = actionAttack;
        playerActions[1] = actionSkill;
        playerActions[2] = actionDefend;
        playerActions[3] = actionFlee;
        playerActions[4] = "";
        playerActions[5] = "";
        playerActions[6] = "";
    }

    public void setChooseSkillText(){
        skillNumber = 0;
        if(mainPlayerStatus.playerSkillCount == 0){
            playerActions[0] = "";
            playerActions[1] = "";
            playerActions[2] = "";
            playerActions[3] = "";
            playerActions[4] = "";
            playerActions[5] = "";
            playerActions[6] = "";
        }
        else if(mainPlayerStatus.playerSkillCount == 1){
            playerActions[0] = "<color=#ffffffff>" + "▶︎" + mainPlayerStatus.playerSkills[0].skillName + "</color>";
            playerActions[1] = "";
            playerActions[2] = "";
            playerActions[3] = "";
            playerActions[4] = "";
            playerActions[5] = "";
            playerActions[6] = "";
        }
        else if(mainPlayerStatus.playerSkillCount == 2){
            playerActions[0] = "<color=#ffffffff>" + "▶︎" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "</color>";
            playerActions[1] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[1].skillName + "</color>";
            playerActions[2] = "";
            playerActions[3] = "";
            playerActions[4] = "";
            playerActions[5] = "";
            playerActions[6] = "";
        }
         else if(mainPlayerStatus.playerSkillCount == 3){
            playerActions[0] = "<color=#ffffffff>" + "▶︎" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "</color>";
            playerActions[1] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "</color>";
            playerActions[2] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[2].skillName + "</color>";
            playerActions[3] = "";
            playerActions[4] = "";
            playerActions[6] = "";
            playerActions[5] = "";
        }
        else if(mainPlayerStatus.playerSkillCount == 4){
            playerActions[0] = "<color=#ffffffff>" + "▶︎" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "</color>";
            playerActions[1] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName +  "\n" + mainPlayerStatus.playerSkills[3].skillName +"</color>";
            playerActions[2] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[2].skillName +  "\n" + mainPlayerStatus.playerSkills[3].skillName +"</color>";
            playerActions[3] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName +  "\n" + "▶︎" + mainPlayerStatus.playerSkills[3].skillName +"</color>";
            playerActions[4] = "";
            playerActions[5] = "";
            playerActions[6] = "";
        }
        else if(mainPlayerStatus.playerSkillCount == 5){
            playerActions[0] = "<color=#ffffffff>" + "▶︎" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName + "</color>";
            playerActions[1] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName + "</color>";
            playerActions[2] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName + "</color>";
            playerActions[3] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName + "</color>";
            playerActions[4] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[4].skillName + "</color>";
            playerActions[5] = "";
            playerActions[6] = "";
        }
        else if(mainPlayerStatus.playerSkillCount == 6){
            playerActions[0] = "<color=#ffffffff>" + "▶︎" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName +  "\n" + mainPlayerStatus.playerSkills[5].skillName + "</color>";
            playerActions[1] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName +  "\n" + mainPlayerStatus.playerSkills[5].skillName + "</color>";
            playerActions[2] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName +  "\n" + mainPlayerStatus.playerSkills[5].skillName + "</color>";
            playerActions[3] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName +  "\n" + mainPlayerStatus.playerSkills[5].skillName + "</color>";
            playerActions[4] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName  + "\n"+ "▶︎" + mainPlayerStatus.playerSkills[4].skillName +  "\n" + mainPlayerStatus.playerSkills[5].skillName + "</color>";
            playerActions[5] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName +  "\n" + "▶︎" + mainPlayerStatus.playerSkills[5] .skillName+ "</color>";
            playerActions[6] = "";
        }
    }

    // Actions
    public IEnumerator playerAttackMotion(Skills usingSkill){
        battleStatus = BattleStatus.PLAYERMOTION; 

        if(usingSkill.isHeal){

        }

        remainingEnemyNumber = numberEnemyAlive();

        //choose enemy
        if(!chosenEnemy){
            if(enemy1Status.enemyCurrentHp > 0){
                chosenEnemy = enemy1Status;
            }
            else if(enemyNumber > 1 && enemy2Status.enemyCurrentHp > 0){
                chosenEnemy = enemy2Status;
            }
            else if(enemyNumber > 2 && enemy3Status.enemyCurrentHp > 0){
                chosenEnemy = enemy3Status;
            }
        }

        if(usingSkill.isSkillTargetMultiple){
            int k = 0;
            allEnemys = new EnemyStatus[remainingEnemyNumber];
            if(enemy1Status.enemyCurrentHp > 0) {
                allEnemys[k] = enemy1Status;
                k++;
            }
            if(enemyNumber > 1 && enemy2Status.enemyCurrentHp > 0) {
                allEnemys[k] = enemy2Status;
                k++;
            }
            if(enemyNumber > 2 && enemy3Status.enemyCurrentHp > 0) {
                allEnemys[k] = enemy3Status;
                k++;
            }
        }

        battleText.text = "<color=#ffffffff>" + mainPlayerStatus.playerName + "の" + usingSkill.skillName + "！\n" + "</color>";
        mainPlayerStatus.playerCurrentMp -= usingSkill.MpCost;

        if(!usingSkill.isSkillTargetMultiple) StartCoroutine(enemyTakeDamage(chosenEnemy));
        else StartCoroutine(allEnemyTakeDamage(allEnemys));

        yield return new WaitForSeconds(1f * mainRpgcontroller.gameTextSpeed);

        int damage = 0;
        if(usingSkill.isAttack){
            if(!usingSkill.isSkillTargetMultiple){
                damage = calculateDamage(mainPlayerStatus, chosenEnemy, usingSkill, true);
                if(damage == 0){
                    battleText.text = "<color=#ffffffff>" + chosenEnemy.enemyName + "にかわされた" + "</color>";
                }
                else {
                    chosenEnemy.enemyCurrentHp -= damage;
                    battleText.text = "<color=#ffffffff>" + chosenEnemy.enemyName + "に " + damage + " のダメージ！" + "</color>";
                }
                if(chosenEnemy.enemyCurrentHp < 0)chosenEnemy.enemyCurrentHp = 0;
            }
            else {
                string battleTextTmp = "";
                for(int i=0; i<remainingEnemyNumber; i++){
                    damage = calculateDamage(mainPlayerStatus, allEnemys[i], usingSkill, true);
                    if(damage == 0){
                        battleTextTmp += "<color=#ffffffff>" + allEnemys[i].enemyName + "にかわされた" + "</color>\n";
                    }
                    else {
                        allEnemys[i].enemyCurrentHp -= damage;
                        battleTextTmp += "<color=#ffffffff>" + allEnemys[i].enemyName + "に " + damage + " のダメージ！" + "</color>\n";
                    }
                    if(allEnemys[i].enemyCurrentHp < 0)allEnemys[i].enemyCurrentHp = 0;
                }
                battleText.text = battleTextTmp;
            }

        }
        if(usingSkill.isHeal) {
            yield return new WaitForSeconds(1f * mainRpgcontroller.gameTextSpeed);
            int heal = calculateHeal(damage, usingSkill, mainPlayerStatus, enemy1Status, true);
            int beforeHeal = mainPlayerStatus.playerCurrentHp;

            if(mainPlayerStatus.playerCurrentHp + heal <= mainPlayerStatus.playerMaxHp) mainPlayerStatus.playerCurrentHp += heal;
            else mainPlayerStatus.playerCurrentHp = mainPlayerStatus.playerMaxHp;

            int afterHeal = mainPlayerStatus.playerCurrentHp;
            battleText.text = "<color=#ffffffff>HPを" + (afterHeal - beforeHeal) + "回復した！</color>";
        }
 
        //adjust health bar
        enemy1HP.value = enemy1Status.enemyCurrentHp;
        enemy2HP.value = enemy2Status.enemyCurrentHp;
        enemy3HP.value = enemy3Status.enemyCurrentHp;

        yield return new WaitForSeconds(1f * mainRpgcontroller.gameTextSpeed);

        string tmpBattleText = "";
        if(usingSkill.isSkillTargetMultiple){
            for(int i=0; i<remainingEnemyNumber; i++){
                if(allEnemys[i].enemyCurrentHp == 0){
                    tmpBattleText += "<color=#ffffffff>" + allEnemys[i].enemyName + "を倒した\n" + "</color>";
                    allEnemys[i].enemyImage.color = invisible;
                    if(allEnemys[i] == enemy1Status) {
                        enemy1HPSliderBGImage.color = invisible;
                        enemy1HPSliderBorderImage.color = invisible;
                        chosen1.SetActive(false);
                        enemy1.SetActive(false);
                    } 
                    if(allEnemys[i] == enemy2Status) {
                        enemy2HPSliderBGImage.color = invisible;
                        enemy2HPSliderBorderImage.color = invisible;
                        chosen2.SetActive(false);
                        enemy2.SetActive(false);
                    }
                    if(allEnemys[i] == enemy3Status) {
                        enemy3HPSliderBGImage.color = invisible;
                        enemy3HPSliderBorderImage.color = invisible;
                        chosen3.SetActive(false);
                        enemy3.SetActive(false);
                    }
                }
            }
        }
        else {
            if(chosenEnemy.enemyCurrentHp == 0){
                tmpBattleText += "<color=#ffffffff>" + chosenEnemy.enemyName + "を倒した\n" + "</color>";
                chosenEnemy.enemyImage.color = invisible;
                if(chosenEnemy == enemy1Status) {
                    enemy1HPSliderBGImage.color = invisible;
                    enemy1HPSliderBorderImage.color = invisible;
                    chosen1.SetActive(false);
                    // enemy1.SetActive(false);
                } 
                if(chosenEnemy == enemy2Status) {
                    enemy2HPSliderBGImage.color = invisible;
                    enemy2HPSliderBorderImage.color = invisible;
                    chosen2.SetActive(false);
                    // enemy2.SetActive(false);
                }
                if(chosenEnemy == enemy3Status) {
                    enemy3HPSliderBGImage.color = invisible;
                    enemy3HPSliderBorderImage.color = invisible;
                    chosen3.SetActive(false);
                    // enemy3.SetActive(false);
                }
            }
        }

        yield return new WaitForSeconds(1 * mainRpgcontroller.gameTextSpeed);
        if(!usingSkill.isSkillTargetMultiple){
            if(chosenEnemy.enemyCurrentHp == 0) {
                battleText.text = "<color=#ffffffff>" + chosenEnemy.enemyName + "を倒した " + "</color>";
                yield return new WaitForSeconds(1 * mainRpgcontroller.gameTextSpeed);
            }
        }
        else {
            battleText.text = tmpBattleText;
            yield return new WaitForSeconds(1 * mainRpgcontroller.gameTextSpeed);
        }

        remainingEnemyNumber = numberEnemyAlive();

        if(chosenEnemy.enemyCurrentHp == 0) {
            chosenEnemy = null;
        }

        if(remainingEnemyNumber == 0){
            battleStatus = BattleStatus.WIN;
            StartCoroutine(playerWinMotion(enemy1Status, enemy2Status, enemy3Status));
        }
        else {
            battleStatus = BattleStatus.ENEMYTURN;
            StartCoroutine(enemyTurn());
        }
    }

    public IEnumerator enemyTurn(){
        if(enemy1Status.enemyCurrentHp > 0){
            StartCoroutine(enemyAttackCheck(enemy1Status, enemy1Transform));
            yield return new WaitForSeconds(2.5f * mainRpgcontroller.gameTextSpeed);
        }
        if(playerAlive && enemyNumber > 1 && enemy2Status.enemyCurrentHp > 0){
            StartCoroutine(enemyAttackCheck(enemy2Status, enemy2Transform));
            yield return new WaitForSeconds(2.5f * mainRpgcontroller.gameTextSpeed);
        }
        if(playerAlive && enemyNumber > 2 && enemy3Status.enemyCurrentHp > 0){
            StartCoroutine(enemyAttackCheck(enemy3Status, enemy3Transform));
            yield return new WaitForSeconds(2.5f * mainRpgcontroller.gameTextSpeed);
        }
        yield return new WaitForSeconds(1 * mainRpgcontroller.gameTextSpeed);
        setChooseAtionText();
        battleText.text = playerActions[0];
        skillNumber = 0;
        actionNumber = 0;
        battleStatus = BattleStatus.PLAYERTURN;
    }

    // public IEnumerator playerSkillMotion(int seconds){
    //     battleStatus =BattleStatus.PLAYERMOTION; 
    //     yield return new WaitForSeconds(seconds * mainRpgcontroller.gameTextSpeed);
    // }

    public IEnumerator playerDefendMotion(int seconds){
        isPlayerDefending = true;
        battleStatus = BattleStatus.PLAYERMOTION; 
        battleText.text = "<color=#ffffffff>防御の構えをとった！</color>";
        yield return new WaitForSeconds(seconds * mainRpgcontroller.gameTextSpeed);
        battleStatus = BattleStatus.ENEMYTURN;
        StartCoroutine(enemyTurn());
    }

    public IEnumerator playerFleeMotion(int seconds){
        battleStatus =　BattleStatus.PLAYERMOTION;
        int enemyFastestSpeed = enemy1Status.enemySpeed;
        if(enemyNumber > 1 && enemy2Status.enemySpeed > enemyFastestSpeed) enemyFastestSpeed = enemy2Status.enemySpeed;
        if(enemyNumber > 2 && enemy3Status.enemySpeed > enemyFastestSpeed) enemyFastestSpeed = enemy3Status.enemySpeed;
        bool canFlee;
        if(mainPlayerStatus.playerSpeed < enemyFastestSpeed) canFlee = false;
        else canFlee = UnityEngine.Random.Range(-100,100) < mainPlayerStatus.playerSpeed - enemyFastestSpeed;

        battleText.text = "<color=#ffffffff>敵から逃げようとした！</color>";
        yield return new WaitForSeconds(1.5f * mainRpgcontroller.gameTextSpeed);
        if(canFlee) {
            battleText.text = "<color=#ffffffff>逃げ切った！</color>";
            yield return new WaitForSeconds(1.5f * mainRpgcontroller.gameTextSpeed);
            mainRpgcontroller.endBattle();
        }
        else {
            battleText.text = "<color=#ffffffff>敵に回り込まれてしまった。</color>";
            yield return new WaitForSeconds(1.5f * mainRpgcontroller.gameTextSpeed);
            battleStatus = BattleStatus.ENEMYTURN;
            StartCoroutine(enemyTurn());
        }
    }

    public IEnumerator enemyAttackCheck(EnemyStatus attackingEnemy, RectTransform attackingEnemyTransform) {
        int enemyChoice = UnityEngine.Random.Range(0,5);
        
        if(enemyChoice == 0) enemySkill = normalAttackSkill;
        else if(enemyChoice == 1) enemySkill = attackingEnemy.enemySkills[0];
        else if(enemyChoice == 2) enemySkill = attackingEnemy.enemySkills[1];
        else if(enemyChoice == 3) enemySkill = attackingEnemy.enemySkills[2];
        else if(enemyChoice == 4) enemySkill = attackingEnemy.enemySkills[3];

        battleText.text = "<color=#ffffffff>" + attackingEnemy.enemyName + "の" + enemySkill.skillName + "</color>";
        yield return new WaitForSeconds(1 * mainRpgcontroller.gameTextSpeed);
        StartCoroutine(enemyAttackMotion(attackingEnemyTransform));
        yield return new WaitForSeconds(0.6f * mainRpgcontroller.gameTextSpeed);
        
        int damage = 0;
        if(enemySkill.isAttack) {
            damage = calculateDamage(mainPlayerStatus, attackingEnemy, enemySkill, false);
            if(damage == 0){
                battleText.text = "<color=#ffffffff>敵の攻撃をかわした</color>";
            }
            else {
                mainPlayerStatus.playerCurrentHp -= damage;
                battleText.text = "<color=#ffffffff>" + damage + " のダメージを受けた" + "</color>";
            }
            if(mainPlayerStatus.playerCurrentHp < 0)mainPlayerStatus.playerCurrentHp = 0;
        }
        if(enemySkill.isHeal) {
            yield return new WaitForSeconds(1 * mainRpgcontroller.gameTextSpeed);
            battleText.text = "<color=#ffffffff>敵のHPが回復した。</color>";
            int heal = calculateHeal(damage, enemySkill, mainPlayerStatus, attackingEnemy ,false);
            if(attackingEnemy.enemyCurrentHp + heal <= attackingEnemy.enemyMaxHp)attackingEnemy.enemyCurrentHp += heal;
            else attackingEnemy.enemyCurrentHp = attackingEnemy.enemyMaxHp;
        }

        if(!isPlayerAlive()) playerAlive = false;
    }

    public IEnumerator enemyAttackMotion(RectTransform enemy){
        Vector3 enemyTmp = enemy.position;
        enemyTmp.y -= 0.5f;
        enemy.position = enemyTmp;
        yield return new WaitForSeconds(0.2f * mainRpgcontroller.gameTextSpeed);
        enemyTmp.y += 0.5f;
        enemy.position = enemyTmp;

        Vector3 otherButtonsTransformTmp = otherButtonsTransform.position;
        Vector3 playerControllerTransformTmp = playerControllerTransform.position;
        Vector3 battleTextHolderTransformTmp = battleTextHolderTransform.position;

        otherButtonsTransformTmp.y -= 0.2f;
        playerControllerTransformTmp.y -= 0.2f;
        battleTextHolderTransformTmp.y -= 0.2f;

        yield return new WaitForSeconds(0.2f * mainRpgcontroller.gameTextSpeed);
        otherButtonsTransform.position = otherButtonsTransformTmp;
        playerControllerTransform.position = playerControllerTransformTmp;
        battleTextHolderTransform.position = battleTextHolderTransformTmp;

        otherButtonsTransformTmp.y += 0.2f;
        playerControllerTransformTmp.y += 0.2f;
        battleTextHolderTransformTmp.y += 0.2f;

        yield return new WaitForSeconds(0.2f * mainRpgcontroller.gameTextSpeed);
        otherButtonsTransform.position = otherButtonsTransformTmp;
        playerControllerTransform.position = playerControllerTransformTmp;
        battleTextHolderTransform.position = battleTextHolderTransformTmp;
    }

    public IEnumerator playerWinMotion(EnemyStatus enemy1, EnemyStatus enemy2, EnemyStatus enemy3){
        int gainExperience = enemy1.enemyExperience;
        int getGold = enemy1.enemyGold;
        if(enemyNumber > 1) {
            gainExperience += enemy2.enemyExperience;
            getGold += enemy2.enemyGold;
        }
        if(enemyNumber > 2) {
            gainExperience += enemy3.enemyExperience;
            getGold += enemy3.enemyGold;
        }
        mainPlayerStatus.playerExperience += gainExperience;
        mainPlayerStatus.playerGold += getGold;

        battleText.text = "<color=#ffffffff>戦いに勝った！\n獲得EXP　" + gainExperience + "exp\n獲得ゴールド　" + getGold + "g</color>";
        yield return new WaitForSeconds(1 * mainRpgcontroller.gameTextSpeed);

        if(mainPlayerStatus.didPlayerLevelUp()){
            battleText.text = "<color=#ffffffff>レベルアップ！</color>"; 
            yield return new WaitForSeconds(1.5f * mainRpgcontroller.gameTextSpeed);
        }

        Skills newSkill = possibleNewSkill();
        Debug.Log(newSkill);

        bool getSkillChance = enemyNumber >= UnityEngine.Random.Range(0,10); // 10 - 30 %
        bool getItemChance = enemyNumber >= UnityEngine.Random.Range(0,10);

        if(newSkill){
            chosenNewSkillNumber = newSkill.skillNumber;
            if(getSkillChance){
                StartCoroutine(chooseNewSkill(newSkill));
            }
            else mainRpgcontroller.endBattle();
        }
        else mainRpgcontroller.endBattle();

        // if(enemyDropItem() {
        //     battleText.text = "<color=#ffffffff>何々ゲット！</color>"; 
        //     yield return new WaitForSeconds(1 * mainRpgcontroller.gameTextSpeed);
        // }

    }

    public IEnumerator playerLoseMotion(){
        yield return new WaitForSeconds(1 * mainRpgcontroller.gameTextSpeed);

    }

    public bool isPlayerAlive(){
        if(mainPlayerStatus.playerCurrentHp < 0){
            mainPlayerStatus.playerCurrentHp = 0;
            battleStatus = BattleStatus.LOSE;
            return false;
        }
        return true;
    }

    public IEnumerator enemyTakeDamage(EnemyStatus enemy){
        yield return new WaitForSeconds(1f * mainRpgcontroller.gameTextSpeed);
        enemy.enemyImage.color = invisible;
        yield return new WaitForSeconds(0.1f * mainRpgcontroller.gameTextSpeed);
        enemy.enemyImage.color = normal;
        yield return new WaitForSeconds(0.1f * mainRpgcontroller.gameTextSpeed);
        enemy.enemyImage.color = invisible;
        yield return new WaitForSeconds(0.1f * mainRpgcontroller.gameTextSpeed);
        enemy.enemyImage.color = normal;
    }

    public IEnumerator allEnemyTakeDamage(EnemyStatus[] allEnemys){
        yield return new WaitForSeconds(1f * mainRpgcontroller.gameTextSpeed);
        for(int i=0; i<remainingEnemyNumber; i++){
            allEnemys[i].enemyImage.color = invisible;
        }
        yield return new WaitForSeconds(0.1f * mainRpgcontroller.gameTextSpeed);
        for(int i=0; i<remainingEnemyNumber; i++){
            allEnemys[i].enemyImage.color = normal;
        }
        yield return new WaitForSeconds(0.1f * mainRpgcontroller.gameTextSpeed);
         for(int i=0; i<remainingEnemyNumber; i++){
            allEnemys[i].enemyImage.color = invisible;
        }
        yield return new WaitForSeconds(0.1f * mainRpgcontroller.gameTextSpeed);
        for(int i=0; i<remainingEnemyNumber; i++){
            allEnemys[i].enemyImage.color = normal;
        }
    }

    public IEnumerator wait(int seconds){
        battleStatus =BattleStatus.PLAYERMOTION; 
        yield return new WaitForSeconds(seconds * mainRpgcontroller.gameTextSpeed);
    }

    public IEnumerator chooseNewSkill(Skills newSkill){
        if(mainPlayerStatus.playerSkillCount < 6) {
            battleText.text = "<color=#ffffffff>敵の技を見切った。\n" + newSkill.skillName + "　を覚えた</color>";
            mainPlayerStatus.playerSkills[mainPlayerStatus.playerSkillCount].setSkill(newSkill.skillNumber);
            mainPlayerStatus.playerSkillCount++;
            yield return new WaitForSeconds(1.5f * mainRpgcontroller.gameTextSpeed);
            mainRpgcontroller.endBattle();
        }
        else {
            newSkillNumber = 0;
            battleStatus = BattleStatus.CHOOSENEWSKILL; 
            playerActions[0] = "<color=#ffffffff>敵の技を見切った！スキルを一つ忘れて\n" + newSkill.skillName + "　を覚えますか？\n" + "▶︎" + mainPlayerStatus.playerSkills[0].skillName + "　を忘れる\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "</color>";
            playerActions[1] = "<color=#ffffffff>敵の技を見切った！スキルを一つ忘れて\n" + newSkill.skillName + "　を覚えますか？\n" + mainPlayerStatus.playerSkills[0].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[1].skillName + "　を忘れる\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "</color>";
            playerActions[2] = "<color=#ffffffff>敵の技を見切った！スキルを一つ忘れて\n" + newSkill.skillName + "　を覚えますか？\n" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[2].skillName + "　を忘れる\n" + mainPlayerStatus.playerSkills[3].skillName + "</color>";
            playerActions[3] = "<color=#ffffffff>敵の技を見切った！スキルを一つ忘れて\n" + newSkill.skillName + "　を覚えますか？\n" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[3].skillName + "　を忘れる</color>";
            playerActions[4] = "<color=#ffffffff>" + newSkill.skillName + "　を覚えますか？\n" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + "▶︎" +  mainPlayerStatus.playerSkills[4].skillName +  "　を忘れる</color>";
            playerActions[5] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[5] .skillName + "　を忘れる</color>";
            playerActions[6] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName + "\n" + mainPlayerStatus.playerSkills[5].skillName + "　\n▶︎覚えない</color>";
        }
        
        yield return new WaitForSeconds(0f * mainRpgcontroller.gameTextSpeed);
    }

    public void tradeNewSkill(){
        if(newSkillNumber != 6) {
            Skills newSkill = tmpSkill.GetComponent<Skills>();
            newSkill.setSkill(chosenNewSkillNumber);
            StartCoroutine(tradeNewSkillMotion(mainPlayerStatus.playerSkills[newSkillNumber], newSkill));
            mainPlayerStatus.playerSkills[newSkillNumber].setSkill(chosenNewSkillNumber);
        }
    }

    public IEnumerator tradeNewSkillMotion(Skills oldSkill, Skills newSkill){
        battleStatus = BattleStatus.WAIT;
        battleText.text = "<color=#ffffffff>" + oldSkill.skillName + " を忘れて\n" + newSkill.skillName + "　を覚えた！</color>";
        yield return new WaitForSeconds(1.5f * mainRpgcontroller.gameTextSpeed);
        mainRpgcontroller.endBattle();
    }

    public Skills possibleNewSkill(){
        // enemy 1 enemySkill1 = 0, .... ,enemy2 enemySkill1 = 4,.... enemy3 enemySkill1 = 8
        EnemyStatus enemy = enemy1Status;
        int possibleNewSkillNumber = 0;
        int enemySkillNumber = 0;
        int[] possibleNewSkills = new int[12];

        for(int i=0; i<enemyNumber; i++){
            if(i == 0) enemy = enemy1Status;
            if(i == 1) enemy = enemy2Status;
            if(i == 2) enemy = enemy3Status;
            for(int j=0; j<4; j++){
                bool differentFound = true;
                for(int k=0; k<6; k++){
                    Debug.Log(enemy.enemySkills[j].skillName);
                    Debug.Log(k);
                    if(enemy.enemySkills[j].skillNumber == 0) differentFound = false;
                    Debug.Log(differentFound);

                    if(enemy.enemySkills[j].skillName == mainPlayerStatus.playerSkills[k].skillName) differentFound = false;
                    Debug.Log(differentFound);
                }
                if(differentFound) {
                    possibleNewSkills[possibleNewSkillNumber] = enemySkillNumber;
                    possibleNewSkillNumber++;
                }
                enemySkillNumber++;
            }
        }

        if(possibleNewSkillNumber == 0)return null;
        int randomSkillNumber = UnityEngine.Random.Range(0,possibleNewSkillNumber);
        
        if(possibleNewSkills[randomSkillNumber] == 0) return enemy1Status.enemySkills[0];
        else if(possibleNewSkills[randomSkillNumber] == 1) return enemy1Status.enemySkills[1];
        else if(possibleNewSkills[randomSkillNumber] == 2) return enemy1Status.enemySkills[2];
        else if(possibleNewSkills[randomSkillNumber] == 3) return enemy1Status.enemySkills[3];

        else if(possibleNewSkills[randomSkillNumber] == 4) return enemy2Status.enemySkills[0];
        else if(possibleNewSkills[randomSkillNumber] == 5) return enemy2Status.enemySkills[1];
        else if(possibleNewSkills[randomSkillNumber] == 6) return enemy2Status.enemySkills[2];
        else if(possibleNewSkills[randomSkillNumber] == 7) return enemy2Status.enemySkills[3];

        else if(possibleNewSkills[randomSkillNumber] == 8) return enemy3Status.enemySkills[0];
        else if(possibleNewSkills[randomSkillNumber] == 9) return enemy3Status.enemySkills[1];
        else if(possibleNewSkills[randomSkillNumber] == 10) return enemy3Status.enemySkills[2];
        else if(possibleNewSkills[randomSkillNumber] == 11) return enemy3Status.enemySkills[3];
        else return null;
    }

    public int numberEnemyAlive(){
        if(enemyNumber == 1){
            return enemy1Status.enemyCurrentHp > 0 ? 1 : 0; 
        }
        else if(enemyNumber == 2){
            int enemyNumber = 0;
            if(enemy1Status.enemyCurrentHp > 0) enemyNumber++;
            if(enemy2Status.enemyCurrentHp > 0) enemyNumber++;
            return enemyNumber;
        }
        else if(enemyNumber == 3){
            int enemyNumber = 0;
            if(enemy1Status.enemyCurrentHp > 0) enemyNumber++;
            if(enemy2Status.enemyCurrentHp > 0) enemyNumber++;
            if(enemy3Status.enemyCurrentHp > 0) enemyNumber++;
            return enemyNumber;
        }
        else return 0;
    }
    

    public int calculateDamage(MainPlayerStatus player, EnemyStatus enemy, Skills skill, bool isPlayerAttack){
        int attack;
        if(isPlayerAttack){
            int noDamageChance = player.playerSpeed < enemy.enemySpeed ? enemy.enemySpeed - player.playerSpeed : 0;
            bool noDamage = UnityEngine.Random.Range(1,100) < noDamageChance;
            if(noDamage) return 0;
            int criticalChance = player.playerCriticalChance;
            bool critical = UnityEngine.Random.Range(1, criticalChanceAdjuster) < criticalChance;

            if(skill.isPhysicalAttack){
                int playerPower = player.playerPhysicalAttack;
                float playerPhysicalMultiplyer = calculatePhysicalAttackMultiplyer();
                Debug.Log(playerPhysicalMultiplyer);
                if(critical) playerPower = (int)Convert.ToSingle(Math.Round(playerPower * (1 + (player.playerCriticalDamage * 0.1))));
                attack = (int)Convert.ToSingle(Math.Round(playerPower * skill.physicalAttackMultiplyer * playerPhysicalMultiplyer));
                attack -= enemy.enemyPhysicalDefense;
                if(attack <= 0) attack = 1;
            }
            else {
                int playerPower = player.playerMagicalAttack;
                float playerMagicalMultiplyer = calculateMagicalAttackMultiplyer();
                if(critical) playerPower = (int)Convert.ToSingle(Math.Round(playerPower * (1 + (player.playerCriticalDamage * 0.1))));
                attack = (int)Convert.ToSingle(Math.Round(playerPower * skill.magicalAttackMultiplyer * playerMagicalMultiplyer));
                attack -= enemy.enemyMagicalDefense;
                if(attack <= 0) attack = 1;
            }
        }
        else {
            int noDamageChance = player.playerSpeed > enemy.enemySpeed ? player.playerSpeed - enemy.enemySpeed : 0;
            bool noDamage = UnityEngine.Random.Range(1,100) < noDamageChance;
            float playerDefending = isPlayerDefending ? 2f : 1f;
            if(noDamage) return 0;
            if(skill.isPhysicalAttack){
                float physicalDefenseMultiplyer = calculatePhysicalDefenseMultiplyer();
                attack = (int)Convert.ToSingle(Math.Round(enemy.enemyMagicalAttack * skill.magicalAttackMultiplyer));
                attack -= (int)Convert.ToSingle(Math.Round(player.playerMagicalDefense * playerDefending * physicalDefenseMultiplyer));
                if(attack <= 0) attack = 1;
            }
            else {
                float magicalDefenseMultiplyer = calculateMagicalDefenseMultiplyer();
                attack = (int)Convert.ToSingle(Math.Round(enemy.enemyMagicalAttack * skill.magicalAttackMultiplyer));
                attack -= (int)Convert.ToSingle(Math.Round(player.playerMagicalDefense * playerDefending * magicalDefenseMultiplyer));
                if(attack <= 0) attack = 1;
            }
        }
        return attack;
    }

    public int calculateHeal(int damage, Skills skill, MainPlayerStatus player, EnemyStatus enemy, bool isPlayerTurn){
        int heal;
        if(isPlayerTurn){
            float magicalDefenseMultiplyer = calculateMagicalDefenseMultiplyer();
            float physicalDefenseMultiplyer = calculatePhysicalDefenseMultiplyer();
            heal = (int)Convert.ToSingle(Math.Round((player.playerPhysicalDefense * physicalDefenseMultiplyer 
                + player.playerMagicalDefense * magicalDefenseMultiplyer) * skill.healMultiplyer));
        }
        else {
            heal = (int)Convert.ToSingle(Math.Round((enemy.enemyPhysicalDefense + enemy.enemyMagicalDefense) * skill.healMultiplyer));
        }
        return heal;
    }

    public float calculatePhysicalAttackMultiplyer() {
        return mainPlayerStatus.playerArmourHead.physicalAttackMultiplyer + mainPlayerStatus.playerArmourBody.physicalAttackMultiplyer 
            + mainPlayerStatus.playerArmourFeet.physicalAttackMultiplyer + mainPlayerStatus.playerArmourHand.physicalAttackMultiplyer + mainPlayerStatus.playerNecklace.physicalAttackMultiplyer
            + mainPlayerStatus.playerWristband.physicalAttackMultiplyer + mainPlayerStatus.playerWeapon.physicalAttackMultiplyer - 6f;
    }

    public float calculateMagicalAttackMultiplyer() {
        return mainPlayerStatus.playerArmourHead.magicalAttackMultiplyer + mainPlayerStatus.playerArmourBody.magicalAttackMultiplyer 
            + mainPlayerStatus.playerArmourFeet.magicalAttackMultiplyer + mainPlayerStatus.playerArmourHand.magicalAttackMultiplyer + mainPlayerStatus.playerNecklace.magicalAttackMultiplyer
            + mainPlayerStatus.playerWristband.magicalAttackMultiplyer + mainPlayerStatus.playerWeapon.magicalAttackMultiplyer - 6f;
    }

    public float calculatePhysicalDefenseMultiplyer() {
        return mainPlayerStatus.playerArmourHead.physicalDefenseMultiplyer + mainPlayerStatus.playerArmourBody.physicalDefenseMultiplyer 
            + mainPlayerStatus.playerArmourFeet.physicalDefenseMultiplyer + mainPlayerStatus.playerArmourHand.physicalDefenseMultiplyer + mainPlayerStatus.playerNecklace.physicalDefenseMultiplyer
            + mainPlayerStatus.playerWristband.physicalDefenseMultiplyer + mainPlayerStatus.playerWeapon.physicalDefenseMultiplyer - 6f;
    }

    public float calculateMagicalDefenseMultiplyer() {
        return mainPlayerStatus.playerArmourHead.magicalDefenseMultiplyer + mainPlayerStatus.playerArmourBody.magicalDefenseMultiplyer 
            + mainPlayerStatus.playerArmourFeet.magicalDefenseMultiplyer + mainPlayerStatus.playerArmourHand.magicalDefenseMultiplyer + mainPlayerStatus.playerNecklace.magicalDefenseMultiplyer
            + mainPlayerStatus.playerWristband.magicalDefenseMultiplyer + mainPlayerStatus.playerWeapon.magicalDefenseMultiplyer - 6f;
    }
}
