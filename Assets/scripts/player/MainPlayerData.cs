using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class MainPlayerData {
    public string playerName = "テスト勇者";
    　
    public int playerLevel;
    public int playerExperience;

    public int playerGold;

    public int playerStepsLimit;

    public int playerMaxHp;
    public int playerCurrentHp;
    public int playerMaxMp;
    public int playerCurrentMp;

    public int playerPhysicalDefense;
    public int playerMagicalDefense;

    public int playerPhysicalAttack;
    public int playerMagicalAttack;

    public int playerSpeed;

    public int playerCriticalChance;
    public int playerCriticalDamage;

    public string playerArmourHead;
    public string playerArmourBody;
    public string playerArmourHand;
    public string playerArmourFeet;

    public string playerNecklace;
    public string playerWristband;

    public string playerWeapon;

    public Skills playerSkill1;
    public Skills playerSkill2;
    public Skills playerSkill3;
    public Skills playerSkill4;
    public Skills playerSkill5;
    public Skills playerSkill6;

    public float[] playerPosition;

    public MainPlayerData (MainPlayerStatus mainPlayerStatus, PlayerMovement playerMovement) {
        playerName = mainPlayerStatus.playerName;
        
        playerLevel = mainPlayerStatus.playerLevel;
        playerExperience = mainPlayerStatus.playerExperience;
        
        playerGold = mainPlayerStatus.playerGold;

        playerStepsLimit = playerMovement.playerStepsLimit;

        playerMaxHp = mainPlayerStatus.playerMaxHp;
        playerCurrentHp = mainPlayerStatus.playerCurrentHp;
        playerMaxMp = mainPlayerStatus.playerMaxMp;
        playerCurrentMp = mainPlayerStatus.playerCurrentMp;

        playerPhysicalDefense = mainPlayerStatus.playerPhysicalDefense;
        playerMagicalDefense = mainPlayerStatus.playerMagicalDefense;

        playerPhysicalAttack = mainPlayerStatus.playerPhysicalAttack;
        playerMagicalAttack = mainPlayerStatus.playerMagicalAttack;

        playerSpeed = mainPlayerStatus.playerSpeed;

        playerCriticalDamage = mainPlayerStatus.playerCriticalDamage;
        playerCriticalChance = mainPlayerStatus.playerCriticalChance;

        playerArmourHead = mainPlayerStatus.playerArmourHead;
        playerArmourBody = mainPlayerStatus.playerArmourBody;
        playerArmourHand = mainPlayerStatus.playerArmourHand;
        playerArmourFeet = mainPlayerStatus.playerArmourFeet;

        playerNecklace = mainPlayerStatus.playerNecklace;
        playerWristband = mainPlayerStatus.playerWristband;

        playerWeapon = mainPlayerStatus.playerWeapon;

        playerSkill1 = mainPlayerStatus.playerSkill1;
        playerSkill2 = mainPlayerStatus.playerSkill2;
        playerSkill3 = mainPlayerStatus.playerSkill3;
        playerSkill4 = mainPlayerStatus.playerSkill4;
        playerSkill5 = mainPlayerStatus.playerSkill5;
        playerSkill6 = mainPlayerStatus.playerSkill6;

        playerPosition = new float[3];
        playerPosition[0] = playerMovement.playerPosition.position.x;
        playerPosition[1] = playerMovement.playerPosition.position.y;
        playerPosition[2] = playerMovement.playerPosition.position.z;
    }
}
