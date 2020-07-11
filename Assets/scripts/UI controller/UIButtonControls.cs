using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonControls : MonoBehaviour
{
    public GameObject mainRpgControl;
    MainRpgController mainRpgController;

    public GameObject battleControl;
    BattleControl battleController;

    public GameObject rpgMenuControl;
    RpgMenuController rpgMenuController;

    public GameObject BButton;
    Text bButtonText;

    void Start()
    {
        mainRpgController = mainRpgControl.GetComponent<MainRpgController>();
        battleController = battleControl.GetComponent<BattleControl>();
        bButtonText = BButton.GetComponent<Text>();
        rpgMenuController = rpgMenuControl.GetComponent<RpgMenuController>();
    }

    void Update(){

    }

    void FixedUpdate()
    {
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){
            bButtonText.text = "<b>メニュー</b>";
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BATTLE){
            bButtonText.text = "<b>戻る</b>";
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BOSS){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.SHOP){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.MENU){
            bButtonText.text = "<b>戻る</b>";
        }
    }

    public void A_Button(){
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){

        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BATTLE){
            if(battleController.battleStatus == BattleStatus.PLAYERTURN){
                battleController.chooseAction();
            }
            else if(battleController.battleStatus == BattleStatus.PLAYERTURNSKILL){
                battleController.chooseSkill();
            }
            else if(battleController.battleStatus == BattleStatus.CHOOSENEWSKILL){
                battleController.tradeNewSkill();
            }
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BOSS){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.SHOP){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.MENU){
            if(rpgMenuController.rpgMenuStatus == RpgMenuStatus.OPEN){
                
            }
            else if(rpgMenuController.rpgMenuStatus == RpgMenuStatus.OPENITEM){

            } 
            else if(rpgMenuController.rpgMenuStatus == RpgMenuStatus.OPENSTATUS){

            } 
            else if(rpgMenuController.rpgMenuStatus == RpgMenuStatus.OPENSKILL){

            } 
            else if(rpgMenuController.rpgMenuStatus == RpgMenuStatus.OPENARMOUR){

            } 
            else if(rpgMenuController.rpgMenuStatus == RpgMenuStatus.OPENSETTINGS){

            }
        }
    }

    public void B_Button(){
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){
            mainRpgController.openMenu();
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BATTLE){
            if(battleController.battleStatus == BattleStatus.PLAYERTURNSKILL){
                battleController.returnToChooseAction();
            }
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BOSS){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.SHOP){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.MENU){
            if(rpgMenuController.rpgMenuStatus == RpgMenuStatus.OPEN){
                mainRpgController.closeMenu();
            }
            else if(rpgMenuController.rpgMenuStatus == RpgMenuStatus.OPENITEM){
                
            } 
            else if(rpgMenuController.rpgMenuStatus == RpgMenuStatus.OPENSTATUS){

            } 
            else if(rpgMenuController.rpgMenuStatus == RpgMenuStatus.OPENSKILL){

            } 
            else if(rpgMenuController.rpgMenuStatus == RpgMenuStatus.OPENARMOUR){

            } 
            else if(rpgMenuController.rpgMenuStatus == RpgMenuStatus.OPENSETTINGS){

            }
        }
    }

    // TEMPLATE //
    public void template(){
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){

        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BATTLE){

        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BOSS){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.SHOP){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.MENU){
            
        }
    }
    // TEMPLATE //
}
