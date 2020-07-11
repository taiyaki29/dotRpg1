using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum RpgMenuStatus { OPEN, OPENITEM, OPENSTATUS, OPENSKILL, OPENARMOUR, OPENSETTINGS, GOTBACKTOHOME, CLOSED }

public class RpgMenuController : MonoBehaviour
{
    public RpgMenuStatus rpgMenuStatus;
    public GameObject rpgMenuTextholder;
    public Text rpgMenuText;

    public GameObject mainRpgControl;
    public MainRpgController mainRpgController;

    public string[] menuAction = new string[7];
    public int mainActionNumber = 0;
    public int itemActionNumber = 0;
    public int statusActionNumber = 0;
    public int skillActionNumber = 0;
    public int armourActionNumber = 0;
    public int settingsActionNumber = 0;


    void Start(){
        rpgMenuText = rpgMenuTextholder.GetComponent<Text>();
        mainRpgController = mainRpgControl.GetComponent<MainRpgController>();
    }

    void Update(){
        if(rpgMenuStatus == RpgMenuStatus.OPEN){
            rpgMenuText.text = menuAction[mainActionNumber];
        }
        else if(rpgMenuStatus == RpgMenuStatus.OPENITEM){

        }
        else if(rpgMenuStatus == RpgMenuStatus.OPENSTATUS){
            
        }
        else if(rpgMenuStatus == RpgMenuStatus.OPENSKILL){
            
        }
        else if(rpgMenuStatus == RpgMenuStatus.OPENARMOUR){
            
        }
        else if(rpgMenuStatus == RpgMenuStatus.OPENSETTINGS){
            
        }
        else if(rpgMenuStatus == RpgMenuStatus.GOTBACKTOHOME){
            
        }
    }

    public void openMenu(){
        setMenuText();
        rpgMenuStatus = RpgMenuStatus.OPEN;
    }

    public void setMenuText(){Debug.Log("set");
        mainActionNumber = 0;
        menuAction[0] = "<color=#ffffffff>▶︎アイテム\nステータス\nスキル\n装備\n設定\nメインメニューに戻る</color>";
        menuAction[1] = "<color=#ffffffff>アイテム\n▶︎ステータス\nスキル\n装備\n設定\nメインメニューに戻る</color>";
        menuAction[2] = "<color=#ffffffff>アイテム\nステータス\n▶︎スキル\n装備\n設定\nメインメニューに戻る</color>";
        menuAction[3] = "<color=#ffffffff>アイテム\nステータス\nスキル\n▶︎装備\n設定\nメインメニューに戻る</color>";
        menuAction[4] = "<color=#ffffffff>アイテム\nステータス\nスキル\n装備\n▶︎設定\nメインメニューに戻る</color>";
        menuAction[5] = "<color=#ffffffff>アイテム\nステータス\nスキル\n装備\n設定\n▶︎メインメニューに戻る</color>";
    }

    public void openItem(){
        rpgMenuStatus = RpgMenuStatus.OPENITEM;
    }
    public void openStatus(){
        rpgMenuStatus = RpgMenuStatus.OPENSTATUS;
    }
    public void openSkill(){
        rpgMenuStatus = RpgMenuStatus.OPENSKILL;
    }
    public void openArmour(){
        rpgMenuStatus = RpgMenuStatus.OPENARMOUR;
    }
    public void openSettings(){
        rpgMenuStatus = RpgMenuStatus.OPENSETTINGS;
    }
    public void goBackToHome(){
        rpgMenuStatus = RpgMenuStatus.GOTBACKTOHOME;
    }
    public void goBack(){
        if(rpgMenuStatus == RpgMenuStatus.OPEN){
            mainRpgController.closeMenu();
        }
        else rpgMenuStatus = RpgMenuStatus.OPEN;
    }
    
}
