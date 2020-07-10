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
    public int enemyEncounterSteps = 0;

    public int stageNumber = 1;

    public float gameTextSpeed = 0.7f;

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
        if(mainRpgStatus != MainRpgStatus.BATTLE &&  enemyEncounterSteps == 9) {
            playerMovement.holdMoveUp = false;
            playerMovement.holdMoveDown = false;
            playerMovement.holdMoveLeft = false;
            playerMovement.holdMoveRight = false;
            playerMovement.walkingAnimator.SetBool("moving", false);
            playerMovement.walkingAnimator.SetBool("lookDown", true);
            startBattle();
            enemyEncounterSteps = 0;
        }
    }

    public void startBattle(){
        // playerMovement.setPlayerStepCountToZero();
        mainRpgStatus = MainRpgStatus.BATTLE;
        battleScreen.SetActive(true);
        battleControl.startBattle();
    }

    public void endBattle(){
        // playerMovement.setPlayerStepCountToZero();
        mainRpgStatus = MainRpgStatus.WALK;
        battleScreen.SetActive(false);
    }
}
