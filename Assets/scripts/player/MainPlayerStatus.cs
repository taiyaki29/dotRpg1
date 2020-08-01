using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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

    public Skills[] playerSkills = new Skills[6];
    public int[] playerSkillsNumber = new int[6];

    public GameObject playerWeaponGameObject;
    public Weapon playerWeapon;
    public int playerWeaponNumber = 0;

    public GameObject playerArmourHeadGameObject;
    public GameObject playerArmourBodyGameObject;
    public GameObject playerArmourFeetGameObject;
    public GameObject playerArmourHandGameObject;
    public GameObject playerNecklaceGameObject;
    public GameObject playerWristbandGameObject;

    public Armour playerArmourHead;
    public Armour playerArmourBody;
    public Armour playerArmourFeet;
    public Armour playerArmourHand;
    public Armour playerNecklace;
    public Armour playerWristband;

    public int playerArmourHeadNumber = 0;
    public int playerArmourBodyNumber = 0;
    public int playerArmourFeetNumber = 0;
    public int playerArmourHandNumber = 0;
    public int playerNecklaceNumber = 0;
    public int playerWristbandNumber = 0;

    Skills skills;

    public string playerName = "テスト勇者";
    　
    public int playerLevel = 1;
    public int playerExperience = 0;
    public int playerStatusPoints = 0;

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

        playerSkills[0] = playerSkill1GameObject.GetComponent<Skills>();
        playerSkills[1] = playerSkill2GameObject.GetComponent<Skills>();
        playerSkills[2] = playerSkill3GameObject.GetComponent<Skills>();
        playerSkills[3] = playerSkill4GameObject.GetComponent<Skills>();
        playerSkills[4] = playerSkill5GameObject.GetComponent<Skills>();
        playerSkills[5] = playerSkill6GameObject.GetComponent<Skills>();

        playerArmourHead = playerArmourHeadGameObject.GetComponent<Armour>();
        playerArmourBody = playerArmourBodyGameObject.GetComponent<Armour>();
        playerArmourFeet = playerArmourFeetGameObject.GetComponent<Armour>();
        playerArmourHand = playerArmourHandGameObject.GetComponent<Armour>();
        playerNecklace = playerNecklaceGameObject.GetComponent<Armour>();
        playerWristband = playerWristbandGameObject.GetComponent<Armour>();

        playerWeapon = playerWeaponGameObject.GetComponent<Weapon>();

        NameStatusText.text = "<color=#ffffffff>" + playerName + "</color>";
        HpStatusText.text = "<color=#00ff00ff>HP: " + playerCurrentHp.ToString() +"</color>";
        MpStatusText.text = "<color=#00ffffff>MP: " + playerCurrentMp.ToString() + "</color>";
        LvStatusText.text = "<color=#ffffffff>Lv: " + playerLevel.ToString() + "</color>";
        GoldStatusText.text = "<color=#ffff00ff>" + playerGold.ToString() + " G</color>";
        StepsLimitText.text = "<color=#fffffff>魔王が来るまで...\n" + "<size=80>" + playerStepsLimit.ToString() + "</size>" + "歩</color>";

        playerMovement = this.GetComponent<PlayerMovement>();
        Debug.Log("start");

        // temporary // 
        for(int i=0; i<6; i++) {
            playerSkills[i].setSkill(i);
            playerSkillCount++;
            playerSkillsNumber[i] = i;
            Debug.Log(playerSkills[i].skillName);
        }
        playerSkills[1].setSkill(8);
        playerArmourHead.setArmour(1,"head");
        playerArmourBody.setArmour(1,"body");
        playerArmourFeet.setArmour(1,"feet");
        playerArmourHand.setArmour(1,"hand");
        playerNecklace.setArmour(1,"necklace");
        playerWristband.setArmour(1,"wristband");

        playerWeapon.setWeapon(1);
        // playerSkills[0].setSkill(0);
        // playerSkillCount++;
    }

    void FixedUpdate() {
        NameStatusText.text = "<color=#ffffffff>" + playerName + "</color>";
        HpStatusText.text = "<color=#00ff00ff>HP: " + playerCurrentHp.ToString() +"</color>";
        MpStatusText.text = "<color=#00ffffff>MP: " + playerCurrentMp.ToString() + "</color>";
        LvStatusText.text = "<color=#ffffffff>Lv: " + playerLevel.ToString() + "</color>";
        GoldStatusText.text = "<color=#ffff00ff>" + playerGold.ToString() + " G</color>";

        playerStepsLimit = playerMovement.playerStepsLimit;
        StepsLimitText.text = "<color=#fffffff>魔王が来るまで...\n" + "<size=80>" + playerStepsLimit.ToString()+ "</size>" + "歩</color>";
    }

    public bool didPlayerLevelUp() {
        int potentialNewLevel = experienceLevelConversion();
        if(playerLevel < experienceLevelConversion()) {
            playerStatusPoints += 10 * (potentialNewLevel - playerLevel);
            playerLevel = potentialNewLevel;
            return true;
        }
        return false;
    }
    
    public int experienceLevelConversion() {
        int experience = 0;
        for(int i=1; i<100000; i++) {
            experience += i + 30 + (int)Math.Pow((double)i, 1.25);
            if(experience > playerExperience) return i;
            Debug.Log(experience);
        }
        return 9999999;
    }
    

}
