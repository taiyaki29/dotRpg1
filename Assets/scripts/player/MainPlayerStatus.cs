using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPlayerStatus : MonoBehaviour
{
    public GameObject NameStatus;
    public GameObject HpStatus;
    public GameObject MpStatus;
    public GameObject LvStatus;
    public GameObject GoldStatus;
    public GameObject StepsLimit;
    public GameObject Skills;

    Skills skills;

    public string playerName = "テスト勇者";
    　
    public int playerLevel = 1;
    public int playerExperience = 0;

    public int playerGold = 0;

    public int playerStepsLimit = 200;

    public int playerMaxHp = 20;
    public int playerCurrentHp = 20;
    public int playerMaxMp = 20;
    public int playerCurrentMp = 20;

    public int playerPhysicalDefense = 10;
    public int playerMagicalDefense = 10;

    public int playerPhysicalAttack = 10;
    public int playerMagicalAttack = 10;

    public int playerSpeed = 10;

    public int playerCriticalChance = 10;
    public int playerCriticalDamage = 10;

    public string playerArmourHead = "null";
    public string playerArmourBody = "null";
    public string playerArmourHand = "null";
    public string playerArmourFeet = "null";

    public string playerNecklace = "null";
    public string playerWristband = "null";

    public string playerWeapon = "null";

    public int[] playerSkills = new int[] {-1, -1, -1, -1, -1, -1};
    public int playerSkillCount = 0;

    Text NameStatusText;
    Text HpStatusText;
    Text MpStatusText;
    Text LvStatusText;
    Text GoldStatusText;
    Text StepsLimitText;

    PlayerMovement playerMovement;

    void Start() {
        NameStatusText = NameStatus.GetComponent<Text>();
        HpStatusText = HpStatus.GetComponent<Text>();
        MpStatusText = MpStatus.GetComponent<Text>();
        LvStatusText = LvStatus.GetComponent<Text>();
        GoldStatusText = GoldStatus.GetComponent<Text>();
        StepsLimitText = StepsLimit.GetComponent<Text>();
        skills = Skills.GetComponent<Skills>();

        NameStatusText.text = "<color=#ffffffff>" + playerName + "</color>";
        HpStatusText.text = "<color=#00ff00ff>HP: " + playerCurrentHp.ToString() +"</color>";
        MpStatusText.text = "<color=#00ffffff>MP: " + playerCurrentMp.ToString() + "</color>";
        LvStatusText.text = "<color=#ffffffff>Lv: " + playerLevel.ToString() + "</color>";
        GoldStatusText.text = "<color=#ffff00ff>" + playerGold.ToString() + " G</color>";
        StepsLimitText.text = "<color=#fffffff>魔王が来るまで...\n" + "<size=80>" + playerStepsLimit.ToString() + "</size>" + "歩</color>";

        playerMovement = this.GetComponent<PlayerMovement>();
        Debug.Log("start");

        // temporary
        playerSkills[0] = 0;
        playerSkills[1] = 1;
        playerSkills[2] = 2;
        playerSkillCount++;
        playerSkillCount++;
        playerSkillCount++;
    }

    void FixedUpdate(){
        NameStatusText.text = "<color=#ffffffff>" + playerName + "</color>";
        HpStatusText.text = "<color=#00ff00ff>HP: " + playerCurrentHp.ToString() +"</color>";
        MpStatusText.text = "<color=#00ffffff>MP: " + playerCurrentMp.ToString() + "</color>";
        LvStatusText.text = "<color=#ffffffff>Lv: " + playerLevel.ToString() + "</color>";
        GoldStatusText.text = "<color=#ffff00ff>" + playerGold.ToString() + " G</color>";

        playerStepsLimit = playerMovement.playerStepsLimit;
        StepsLimitText.text = "<color=#fffffff>魔王が来るまで...\n" + "<size=80>" + playerStepsLimit.ToString()+ "</size>" + "歩</color>";
    }

}
