using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public RpgMenuStatus rpgMenuStatus;
    public GameObject rpgMenuTextholder;
    public Text rpgMenuText;

    public GameObject mainRpgControl;
    public MainRpgController mainRpgController;

    public GameObject player;
    public MainPlayerStatus mainPlayerStatus;

    public GameObject battleControlGameObject;
    public BattleControl battleController;

    public GameObject extraInfoTextHolder;
    public GameObject extraInfoTextGameObject;
    public Text extraInfoText;

    void Start()
    {
        rpgMenuText = rpgMenuTextholder.GetComponent<Text>();
        mainRpgController = mainRpgControl.GetComponent<MainRpgController>();
        mainPlayerStatus = player.GetComponent<MainPlayerStatus>();
        extraInfoText = extraInfoTextGameObject.GetComponent<Text>();
        battleController = battleControlGameObject.GetComponent<BattleControl>();
        extraInfoTextHolder.SetActive(true);
    }

    void Update()
    {
        
    }
}
