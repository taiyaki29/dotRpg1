using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ShopControllerStatus { OPEN, BUY_WEAPON, BUY_ARMOUR, BUY_ITEM, SELL, CLOSE }

public class ShopController : MonoBehaviour
{
    public ShopControllerStatus shopControllerStatus;
    public GameObject shopMenuTextholder;
    public Text shopMenuText;

    public GameObject mainRpgControl;
    public MainRpgController mainRpgController;

    public GameObject player;
    public MainPlayerStatus mainPlayerStatus;

    public GameObject battleControlGameObject;
    public BattleControl battleController;

    public GameObject extraInfoTextHolder;
    public GameObject extraInfoTextGameObject;
    public Text extraInfoText;

    public string[] menuAction = new string[12];
    public string[] extraMenuInfo = new string[11];
    public int mainActionNumber = 0;

    void Start() {
        shopMenuText = shopMenuTextholder.GetComponent<Text>();
        mainRpgController = mainRpgControl.GetComponent<MainRpgController>();
        mainPlayerStatus = player.GetComponent<MainPlayerStatus>();
        extraInfoText = extraInfoTextGameObject.GetComponent<Text>();
        battleController = battleControlGameObject.GetComponent<BattleControl>();
        extraInfoTextHolder.SetActive(true);
    }

    void Update() {
        if(shopControllerStatus == ShopControllerStatus.OPEN) {
            shopMenuText.text = menuAction[mainActionNumber];
        }
    }

    public void setShopMainText() {
        for(int i=0; i<5; i++) {
            menuAction[i] = "<color=#ffffffff>";
            if(i == 0) menuAction[i] += "▶︎";
            menuAction[i] += "武器を買う";
            if(i == 1) menuAction[i] += "▶︎";
            menuAction[i] += "\n防具を買う";
            if(i == 2) menuAction[i] += "▶︎";
            menuAction[i] += "\nアイテムを買う";
            if(i == 3) menuAction[i] += "▶︎";
            menuAction[i] += "\n所持品を売る";
            if(i == 4) menuAction[i] += "▶︎";
            menuAction[i] += "\n店を出る";
            menuAction[i] = "</color>";
        }
    }

    public void openShop() {
        shopControllerStatus = ShopControllerStatus.OPEN;
        setShopMainText();
    }
}
