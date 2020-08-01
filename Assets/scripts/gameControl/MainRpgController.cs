using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public enum MainRpgStatus { START, WALK, BATTLE, BOSS, SHOP, MENU }

public class MainRpgController : MonoBehaviour
{
    
    public MainRpgStatus mainRpgStatus;
    public GameObject battleScreen;
    public GameObject rpgMenuScreen;
    public GameObject rpgMenuControl;
    public GameObject shopControllerGameObject;
    public GameObject battleController;
    public GameObject player;

    public Sprite shopSprite;

    public GameObject exclamationPoint;

    PlayerMovement playerMovement;
    BattleControl battleControl;

    RpgMenuController rpgMenuController;
    MainPlayerStatus mainPlayerStatus;
    ShopController shopController;

    public Tilemap tilemap;

    int playerStepsLimit = 0;
    public int enemyEncounterSteps = 0;

    public int stageNumber = 1;

    public float gameTextSpeed = 0.7f;

    void Start() {
        mainRpgStatus = MainRpgStatus.WALK;
        battleScreen.SetActive(false);
        rpgMenuScreen.SetActive(false);

        playerMovement = player.GetComponent<PlayerMovement>();
        playerStepsLimit = playerMovement.playerStepsLimit;

        battleControl = battleController.GetComponent<BattleControl>();
        rpgMenuController = rpgMenuControl.GetComponent<RpgMenuController>();
        mainPlayerStatus = player.GetComponent<MainPlayerStatus>();
        shopController = shopControllerGameObject.GetComponent<ShopController>();

        if(mainRpgStatus == MainRpgStatus.WALK && mainPlayerStatus.playerStatusPoints > 0) exclamationPoint.SetActive(true);
        else exclamationPoint.SetActive(false);
    }

    void Update() {
        
    }

    void FixedUpdate() {
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
        if(mainRpgStatus == MainRpgStatus.WALK && !exclamationPoint.active && mainPlayerStatus.playerStatusPoints > 0) {
            exclamationPoint.SetActive(true);
        }
        else if(mainRpgStatus != MainRpgStatus.WALK) exclamationPoint.SetActive(false);

        checkTile();
    }

    public void startBattle() {
        mainRpgStatus = MainRpgStatus.BATTLE;
        battleScreen.SetActive(true);
        battleControl.startBattle();
    }

    public void endBattle() {
        mainRpgStatus = MainRpgStatus.WALK;
        battleScreen.SetActive(false);
    }

    public void openMenu() {
        mainRpgStatus = MainRpgStatus.MENU;
        rpgMenuScreen.SetActive(true);
        rpgMenuController.openMenu();
    }

    public void closeMenu() {
        mainRpgStatus = MainRpgStatus.WALK;
        rpgMenuScreen.SetActive(false);
    }

    public void openShop() {
        mainRpgStatus = MainRpgStatus.SHOP;
        shopController.openShop();
        rpgMenuScreen.SetActive(true);
    }

    public void checkTile() {
        Vector3Int position = new Vector3Int((int)playerMovement.playerPos.x+1, (int)playerMovement.playerPos.y-1, 0);
        var tile = tilemap.GetTile<Tile>(position);
        Debug.Log(tile.sprite);
        if(tile.sprite == shopSprite) {
            enemyEncounterSteps = 0;
            openShop();
        }
    }
}
