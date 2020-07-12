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

    public GameObject AButton;
    Text aButtonText;

    void Start()
    {
        mainRpgController = mainRpgControl.GetComponent<MainRpgController>();
        battleController = battleControl.GetComponent<BattleControl>();
        bButtonText = BButton.GetComponent<Text>();
        aButtonText = AButton.GetComponent<Text>();
        rpgMenuController = rpgMenuControl.GetComponent<RpgMenuController>();
    }

    void Update(){

    }

    void FixedUpdate()
    {
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){
            bButtonText.text = "<b>メニュー</b>";
            aButtonText.text = "";
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BATTLE){
            bButtonText.text = "<b>戻る</b>";
            aButtonText.text = "";
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BOSS){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.SHOP){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.MENU){
            if(rpgMenuController.rpgMenuStatus == RpgMenuStatus.OPEN) {
                bButtonText.text = "<b>戻る</b>";
                aButtonText.text = "";
            }
            else if(rpgMenuController.rpgMenuStatus == RpgMenuStatus.OPENSTATUS) {
                if(rpgMenuController.statusActionNumber == 10 || rpgMenuController.statusActionNumber == 9) {
                    bButtonText.text = "<b>戻る</b>";
                    aButtonText.text = "<b>決定</b>";
                }
                // else if(rpgMenuController.statusActionNumber == 11){
                //     bButtonText.text = "<b>戻る</b>";
                //     aButtonText.text = "<b>決定</b>";
                // }
                else {
                    bButtonText.text = "<b>下げる</b>";
                    aButtonText.text = "<b>上げる</b>";
                }
            }
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
                rpgMenuController.chooseAction();
            }
            else if(rpgMenuController.rpgMenuStatus == RpgMenuStatus.OPENITEM){

            } 
            else if(rpgMenuController.rpgMenuStatus == RpgMenuStatus.OPENSTATUS){
                rpgMenuController.chooseStatusAction(true);
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
                rpgMenuController.goBack();
            } 
            else if(rpgMenuController.rpgMenuStatus == RpgMenuStatus.OPENSTATUS){
                rpgMenuController.chooseStatusAction(false);
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
