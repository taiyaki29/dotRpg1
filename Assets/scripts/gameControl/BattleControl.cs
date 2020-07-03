using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleStatus { START, PLAYERTURN, ENEMYTURN, WIN, LOSE, NO_BATTLE }

public class BattleControl : MonoBehaviour
{
    public BattleStatus battleStatus;

    public GameObject battleTextHolder;
    Text battleText;

    public GameObject mainRpgcontrol;
    MainRpgController mainRpgcontroller;

    public GameObject player;
    MainPlayerStatus mainPlayerStatus;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    EnemyStatus enemy1Status;
    EnemyStatus enemy2Status;
    EnemyStatus enemy3Status;

    int enemyNumber;

    int stageNumber;

    public string actionAttack = "<color=#ffffffff>▶︎　攻撃\nスキル\n防御\n逃げる</color>";
    public string actionSkill = "<color=#ffffffff>攻撃\n▶︎　スキル\n防御\n逃げる</color>";
    public string actionDefend = "<color=#ffffffff>攻撃\nスキル\n▶︎　防御\n逃げる</color>";
    public string actionFlee = "<color=#ffffffff>攻撃\nスキル\n防御\n▶︎　逃げる</color>";

    public string[] playerActions = new string[4]; 
    public int actionNumber = 0;
    
    void Start(){
        playerActions[0] = actionAttack;
        playerActions[1] = actionSkill;
        playerActions[2] = actionDefend;
        playerActions[3] = actionFlee;

        battleStatus = BattleStatus.NO_BATTLE;
        Debug.Log("battle start");
        
        mainRpgcontroller = mainRpgcontrol.GetComponent<MainRpgController>();
        mainPlayerStatus = player.GetComponent<MainPlayerStatus>();
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

    public IEnumerator chooseAction(){
        yield return new WaitForSeconds(2f);
        battleText.text = playerActions[0];
        battleStatus = BattleStatus.PLAYERTURN;
    }

    public IEnumerator wait(int seconds){
        yield return new WaitForSeconds(seconds);
    }
}
