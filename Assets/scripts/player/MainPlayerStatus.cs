﻿using System.Collections;
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

    public GameObject playerSkill1GameObject;
    public GameObject playerSkill2GameObject;
    public GameObject playerSkill3GameObject;
    public GameObject playerSkill4GameObject;
    public GameObject playerSkill5GameObject;
    public GameObject playerSkill6GameObject;

    public Skills playerSkill1;
    public Skills playerSkill2;
    public Skills playerSkill3;
    public Skills playerSkill4;
    public Skills playerSkill5;
    public Skills playerSkill6;

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

    public int playerPhysicalDefense = 5;
    public int playerMagicalDefense = 5;

    public int playerPhysicalAttack = 5;
    public int playerMagicalAttack = 5;

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

    // public int[] playerSkills = new int[] {-1, -1, -1, -1, -1, -1};
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

        playerSkill1 = playerSkill1GameObject.GetComponent<Skills>();
        playerSkill2 = playerSkill2GameObject.GetComponent<Skills>();
        playerSkill3 = playerSkill3GameObject.GetComponent<Skills>();
        playerSkill4 = playerSkill4GameObject.GetComponent<Skills>();
        playerSkill5 = playerSkill5GameObject.GetComponent<Skills>();
        playerSkill6 = playerSkill6GameObject.GetComponent<Skills>();

        NameStatusText.text = "<color=#ffffffff>" + playerName + "</color>";
        HpStatusText.text = "<color=#00ff00ff>HP: " + playerCurrentHp.ToString() +"</color>";
        MpStatusText.text = "<color=#00ffffff>MP: " + playerCurrentMp.ToString() + "</color>";
        LvStatusText.text = "<color=#ffffffff>Lv: " + playerLevel.ToString() + "</color>";
        GoldStatusText.text = "<color=#ffff00ff>" + playerGold.ToString() + " G</color>";
        StepsLimitText.text = "<color=#fffffff>魔王が来るまで...\n" + "<size=80>" + playerStepsLimit.ToString() + "</size>" + "歩</color>";

        playerMovement = this.GetComponent<PlayerMovement>();
        Debug.Log("start");

        // temporary
        playerSkill1.setSkill(0);
        playerSkill2.setSkill(1);
        playerSkill3.setSkill(2);
        playerSkill4.setSkill(3);
        playerSkillCount++;
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
