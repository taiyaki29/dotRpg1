﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum BattleStatus { START, PLAYERTURN, PLAYERTURNSKILL, PLAYERMOTION, ENEMYTURN, WIN, LOSE, NO_BATTLE }

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
    Skills useSkill;

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

    EnemyStatus enemy1Status;
    EnemyStatus enemy2Status;
    EnemyStatus enemy3Status;

    public EnemyStatus chosenEnemy;

    int enemyNumber;

    int stageNumber;

    string actionAttack = "<color=#ffffffff>▶︎攻撃\nスキル\n防御\n逃げる</color>";
    string actionSkill = "<color=#ffffffff>攻撃\n▶︎スキル\n防御\n逃げる</color>";
    string actionDefend = "<color=#ffffffff>攻撃\nスキル\n▶︎防御\n逃げる</color>";
    string actionFlee = "<color=#ffffffff>攻撃\nスキル\n防御\n▶︎逃げる</color>";

    string skill_0;
    string skill_1;
    string skill_2;
    string skill_3;
    string skill_4;
    string skill_5;

    public string[] playerActions = new string[6]; 
    public int actionNumber = 0;

    public int skillNumber = 0;

    Color invisible;
    Color normal;
    
    void Start(){
        setChooseAtionText();

        battleStatus = BattleStatus.NO_BATTLE;
        Debug.Log("battle start");
        
        mainRpgcontroller = mainRpgcontrol.GetComponent<MainRpgController>();
        mainPlayerStatus = player.GetComponent<MainPlayerStatus>();
        skills = skill.GetComponent<Skills>();

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

        invisible = new Color(1.0f, 1.0f, 1.0f, 0f);
        normal = new Color(1.0f, 1.0f, 1.0f, 1.0f);
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
            Debug.Log(enemy1Status.enemyMaxHp);
            Debug.Log(enemy1HP.maxValue);
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
        Debug.Log("start wait");
        yield return new WaitForSeconds(1.5f);
        battleText.text = playerActions[0];
        battleStatus = BattleStatus.PLAYERTURN;
        Debug.Log("end wait");
    }

    public void chooseAction(){
        // attack
        if(actionNumber == 0){
            StartCoroutine(playerAttackMotion(2));
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
        useSkill = skills.useSkill(mainPlayerStatus.playerSkills[skillNumber]);
        StartCoroutine(playerSkillMotion(2));
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
        if(mainPlayerStatus.playerSkills[0] != -1) skill_0 = skills.returnSkillName(mainPlayerStatus.playerSkills[0]);
        if(mainPlayerStatus.playerSkills[1] != -1) skill_1 = skills.returnSkillName(mainPlayerStatus.playerSkills[1]);
        if(mainPlayerStatus.playerSkills[2] != -1) skill_2 = skills.returnSkillName(mainPlayerStatus.playerSkills[2]);
        if(mainPlayerStatus.playerSkills[3] != -1) skill_3 = skills.returnSkillName(mainPlayerStatus.playerSkills[3]);
        if(mainPlayerStatus.playerSkills[4] != -1) skill_4 = skills.returnSkillName(mainPlayerStatus.playerSkills[4]);
        if(mainPlayerStatus.playerSkills[5] != -1) skill_5 = skills.returnSkillName(mainPlayerStatus.playerSkills[5]);

        if(mainPlayerStatus.playerSkillCount == 0){
            playerActions[0] = "";
            playerActions[1] = "";
            playerActions[2] = "";
            playerActions[3] = "";
            playerActions[4] = "";
            playerActions[5] = "";
        }
        else if(mainPlayerStatus.playerSkillCount == 1){
            playerActions[0] = "<color=#ffffffff>" + "▶︎" + skill_0 + "</color>";
            playerActions[1] = "";
            playerActions[2] = "";
            playerActions[3] = "";
            playerActions[4] = "";
            playerActions[5] = "";
        }
        else if(mainPlayerStatus.playerSkillCount == 2){
            playerActions[0] = "<color=#ffffffff>" + "▶︎" + skill_0 + "\n" + skill_1 + "</color>";
            playerActions[1] = "<color=#ffffffff>" + skill_0 + "\n" + "▶︎" + skill_1 + "</color>";
            playerActions[2] = "";
            playerActions[3] = "";
            playerActions[4] = "";
            playerActions[5] = "";
        }
         else if(mainPlayerStatus.playerSkillCount == 3){
            playerActions[0] = "<color=#ffffffff>" + "▶︎" + skill_0 + "\n" + skill_1 + "\n" + skill_2 + "</color>";
            playerActions[1] = "<color=#ffffffff>" + skill_0 + "\n" + "▶︎" + skill_1 + "\n" + skill_2 + "</color>";
            playerActions[2] = "<color=#ffffffff>" + skill_0 + "\n" + skill_1 + "\n" + "▶︎" + skill_2 + "</color>";
            playerActions[3] = "";
            playerActions[4] = "";
            playerActions[5] = "";
        }
        else if(mainPlayerStatus.playerSkillCount == 4){
            playerActions[0] = "<color=#ffffffff>" + "▶︎" + skill_0 + "\n" + skill_1 + "\n" + skill_2 + "\n" + skill_3 + "</color>";
            playerActions[1] = "<color=#ffffffff>" + skill_0 + "\n" + "▶︎" + skill_1 + "\n" + skill_2 +  "\n" + skill_3 +"</color>";
            playerActions[2] = "<color=#ffffffff>" + skill_0 + "\n" + skill_1 + "\n" + "▶︎" + skill_2 +  "\n" + skill_3 +"</color>";
            playerActions[3] = "<color=#ffffffff>" + skill_0 + "\n" + skill_1 + "\n" + skill_2 +  "\n" + "▶︎" + skill_3 +"</color>";
            playerActions[4] = "";
            playerActions[5] = "";
        }
        else if(mainPlayerStatus.playerSkillCount == 5){
            playerActions[0] = "<color=#ffffffff>" + "▶︎" + skill_0 + "\n" + skill_1 + "\n" + skill_2 + "\n" + skill_3 + "\n" + skill_4 + "</color>";
            playerActions[1] = "<color=#ffffffff>" + skill_0 + "\n" + "▶︎" + skill_1 + "\n" + skill_2 + "\n" + skill_3 + "\n" + skill_4 + "</color>";
            playerActions[2] = "<color=#ffffffff>" + skill_0 + "\n" + skill_1 + "\n" + "▶︎" + skill_2 + "\n" + skill_3 + "\n" + skill_4 + "</color>";
            playerActions[3] = "<color=#ffffffff>" + skill_0 + "\n" + skill_1 + "\n" + skill_2 + "\n" + "▶︎" + skill_3 + "\n" + skill_4 + "</color>";
            playerActions[4] = "<color=#ffffffff>" + skill_0 + "\n" + skill_1 + "\n" + skill_2 + "\n" + skill_3 + "\n" + "▶︎" + skill_4 + "</color>";
            playerActions[5] = "";
        }
        else if(mainPlayerStatus.playerSkillCount == 6){
            playerActions[0] = "<color=#ffffffff>" + "▶︎" + skill_0 + "\n" + skill_1 + "\n" + skill_2 + "\n" + skill_3 + "\n" + skill_4 +  "\n" + skill_5 + "</color>";
            playerActions[1] = "<color=#ffffffff>" + skill_0 + "\n" + "▶︎" + skill_1 + "\n" + skill_2 + "\n" + skill_3 + "\n" + skill_4 +  "\n" + skill_5 + "</color>";
            playerActions[2] = "<color=#ffffffff>" + skill_0 + "\n" + skill_1 + "\n" + "▶︎" + skill_2 + "\n" + skill_3 + "\n" + skill_4 +  "\n" + skill_5 + "</color>";
            playerActions[3] = "<color=#ffffffff>" + skill_0 + "\n" + skill_1 + "\n" + skill_2 + "\n" + "▶︎" + skill_3 + "\n" + skill_4 +  "\n" + skill_5 + "</color>";
            playerActions[4] = "<color=#ffffffff>" + skill_0 + "\n" + skill_1 + "\n" + skill_2 + "\n" + skill_3 + "▶︎" + "\n" + skill_4 +  "\n" + skill_5 + "</color>";
            playerActions[5] = "<color=#ffffffff>" + skill_0 + "\n" + skill_1 + "\n" + skill_2 + "\n" + skill_3 + "\n" + skill_4 +  "\n" + "▶︎" + skill_5 + "</color>";
        }
    }

    // Actions
    public IEnumerator playerAttackMotion(int seconds){
        battleStatus = BattleStatus.PLAYERMOTION; 
        // yield return new WaitForSeconds(1);

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

        battleText.text = "<color=#ffffffff>" + mainPlayerStatus.playerName + "が" + chosenEnemy.enemyName + "を攻撃！\n" + "</color>";

        StartCoroutine(enemyTakeDamage(chosenEnemy));

        yield return new WaitForSeconds(1f);

        if(mainPlayerStatus.playerPhysicalAttack <= chosenEnemy.enemyPhysicalDefense){
            chosenEnemy.enemyCurrentHp--;
            battleText.text = "<color=#ffffffff>" + chosenEnemy.enemyName + "に 1 " + "のダメージ！" + "</color>";
        }
        else{
            chosenEnemy.enemyCurrentHp -= mainPlayerStatus.playerPhysicalAttack - chosenEnemy.enemyPhysicalDefense;
            if(chosenEnemy.enemyCurrentHp < 0)chosenEnemy.enemyCurrentHp = 0;
            battleText.text = "<color=#ffffffff>" + chosenEnemy.enemyName + "に " + (mainPlayerStatus.playerPhysicalAttack - chosenEnemy.enemyPhysicalDefense) + " のダメージ！" + "</color>";
        }

        yield return new WaitForSeconds(0.4f);
        //adjust health bar
        if(chosenEnemy == enemy1Status){
            enemy1HP.value = chosenEnemy.enemyCurrentHp;
        }
        else if(chosenEnemy == enemy2Status){
            enemy2HP.value = chosenEnemy.enemyCurrentHp;
        }
        else if(chosenEnemy == enemy3Status){
            enemy3HP.value = chosenEnemy.enemyCurrentHp;
        }

        if(chosenEnemy.enemyCurrentHp == 0) {
            chosenEnemy.enemyImage.color = invisible;
            if(chosenEnemy == enemy1Status) {
                enemy1HPSliderBGImage.color = invisible;
                enemy1HPSliderBorderImage.color = invisible;
            } 
            if(chosenEnemy == enemy2Status) {
                enemy2HPSliderBGImage.color = invisible;
                enemy2HPSliderBorderImage.color = invisible;
            }
            if(chosenEnemy == enemy3Status) {
                enemy3HPSliderBGImage.color = invisible;
                enemy3HPSliderBorderImage.color = invisible;
            }
        }

        yield return new WaitForSeconds(1);
        
        if(chosenEnemy.enemyCurrentHp == 0) {
            battleText.text = "<color=#ffffffff>" + chosenEnemy.enemyName + "を倒した " + "</color>";
            chosenEnemy = null;
            yield return new WaitForSeconds(1);
        }

        if(!isEnemyAlive()){
            StartCoroutine(playerWinMotion());
        }
        else {
            battleStatus = BattleStatus.ENEMYTURN;
            StartCoroutine(enemyTurn());
            Debug.Log("enemy turn");
        }
    }

    public IEnumerator enemyTurn(){
        // enemyChoice = 0 enemy normal attack
        // enemyChoice = 1 enemy skill
        bool playerAlive = true;
        if(enemy1Status.enemyCurrentHp > 0){
            int enemyChoice = UnityEngine.Random.Range(0,2);
            enemyChoice = 0; //tmp!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if(enemyChoice == 0){
                battleText.text = "<color=#ffffffff>" + enemy1Status.enemyName + "の攻撃 " + "</color>";
                yield return new WaitForSeconds(1);
                StartCoroutine(enemyAttackMotion(enemy1Transform));
                yield return new WaitForSeconds(0.6f);
                if(enemy1Status.enemyPhysicalAttack <= mainPlayerStatus.playerPhysicalDefense){
                    mainPlayerStatus.playerCurrentHp--;
                    battleText.text = "<color=#ffffffff>" + " 1 " + "のダメージを受けた" + "</color>";
                }
                else{
                    mainPlayerStatus.playerCurrentHp -= enemy3Status.enemyPhysicalAttack - mainPlayerStatus.playerCurrentHp;
                    battleText.text = "<color=#ffffffff>" + (enemy1Status.enemyPhysicalAttack - mainPlayerStatus.playerPhysicalDefense) + "のダメージを受けた " + "</color>";
                }
                if(mainPlayerStatus.playerCurrentHp < 0)mainPlayerStatus.playerCurrentHp = 0;
                yield return new WaitForSeconds(1f);
                if(!isPlayerAlive()) playerAlive = false;

            }
            else if(enemyChoice == 1){

            }
        }
        if(playerAlive && enemyNumber > 1 && enemy2Status.enemyCurrentHp > 0){
            int enemyChoice = UnityEngine.Random.Range(0,2);
            enemyChoice = 0; //tmp!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            if(enemy2Status.enemyCurrentHp > 0){
                if(enemyChoice == 0){
                    battleText.text = "<color=#ffffffff>" + enemy2Status.enemyName + "の攻撃 " + "</color>";
                    yield return new WaitForSeconds(1);
                    StartCoroutine(enemyAttackMotion(enemy2Transform));
                    yield return new WaitForSeconds(0.6f);
                    if(enemy2Status.enemyPhysicalAttack <= mainPlayerStatus.playerPhysicalDefense){
                        mainPlayerStatus.playerCurrentHp--;
                        battleText.text = "<color=#ffffffff>" + " 1 " + "のダメージを受けた" + "</color>";
                    }
                    else{
                        mainPlayerStatus.playerCurrentHp -= enemy3Status.enemyPhysicalAttack - mainPlayerStatus.playerCurrentHp;
                        battleText.text = "<color=#ffffffff>" + (enemy2Status.enemyPhysicalAttack - mainPlayerStatus.playerPhysicalDefense) + "のダメージを受けた " + "</color>";
                    }
                    if(mainPlayerStatus.playerCurrentHp < 0)mainPlayerStatus.playerCurrentHp = 0;
                    yield return new WaitForSeconds(1f);
                    if(!isPlayerAlive()) playerAlive = false;

                }
                else if(enemyChoice == 1){

                }
            }
        }
        if(playerAlive && enemyNumber > 2 && enemy3Status.enemyCurrentHp > 0){
            int enemyChoice = UnityEngine.Random.Range(0,2);
            enemyChoice = 0; //tmp!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            if(enemy3Status.enemyCurrentHp > 0){
                if(enemyChoice == 0){
                    battleText.text = "<color=#ffffffff>" + enemy3Status.enemyName + "の攻撃 " + "</color>";
                    yield return new WaitForSeconds(1);
                    StartCoroutine(enemyAttackMotion(enemy3Transform));
                    yield return new WaitForSeconds(0.6f);
                    if(enemy3Status.enemyPhysicalAttack <= mainPlayerStatus.playerPhysicalDefense){
                        mainPlayerStatus.playerCurrentHp--;
                        battleText.text = "<color=#ffffffff>" + " 1 " + "のダメージを受けた" + "</color>";
                    }
                    else{
                        mainPlayerStatus.playerCurrentHp -= enemy3Status.enemyPhysicalAttack - mainPlayerStatus.playerCurrentHp;
                        battleText.text = "<color=#ffffffff>" + (enemy3Status.enemyPhysicalAttack - mainPlayerStatus.playerPhysicalDefense) + "のダメージを受けた " + "</color>";
                    }
                    if(mainPlayerStatus.playerCurrentHp < 0)mainPlayerStatus.playerCurrentHp = 0;
                    yield return new WaitForSeconds(1f);
                    if(!isPlayerAlive()) playerAlive = false;

                }
                else if(enemyChoice == 1){

                }
            }
        }
        yield return new WaitForSeconds(1);
        battleText.text = playerActions[0];
        battleStatus = BattleStatus.PLAYERTURN;
    }

    public IEnumerator playerSkillMotion(int seconds){
        battleStatus =BattleStatus.PLAYERMOTION; 
        yield return new WaitForSeconds(seconds);
    }
    public IEnumerator playerDefendMotion(int seconds){
        battleStatus =BattleStatus.PLAYERMOTION; 
        yield return new WaitForSeconds(seconds);
    }
    public IEnumerator playerFleeMotion(int seconds){
        battleStatus =BattleStatus.PLAYERMOTION; 
        yield return new WaitForSeconds(seconds);
    }
    public IEnumerator enemyAttackMotion(RectTransform enemy){
        Vector3 enemyTmp = enemy.position;
        enemyTmp.y -= 0.5f;
        enemy.position = enemyTmp;
        yield return new WaitForSeconds(0.2f);
        enemyTmp.y += 0.5f;
        enemy.position = enemyTmp;

        Vector3 otherButtonsTransformTmp = otherButtonsTransform.position;
        Vector3 playerControllerTransformTmp = playerControllerTransform.position;
        Vector3 battleTextHolderTransformTmp = battleTextHolderTransform.position;

        otherButtonsTransformTmp.y -= 0.2f;
        playerControllerTransformTmp.y -= 0.2f;
        battleTextHolderTransformTmp.y -= 0.2f;

        yield return new WaitForSeconds(0.2f);
        otherButtonsTransform.position = otherButtonsTransformTmp;
        playerControllerTransform.position = playerControllerTransformTmp;
        battleTextHolderTransform.position = battleTextHolderTransformTmp;

        otherButtonsTransformTmp.y += 0.2f;
        playerControllerTransformTmp.y += 0.2f;
        battleTextHolderTransformTmp.y += 0.2f;

        yield return new WaitForSeconds(0.2f);
        otherButtonsTransform.position = otherButtonsTransformTmp;
        playerControllerTransform.position = playerControllerTransformTmp;
        battleTextHolderTransform.position = battleTextHolderTransformTmp;
    }
    public IEnumerator playerWinMotion(){
        yield return new WaitForSeconds(1);

    }
    public IEnumerator playerLoseMotion(){
        yield return new WaitForSeconds(1);

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
        yield return new WaitForSeconds(1f);
        enemy.enemyImage.color = invisible;
        yield return new WaitForSeconds(0.1f);
        enemy.enemyImage.color = normal;
        yield return new WaitForSeconds(0.1f);
        enemy.enemyImage.color = invisible;
        yield return new WaitForSeconds(0.1f);
        enemy.enemyImage.color = normal;
    }


    public IEnumerator wait(int seconds){
        battleStatus =BattleStatus.PLAYERMOTION; 
        yield return new WaitForSeconds(seconds);
    }

    public bool isEnemyAlive(){
        if(enemyNumber == 1){
            return enemy1Status.enemyCurrentHp > 0 ? true : false; 
        }
        else if(enemyNumber == 2){
            return enemy1Status.enemyCurrentHp > 0 || enemy2Status.enemyCurrentHp > 0 ? true : false;
        }
        else if(enemyNumber == 3){
            return enemy1Status.enemyCurrentHp > 0 || enemy2Status.enemyCurrentHp > 0 || enemy3Status.enemyCurrentHp > 0 ? true : false;
        }
        else return false;
    }
}
