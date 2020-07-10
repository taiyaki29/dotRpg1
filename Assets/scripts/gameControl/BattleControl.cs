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
    Skills skills;
    Skills enemySkill;

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

    int enemyNumber;
    int remainingEnemyNumber;

    int stageNumber;

    string actionAttack = "<color=#ffffffff>▶︎攻撃\nスキル\n防御\n逃げる</color>";
    string actionSkill = "<color=#ffffffff>攻撃\n▶︎スキル\n防御\n逃げる</color>";
    string actionDefend = "<color=#ffffffff>攻撃\nスキル\n▶︎防御\n逃げる</color>";
    string actionFlee = "<color=#ffffffff>攻撃\nスキル\n防御\n▶︎逃げる</color>";

    public string[] playerActions = new string[6]; 
    public int actionNumber = 0;

    public int skillNumber = 0;
    public int newSkillNumber = 0;
    public int chosenNewSkillNumber = 0;

    public bool playerAlive = true;

    Color invisible;
    Color normal;
    Color black;
    
    void Start(){
        setChooseAtionText();

        battleStatus = BattleStatus.NO_BATTLE;
        Debug.Log("battle start");
        
        mainRpgcontroller = mainRpgcontrol.GetComponent<MainRpgController>();
        mainPlayerStatus = player.GetComponent<MainPlayerStatus>();
        skills = skill.GetComponent<Skills>();
        enemySkill = skill.GetComponent<Skills>();

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
            StartCoroutine(playerAttackMotion(mainPlayerStatus.playerSkills[0]));
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
        playerActions[0] = actionAttack;
        playerActions[1] = actionSkill;
        playerActions[2] = actionDefend;
        playerActions[3] = actionFlee;
        playerActions[4] = "";
        playerActions[5] = "";
    }

    public void setChooseSkillText(){
        if(mainPlayerStatus.playerSkillCount == 0){
            playerActions[0] = "";
            playerActions[1] = "";
            playerActions[2] = "";
            playerActions[3] = "";
            playerActions[4] = "";
            playerActions[5] = "";
        }
        else if(mainPlayerStatus.playerSkillCount == 1){
            playerActions[0] = "<color=#ffffffff>" + "▶︎" + mainPlayerStatus.playerSkills[0].skillName + "</color>";
            playerActions[1] = "";
            playerActions[2] = "";
            playerActions[3] = "";
            playerActions[4] = "";
            playerActions[5] = "";
        }
        else if(mainPlayerStatus.playerSkillCount == 2){
            playerActions[0] = "<color=#ffffffff>" + "▶︎" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "</color>";
            playerActions[1] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[1].skillName + "</color>";
            playerActions[2] = "";
            playerActions[3] = "";
            playerActions[4] = "";
            playerActions[5] = "";
        }
         else if(mainPlayerStatus.playerSkillCount == 3){
            playerActions[0] = "<color=#ffffffff>" + "▶︎" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "</color>";
            playerActions[1] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "</color>";
            playerActions[2] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[2].skillName + "</color>";
            playerActions[3] = "";
            playerActions[4] = "";
            playerActions[5] = "";
        }
        else if(mainPlayerStatus.playerSkillCount == 4){
            playerActions[0] = "<color=#ffffffff>" + "▶︎" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "</color>";
            playerActions[1] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName +  "\n" + mainPlayerStatus.playerSkills[3].skillName +"</color>";
            playerActions[2] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[2].skillName +  "\n" + mainPlayerStatus.playerSkills[3].skillName +"</color>";
            playerActions[3] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName +  "\n" + "▶︎" + mainPlayerStatus.playerSkills[3].skillName +"</color>";
            playerActions[4] = "";
            playerActions[5] = "";
        }
        else if(mainPlayerStatus.playerSkillCount == 5){
            playerActions[0] = "<color=#ffffffff>" + "▶︎" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName + "</color>";
            playerActions[1] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName + "</color>";
            playerActions[2] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName + "</color>";
            playerActions[3] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName + "</color>";
            playerActions[4] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[4].skillName + "</color>";
            playerActions[5] = "";
        }
        else if(mainPlayerStatus.playerSkillCount == 6){
            playerActions[0] = "<color=#ffffffff>" + "▶︎" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName +  "\n" + mainPlayerStatus.playerSkills[5].skillName + "</color>";
            playerActions[1] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName +  "\n" + mainPlayerStatus.playerSkills[5].skillName + "</color>";
            playerActions[2] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName +  "\n" + mainPlayerStatus.playerSkills[5].skillName + "</color>";
            playerActions[3] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName +  "\n" + mainPlayerStatus.playerSkills[5].skillName + "</color>";
            playerActions[4] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "▶︎" + "\n" + mainPlayerStatus.playerSkills[4].skillName +  "\n" + mainPlayerStatus.playerSkills[5].skillName + "</color>";
            playerActions[5] = "<color=#ffffffff>" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName +  "\n" + "▶︎" + mainPlayerStatus.playerSkills[5] .skillName+ "</color>";
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

        if(!usingSkill.isSkillTargetMultiple){
            int damage = calculateDamage(mainPlayerStatus, chosenEnemy, usingSkill, true);
            chosenEnemy.enemyCurrentHp -= damage;
            battleText.text = "<color=#ffffffff>" + chosenEnemy.enemyName + "に " + damage + " のダメージ！" + "</color>";
            if(chosenEnemy.enemyCurrentHp < 0)chosenEnemy.enemyCurrentHp = 0;
        }
        else {
            string battleTextTmp = "";
            for(int i=0; i<remainingEnemyNumber; i++){
                int damage = calculateDamage(mainPlayerStatus, allEnemys[i], usingSkill, true);
                allEnemys[i].enemyCurrentHp -= damage;
                battleTextTmp += "<color=#ffffffff>" + allEnemys[i].enemyName + "に " + damage + " のダメージ！\n" + "</color>";
                if(allEnemys[i].enemyCurrentHp < 0)allEnemys[i].enemyCurrentHp = 0;
            }
            battleText.text = battleTextTmp;
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

    public IEnumerator playerSkillMotion(int seconds){
        battleStatus =BattleStatus.PLAYERMOTION; 
        yield return new WaitForSeconds(seconds * mainRpgcontroller.gameTextSpeed);
    }

    public IEnumerator playerDefendMotion(int seconds){
        battleStatus =BattleStatus.PLAYERMOTION; 
        yield return new WaitForSeconds(seconds * mainRpgcontroller.gameTextSpeed);
    }

    public IEnumerator playerFleeMotion(int seconds){
        battleStatus =BattleStatus.PLAYERMOTION; 
        yield return new WaitForSeconds(seconds * mainRpgcontroller.gameTextSpeed);
    }

    public IEnumerator enemyAttackCheck(EnemyStatus attackingEnemy, RectTransform attackingEnemyTransform) {
        int enemyChoice = UnityEngine.Random.Range(0,4);
        
        if(enemyChoice == 0) enemySkill = attackingEnemy.enemySkills[0];
        else if(enemyChoice == 1) enemySkill = attackingEnemy.enemySkills[1];
        else if(enemyChoice == 2) enemySkill = attackingEnemy.enemySkills[2];
        else if(enemyChoice == 3) enemySkill = attackingEnemy.enemySkills[3];

        battleText.text = "<color=#ffffffff>" + attackingEnemy.enemyName + "の" + enemySkill.skillName + "</color>";
        yield return new WaitForSeconds(1 * mainRpgcontroller.gameTextSpeed);
        StartCoroutine(enemyAttackMotion(attackingEnemyTransform));
        yield return new WaitForSeconds(0.6f * mainRpgcontroller.gameTextSpeed);

        int damage = calculateDamage(mainPlayerStatus, attackingEnemy, enemySkill, false);
        mainPlayerStatus.playerCurrentHp -= damage;
        battleText.text = "<color=#ffffffff>" + damage + " のダメージを受けた" + "</color>";
        if(mainPlayerStatus.playerCurrentHp < 0)mainPlayerStatus.playerCurrentHp = 0;

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

        battleText.text = "<color=#ffffffff>戦いに勝った！\n獲得EXP　" + gainExperience + "exp\n獲得ゴールド　" + getGold + "g</color>";
        yield return new WaitForSeconds(1 * mainRpgcontroller.gameTextSpeed);

        // if(mainPlayerStatus.didPlayerLevelUp()){
        //     battleText.text = "<color=#ffffffff>レベルアップ！</color>"; 
        //     yield return new WaitForSeconds(1 * mainRpgcontroller.gameTextSpeed);
        // }

        Skills newSkill = possibleNewSkill();

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
            battleStatus = BattleStatus.CHOOSENEWSKILL; 
            playerActions[0] = "<color=#ffffffff>敵の技を見切った。スキルを一つ忘れて　" + newSkill.skillName + "　を覚えますか？\n" + "▶︎" + mainPlayerStatus.playerSkills[0].skillName + "　を忘れる\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName +  "\n" + mainPlayerStatus.playerSkills[5].skillName + "\n覚えない</color>";
            playerActions[1] = "<color=#ffffffff>敵の技を見切った。スキルを一つ忘れて　" + newSkill.skillName + "　を覚えますか？\n" + mainPlayerStatus.playerSkills[0].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[1].skillName + "　を忘れる\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName +  "\n" + mainPlayerStatus.playerSkills[5].skillName + "\n覚えない</color>";
            playerActions[2] = "<color=#ffffffff>敵の技を見切った。スキルを一つ忘れて　" + newSkill.skillName + "　を覚えますか？\n" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[2].skillName + "　を忘れる\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName +  "\n" + mainPlayerStatus.playerSkills[5].skillName + "\n覚えない</color>";
            playerActions[3] = "<color=#ffffffff>敵の技を見切った。スキルを一つ忘れて　" + newSkill.skillName + "　を覚えますか？\n" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + "▶︎" + mainPlayerStatus.playerSkills[3].skillName + "　を忘れる\n" + mainPlayerStatus.playerSkills[4].skillName +  "\n" + mainPlayerStatus.playerSkills[5].skillName + "\n覚えない</color>";
            playerActions[4] = "<color=#ffffffff>敵の技を見切った。スキルを一つ忘れて　" + newSkill.skillName + "　を覚えますか？\n" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "▶︎" + "\n" + mainPlayerStatus.playerSkills[4].skillName +  "を忘れる\n" + mainPlayerStatus.playerSkills[5].skillName + "\n覚えない</color>";
            playerActions[5] = "<color=#ffffffff>敵の技を見切った。スキルを一つ忘れて　" + newSkill.skillName + "　を覚えますか？\n" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName +  "\n" + "▶︎" + mainPlayerStatus.playerSkills[5] .skillName+ "　を忘れる\n覚えない</color>";
            playerActions[6] = "<color=#ffffffff>敵の技を見切った。スキルを一つ忘れて　" + newSkill.skillName + "　を覚えますか？\n" + mainPlayerStatus.playerSkills[0].skillName + "\n" + mainPlayerStatus.playerSkills[1].skillName + "\n" + mainPlayerStatus.playerSkills[2].skillName + "\n" + mainPlayerStatus.playerSkills[3].skillName + "\n" + mainPlayerStatus.playerSkills[4].skillName +  "\n" + "▶︎" + mainPlayerStatus.playerSkills[5] .skillName+ "　\n▶︎覚えない</color>";
        }
        
        yield return new WaitForSeconds(0f * mainRpgcontroller.gameTextSpeed);
    }

    public void tradeNewSkill(){
        if(newSkillNumber != 6) mainPlayerStatus.playerSkills[newSkillNumber].setSkill(chosenNewSkillNumber);
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
                    if(enemy.enemySkills[j].skillName == mainPlayerStatus.playerSkills[k].skillName) differentFound = false;
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
            if(skill.isPhysicalAttack){
                attack = (int)Convert.ToSingle(Math.Round(player.playerPhysicalAttack * skill.physicalAttackMultiplyer));
                attack -= enemy.enemyPhysicalDefense;
                if(attack <= 0) attack = 1;
            }
            else {
                attack = (int)Convert.ToSingle(Math.Round(player.playerMagicalAttack * skill.magicalAttackMultiplyer));
                attack -= enemy.enemyMagicalDefense;
                if(attack <= 0) attack = 1;
            }
        }
        else {
            if(skill.isPhysicalAttack){
                attack = (int)Convert.ToSingle(Math.Round(enemy.enemyPhysicalAttack * skill.physicalAttackMultiplyer));
                attack -= player.playerPhysicalDefense;
                if(attack <= 0) attack = 1;
            }
            else {
                attack = (int)Convert.ToSingle(Math.Round(enemy.enemyMagicalAttack * skill.magicalAttackMultiplyer));
                attack -= player.playerMagicalDefense;
                if(attack <= 0) attack = 1;
            }
        }
        return attack;
    }
}
