using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum BattleStatus { START, PLAYERTURN, PLAYERTURNSKILL, PLAYERMOTION, ENEMYTURN, WIN, LOSE, NO_BATTLE }

public class BattleControl : MonoBehaviour
{
    public BattleStatus battleStatus;

    public GameObject battleTextHolder;
    Text battleText;

    public GameObject mainRpgcontrol;
    MainRpgController mainRpgcontroller;

    public GameObject player;
    MainPlayerStatus mainPlayerStatus;

    public GameObject skill;
    Skills skills;
    Skills useSkill;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

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
    
    void Start(){
        setChooseAtionText();

        battleStatus = BattleStatus.NO_BATTLE;
        Debug.Log("battle start");
        
        mainRpgcontroller = mainRpgcontrol.GetComponent<MainRpgController>();
        mainPlayerStatus = player.GetComponent<MainPlayerStatus>();
        skills = skill.GetComponent<Skills>();

        battleText = battleTextHolder.GetComponent<Text>();
        enemy1Status = enemy1.GetComponent<EnemyStatus>();
        enemy2Status = enemy2.GetComponent<EnemyStatus>();
        enemy3Status = enemy3.GetComponent<EnemyStatus>();

        stageNumber = mainRpgcontroller.stageNumber;
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
    }

    public void startBattle(){
        StartCoroutine(setUpBattle());
    }

    public IEnumerator setUpBattle(){
        enemyNumber = UnityEngine.Random.Range(1,4);
        if(enemyNumber == 1){
            enemy1Status.spawnEnemy(stageNumber);

            enemy1.SetActive(true);
            enemy2.SetActive(false);
            enemy3.SetActive(false);

            battleText.text = "<color=#ffffffff>" + enemy1Status.enemyName + "が襲いかかってきた。"+ "</color>";
        }
        else if(enemyNumber == 2){
            enemy1Status.spawnEnemy(stageNumber);
            enemy2Status.spawnEnemy(stageNumber);

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
        yield return new WaitForSeconds(2f);
        battleText.text = playerActions[0];
        battleStatus = BattleStatus.PLAYERTURN;
        Debug.Log("end wait");
    }

    public void chooseAction(){Debug.Log(actionNumber);
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
        battleStatus =BattleStatus.PLAYERMOTION; 
        yield return new WaitForSeconds(seconds);
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

    public IEnumerator wait(int seconds){
        battleStatus =BattleStatus.PLAYERMOTION; 
        yield return new WaitForSeconds(seconds);
    }

    // on click enemy
    
}
