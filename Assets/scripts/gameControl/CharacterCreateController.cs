using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreateController : MonoBehaviour
{
    public GameObject player;

    public void SavePlayer(){
        MainPlayerStatus mainPlayerStatus = player.GetComponent<MainPlayerStatus>();
        PlayerMovement playerPosition = player.GetComponent<PlayerMovement>();
        SaveSystem.SavePlayer(mainPlayerStatus, playerPosition);
    }

    public void LoadPlayer(){
        MainPlayerData data = SaveSystem.LoadPlayer();
        // MainPlayerStatus player = new MainPlayerStatus();
        // PlayerMovement playerPosition = new PlayerMovement();
        MainPlayerStatus mainPlayerStatus = player.GetComponent<MainPlayerStatus>();
        PlayerMovement playerPosition = player.GetComponent<PlayerMovement>();

        mainPlayerStatus.playerName = data.playerName;
        
        mainPlayerStatus.playerLevel = data.playerLevel;
        mainPlayerStatus.playerExperience = data.playerExperience;
        mainPlayerStatus.playerStatusPoints = data.playerStatusPoints;
        
        mainPlayerStatus.playerGold = data.playerGold;

        playerPosition.playerStepsLimit = data.playerStepsLimit;

        mainPlayerStatus.playerMaxHp = data.playerMaxHp;
        mainPlayerStatus.playerCurrentHp = data.playerCurrentHp;
        mainPlayerStatus.playerMaxMp = data.playerMaxMp;
        mainPlayerStatus.playerCurrentMp = data.playerCurrentMp;

        mainPlayerStatus.playerPhysicalDefense = data.playerPhysicalDefense;
        mainPlayerStatus.playerMagicalDefense = data.playerMagicalDefense;

        mainPlayerStatus.playerPhysicalAttack = data.playerPhysicalAttack;
        mainPlayerStatus.playerMagicalAttack = data.playerMagicalAttack;

        mainPlayerStatus.playerSpeed = data.playerSpeed;

        mainPlayerStatus.playerCriticalDamage = data.playerCriticalDamage;
        mainPlayerStatus.playerCriticalChance = data.playerCriticalChance;

        mainPlayerStatus.playerArmourHead = data.playerArmourHead;
        mainPlayerStatus.playerArmourBody = data.playerArmourBody;
        mainPlayerStatus.playerArmourHand = data.playerArmourHand;
        mainPlayerStatus.playerArmourFeet = data.playerArmourFeet;

        mainPlayerStatus.playerNecklace = data.playerNecklace;
        mainPlayerStatus.playerWristband = data.playerWristband;

        mainPlayerStatus.playerWeapon = data.playerWeapon;

        for(int i=0; i<6; i++){
            mainPlayerStatus.playerSkills[i] = data.playerSkills[i];
        }

        Vector3 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];
        position.z = data.playerPosition[2];

        playerPosition.playerPosition.position = position;
    }
}
