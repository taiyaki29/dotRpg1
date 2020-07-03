using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleStatus { START, PLAYERTURN, ENEMYTURN, WIN, LOSE, NO_BATTLE }

public class BattleControl : MonoBehaviour
{
    public BattleStatus battleStatus;

    public GameObject battleTextHolder;
    Text batleText;

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
    
    void Start(){
        battleStatus = BattleStatus.NO_BATTLE;
        Debug.Log("battle start");
        
        mainRpgcontroller = mainRpgcontrol.GetComponent<MainRpgController>();
        mainPlayerStatus = player.GetComponent<MainPlayerStatus>();
        batleText = battleTextHolder.GetComponent<Text>();
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
    }

    public void setUpBattle(){
        enemyNumber = UnityEngine.Random.Range(1,4);
        if(enemyNumber == 1){
            enemy1Status.spawnEnemy(stageNumber);
            enemy1.SetActive(true);
            enemy2.SetActive(false);
            enemy3.SetActive(false);
            // enemy1Status
            batleText.text = "<color=#ffffffff>" + enemy1Status.enemyName + "が襲いかかってきた。"+ "</color>";
        }
        else if(enemyNumber == 2){
            enemy1.SetActive(true);
            enemy2.SetActive(true);
            enemy3.SetActive(false);
            if(enemy1Status.enemyName != enemy2Status.enemyName){
                batleText.text = "<color=#ffffffff>" + enemy1Status.enemyName + "と\n" + enemy2Status.enemyName + "が襲いかかってきた。"+ "</color>";
            }
            else {
                batleText.text = "<color=#ffffffff>" + enemy1Status.enemyName + "達が襲いかかってきた。"+ "</color>";
            }
        }
        else if(enemyNumber == 3){
            enemy1.SetActive(true);
            enemy2.SetActive(true);
            enemy3.SetActive(true);
            if(enemy1Status.enemyName != enemy2Status.enemyName && enemy2Status.enemyName != enemy3Status.enemyName){
                batleText.text = "<color=#ffffffff>" + enemy1Status.enemyName + "と\n" + enemy2Status.enemyName + "と\n" + enemy3Status.enemyName + "が襲いかかってきた。"+ "</color>";
            }
            else if(enemy1Status.enemyName == enemy2Status.enemyName){

            }
        }
        Debug.Log(enemyNumber);
        Debug.Log("battle set up");
    }
}
