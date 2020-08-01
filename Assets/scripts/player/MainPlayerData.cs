﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class MainPlayerData {
    public string playerName = "テスト勇者";
    　
    public int playerLevel;
    public int playerExperience;
    public int playerStatusPoints;

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

    public int playerWeaponNumber;

    public int playerArmourHeadNumber;
    public int playerArmourBodyNumber;
    public int playerArmourFeetNumber;
    public int playerArmourHandNumber;
    public int playerNecklaceNumber;
    public int playerWristbandNumber;

    public int[] playerSkillsNumber = new int[6];

    public float[] playerPosition;

    public MainPlayerData (MainPlayerStatus mainPlayerStatus, PlayerMovement playerMovement) {
        playerName = mainPlayerStatus.playerName;
        
        playerLevel = mainPlayerStatus.playerLevel;
        playerExperience = mainPlayerStatus.playerExperience;
        playerStatusPoints = mainPlayerStatus.playerStatusPoints;
        
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

        playerArmourHeadNumber = mainPlayerStatus.playerArmourHeadNumber;
        playerArmourBodyNumber = mainPlayerStatus.playerArmourBodyNumber;
        playerArmourHandNumber = mainPlayerStatus.playerArmourHandNumber;
        playerArmourFeetNumber = mainPlayerStatus.playerArmourFeetNumber;
        playerNecklaceNumber = mainPlayerStatus.playerNecklaceNumber;
        playerWristbandNumber = mainPlayerStatus.playerWristbandNumber;

        playerWeaponNumber = mainPlayerStatus.playerWeaponNumber;

        for(int i=0; i<6; i++) {
            playerSkillsNumber[i] = mainPlayerStatus.playerSkillsNumber[i];
        }

        playerPosition = new float[3];
        playerPosition[0] = playerMovement.playerPosition.position.x;
        playerPosition[1] = playerMovement.playerPosition.position.y;
        playerPosition[2] = playerMovement.playerPosition.position.z;
    }
}
