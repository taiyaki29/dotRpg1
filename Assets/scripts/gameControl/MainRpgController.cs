using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MainRpgStatus { START, WALK, BATTLE, BOSS, SHOP, MENU }

public class MainRpgController : MonoBehaviour
{
    
    public MainRpgStatus mainRpgStatus;
    public GameObject battleScreen;
    public GameObject battleController;
    public GameObject player;

    PlayerMovement playerMovement;
    BattleControl battleControl;

    int playerStepsLimit = 0;
    public int enemyEncounterSteps = 9;

    public int stageNumber =1;

    void Start(){
        mainRpgStatus = MainRpgStatus.WALK;
        battleScreen.SetActive(false);

        playerMovement = player.GetComponent<PlayerMovement>();
        playerStepsLimit = playerMovement.playerStepsLimit;

        battleControl = battleController.GetComponent<BattleControl>();

    }

    void Update(){
        
    }

    void FixedUpdate(){
        playerStepsLimit = playerMovement.playerStepsLimit;
        if(mainRpgStatus != MainRpgStatus.BATTLE && playerStepsLimit % enemyEncounterSteps == 0) startBattle();
    }

    public void startBattle(){
        // playerMovement.setPlayerStepCountToZero();
        Debug.Log("start battle");
        Debug.Log(playerStepsLimit);
        Debug.Log(enemyEncounterSteps);
        mainRpgStatus = MainRpgStatus.BATTLE;
        battleControl.setUpBattle();
        battleScreen.SetActive(true);
    }
}
