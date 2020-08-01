﻿using System.Collections;
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
    public int itemActionNumber = 0;
    public int statusActionNumber = 0;
    public int skillActionNumber = 0;
    public int armourActionNumber = 0;
    public int settingsActionNumber = 0;

    public int statusPointsDiff = 0;
    public int maxHPDiff = 0;
    public int maxMPDiff = 0;
    public int physicalAttackDiff = 0;
    public int magicalAttackDiff = 0;
    public int physicalDefenseDiff = 0;
    public int magicalDefenseDiff = 0;
    public int criticalChanceDiff = 0;
    public int criticalDamageDiff = 0;
    public int speedDiff = 0; 


    void Start() {
        rpgMenuText = rpgMenuTextholder.GetComponent<Text>();
        mainRpgController = mainRpgControl.GetComponent<MainRpgController>();
        mainPlayerStatus = player.GetComponent<MainPlayerStatus>();
        extraInfoText = extraInfoTextGameObject.GetComponent<Text>();
        battleController = battleControlGameObject.GetComponent<BattleControl>();
        extraInfoTextHolder.SetActive(false);
    }

    void Update() {
        if(rpgMenuStatus == RpgMenuStatus.OPEN) {
            rpgMenuText.text = menuAction[mainActionNumber];
            extraInfoTextHolder.SetActive(false);
        }
        else if(rpgMenuStatus == RpgMenuStatus.OPENITEM) {

        }
        else if(rpgMenuStatus == RpgMenuStatus.OPENSTATUS) {
            rpgMenuText.text = menuAction[statusActionNumber];
            setStatusExtraInfoText();
            if(statusActionNumber < 9) {
                extraInfoTextHolder.SetActive(true);
                extraInfoText.text = extraMenuInfo[statusActionNumber];
            }
            else extraInfoTextHolder.SetActive(false);
        }
        else if(rpgMenuStatus == RpgMenuStatus.OPENSKILL) {
            
        }
        else if(rpgMenuStatus == RpgMenuStatus.OPENARMOUR) {
            rpgMenuText.text = menuAction[armourActionNumber];
            setArmourExtraText();
            extraInfoTextHolder.SetActive(true);
            extraInfoText.text = extraMenuInfo[armourActionNumber];
        }
        else if(rpgMenuStatus == RpgMenuStatus.OPENSETTINGS) {
            
        }
        else if(rpgMenuStatus == RpgMenuStatus.GOTBACKTOHOME) {
            
        }
        if(rpgMenuStatus != RpgMenuStatus.OPENSTATUS && statusActionNumber >= 9 || rpgMenuStatus != RpgMenuStatus.OPENARMOUR) extraInfoTextHolder.SetActive(false);
    }

    public void setMenuText() {
        mainActionNumber = 0;
        if(mainPlayerStatus.playerStatusPoints > 0) {
            menuAction[0] = "<color=#ffffffff>▶︎アイテム\nステータス !\nスキル\n装備\n設定\nメインメニューに戻る</color>";
            menuAction[1] = "<color=#ffffffff>アイテム\n▶︎ステータス !\nスキル\n装備\n設定\nメインメニューに戻る</color>";
            menuAction[2] = "<color=#ffffffff>アイテム\nステータス !\n▶︎スキル\n装備\n設定\nメインメニューに戻る</color>";
            menuAction[3] = "<color=#ffffffff>アイテム\nステータス !\nスキル\n▶︎装備\n設定\nメインメニューに戻る</color>";
            menuAction[4] = "<color=#ffffffff>アイテム\nステータス !\nスキル\n装備\n▶︎設定\nメインメニューに戻る</color>";
            menuAction[5] = "<color=#ffffffff>アイテム\nステータス !\nスキル\n装備\n設定\n▶︎メインメニューに戻る</color>";
        }
        else {
            menuAction[0] = "<color=#ffffffff>▶︎アイテム\nステータス\nスキル\n装備\n設定\nメインメニューに戻る</color>";
            menuAction[1] = "<color=#ffffffff>アイテム\n▶︎ステータス\nスキル\n装備\n設定\nメインメニューに戻る</color>";
            menuAction[2] = "<color=#ffffffff>アイテム\nステータス\n▶︎スキル\n装備\n設定\nメインメニューに戻る</color>";
            menuAction[3] = "<color=#ffffffff>アイテム\nステータス\nスキル\n▶︎装備\n設定\nメインメニューに戻る</color>";
            menuAction[4] = "<color=#ffffffff>アイテム\nステータス\nスキル\n装備\n▶︎設定\nメインメニューに戻る</color>";
            menuAction[5] = "<color=#ffffffff>アイテム\nステータス\nスキル\n装備\n設定\n▶︎メインメニューに戻る</color>";
        }
    }

    public void setStatusText() {
        menuAction[0] = "<color=#ffffffff>" + mainPlayerStatus.playerName + "のステータス\n残りステータスポイント　" + statusPointsDiff + "\n\n▶︎最大HP　" 
            + mainPlayerStatus.playerMaxHp + " +" + maxHPDiff + "\n最大MP　" + mainPlayerStatus.playerMaxMp + " +" + maxMPDiff + "\n物理攻撃力　" + mainPlayerStatus.playerPhysicalAttack + " +" 
            + physicalAttackDiff + "\n魔法攻撃力　" + mainPlayerStatus.playerMagicalAttack + " +" + magicalAttackDiff + "\n物理防御　" + mainPlayerStatus.playerPhysicalDefense + " +" + physicalDefenseDiff 
            + "\n魔法防御　" + mainPlayerStatus.playerMagicalDefense + " +" + magicalDefenseDiff + "\nクリティカルチャンス　" + mainPlayerStatus.playerCriticalChance + " +" 
            + criticalChanceDiff + "\nクリティカル倍率　" + mainPlayerStatus.playerCriticalDamage + " +" + criticalDamageDiff + "\n速度　" + mainPlayerStatus.playerSpeed + " +" + speedDiff + "\n決定\n元に戻す</color>";
        menuAction[1] = "<color=#ffffffff>" + mainPlayerStatus.playerName + "のステータス\n残りステータスポイント　" + statusPointsDiff + "\n\n最大HP　" 
            + mainPlayerStatus.playerMaxHp + " +" + maxHPDiff + "\n▶︎最大MP　" + mainPlayerStatus.playerMaxMp + " +" + maxMPDiff + "\n物理攻撃力　" + mainPlayerStatus.playerPhysicalAttack + " +" 
            + physicalAttackDiff + "\n魔法攻撃力　" + mainPlayerStatus.playerMagicalAttack + " +" + magicalAttackDiff + "\n物理防御　" + mainPlayerStatus.playerPhysicalDefense + " +" + physicalDefenseDiff 
            + "\n魔法防御　" + mainPlayerStatus.playerMagicalDefense + " +" + magicalDefenseDiff + "\nクリティカルチャンス　" + mainPlayerStatus.playerCriticalChance + " +" 
            + criticalChanceDiff + "\nクリティカル倍率　" + mainPlayerStatus.playerCriticalDamage + " +" + criticalDamageDiff + "\n速度　" + mainPlayerStatus.playerSpeed + " +" + speedDiff + "\n決定\n元に戻す</color>";
        menuAction[2] = "<color=#ffffffff>" + mainPlayerStatus.playerName + "のステータス\n残りステータスポイント　" + statusPointsDiff + "\n\n最大HP　" 
            + mainPlayerStatus.playerMaxHp + " +" + maxHPDiff + "\n最大MP　" + mainPlayerStatus.playerMaxMp + " +" + maxMPDiff + "\n▶︎物理攻撃力　" + mainPlayerStatus.playerPhysicalAttack + " +" 
            + physicalAttackDiff + "\n魔法攻撃力　" + mainPlayerStatus.playerMagicalAttack + " +" + magicalAttackDiff + "\n物理防御　" + mainPlayerStatus.playerPhysicalDefense + " +" + physicalDefenseDiff 
            + "\n魔法防御　" + mainPlayerStatus.playerMagicalDefense + " +" + magicalDefenseDiff + "\nクリティカルチャンス　" + mainPlayerStatus.playerCriticalChance + " +" 
            + criticalChanceDiff + "\nクリティカル倍率　" + mainPlayerStatus.playerCriticalDamage + " +" + criticalDamageDiff + "\n速度　" + mainPlayerStatus.playerSpeed + " +" + speedDiff + "\n決定\n元に戻す</color>";
        menuAction[3] = "<color=#ffffffff>" + mainPlayerStatus.playerName + "のステータス\n残りステータスポイント　" + statusPointsDiff + "\n\n最大HP　" 
            + mainPlayerStatus.playerMaxHp + " +" + maxHPDiff + "\n最大MP　" + mainPlayerStatus.playerMaxMp + " +" + maxMPDiff + "\n物理攻撃力　" + mainPlayerStatus.playerPhysicalAttack + " +" 
            + physicalAttackDiff + "\n▶︎魔法攻撃力　" + mainPlayerStatus.playerMagicalAttack + " +" + magicalAttackDiff + "\n物理防御　" + mainPlayerStatus.playerPhysicalDefense + " +" + physicalDefenseDiff 
            + "\n魔法防御　" + mainPlayerStatus.playerMagicalDefense + " +" + magicalDefenseDiff + "\nクリティカルチャンス　" + mainPlayerStatus.playerCriticalChance + " +" 
            + criticalChanceDiff + "\nクリティカル倍率　" + mainPlayerStatus.playerCriticalDamage + " +" + criticalDamageDiff + "\n速度　" + mainPlayerStatus.playerSpeed + " +" + speedDiff + "\n決定\n元に戻す</color>";
        menuAction[4] = "<color=#ffffffff>" + mainPlayerStatus.playerName + "のステータス\n残りステータスポイント　" + statusPointsDiff + "\n\n最大HP　" 
            + mainPlayerStatus.playerMaxHp + " +" + maxHPDiff + "\n最大MP　" + mainPlayerStatus.playerMaxMp + " +" + maxMPDiff + "\n物理攻撃力　" + mainPlayerStatus.playerPhysicalAttack + " +" 
            + physicalAttackDiff + "\n魔法攻撃力　" + mainPlayerStatus.playerMagicalAttack + " +" + magicalAttackDiff + "\n▶︎物理防御　" + mainPlayerStatus.playerPhysicalDefense + " +" + physicalDefenseDiff 
            + "\n魔法防御　" + mainPlayerStatus.playerMagicalDefense + " +" + magicalDefenseDiff + "\nクリティカルチャンス　" + mainPlayerStatus.playerCriticalChance + " +" 
            + criticalChanceDiff + "\nクリティカル倍率　" + mainPlayerStatus.playerCriticalDamage + " +" + criticalDamageDiff + "\n速度　" + mainPlayerStatus.playerSpeed + " +" + speedDiff + "\n決定\n元に戻す</color>";
        menuAction[5] = "<color=#ffffffff>" + mainPlayerStatus.playerName + "のステータス\n残りステータスポイント　" + statusPointsDiff + "\n\n最大HP　" 
            + mainPlayerStatus.playerMaxHp + " +" + maxHPDiff + "\n最大MP　" + mainPlayerStatus.playerMaxMp + " +" + maxMPDiff + "\n物理攻撃力　" + mainPlayerStatus.playerPhysicalAttack + " +" 
            + physicalAttackDiff + "\n魔法攻撃力　" + mainPlayerStatus.playerMagicalAttack + " +" + magicalAttackDiff + "\n物理防御　" + mainPlayerStatus.playerPhysicalDefense + " +" + physicalDefenseDiff 
            + "\n▶︎魔法防御　" + mainPlayerStatus.playerMagicalDefense + " +" + magicalDefenseDiff + "\nクリティカルチャンス　" + mainPlayerStatus.playerCriticalChance + " +" 
            + criticalChanceDiff + "\nクリティカル倍率　" + mainPlayerStatus.playerCriticalDamage + " +" + criticalDamageDiff + "\n速度　" + mainPlayerStatus.playerSpeed + " +" + speedDiff + "\n決定\n元に戻す</color>";
        menuAction[6] = "<color=#ffffffff>" + mainPlayerStatus.playerName + "のステータス\n残りステータスポイント　" + statusPointsDiff + "\n\n最大HP　" 
            + mainPlayerStatus.playerMaxHp + " +" + maxHPDiff + "\n最大MP　" + mainPlayerStatus.playerMaxMp + " +" + maxMPDiff + "\n物理攻撃力　" + mainPlayerStatus.playerPhysicalAttack + " +" 
            + physicalAttackDiff + "\n魔法攻撃力　" + mainPlayerStatus.playerMagicalAttack + " +" + magicalAttackDiff + "\n物理防御　" + mainPlayerStatus.playerPhysicalDefense + " +" + physicalDefenseDiff 
            + "\n魔法防御　" + mainPlayerStatus.playerMagicalDefense + " +" + magicalDefenseDiff + "\n▶︎クリティカルチャンス　" + mainPlayerStatus.playerCriticalChance + " +" 
            + criticalChanceDiff + "\nクリティカル倍率　" + mainPlayerStatus.playerCriticalDamage + " +" + criticalDamageDiff + "\n速度　" + mainPlayerStatus.playerSpeed + " +" + speedDiff + "\n決定\n元に戻す</color>";
        menuAction[7] = "<color=#ffffffff>" + mainPlayerStatus.playerName + "のステータス\n残りステータスポイント　" + statusPointsDiff + "\n\n最大HP　" 
            + mainPlayerStatus.playerMaxHp + " +" + maxHPDiff + "\n最大MP　" + mainPlayerStatus.playerMaxMp + " +" + maxMPDiff + "\n物理攻撃力　" + mainPlayerStatus.playerPhysicalAttack + " +" 
            + physicalAttackDiff + "\n魔法攻撃力　" + mainPlayerStatus.playerMagicalAttack + " +" + magicalAttackDiff + "\n物理防御　" + mainPlayerStatus.playerPhysicalDefense + " +" + physicalDefenseDiff 
            + "\n魔法防御　" + mainPlayerStatus.playerMagicalDefense + " +" + magicalDefenseDiff + "\nクリティカルチャンス　" + mainPlayerStatus.playerCriticalChance + " +" 
            + criticalChanceDiff + "\n▶︎クリティカル倍率　" + mainPlayerStatus.playerCriticalDamage + " +" + criticalDamageDiff + "\n速度　" + mainPlayerStatus.playerSpeed + " +" + speedDiff + "\n決定\n元に戻す</color>";
        menuAction[8] = "<color=#ffffffff>" + mainPlayerStatus.playerName + "のステータス\n残りステータスポイント　" + statusPointsDiff + "\n\n最大HP　" 
            + mainPlayerStatus.playerMaxHp + " +" + maxHPDiff + "\n最大MP　" + mainPlayerStatus.playerMaxMp + " +" + maxMPDiff + "\n物理攻撃力　" + mainPlayerStatus.playerPhysicalAttack + " +" 
            + physicalAttackDiff + "\n魔法攻撃力　" + mainPlayerStatus.playerMagicalAttack + " +" + magicalAttackDiff + "\n物理防御　" + mainPlayerStatus.playerPhysicalDefense + " +" + physicalDefenseDiff 
            + "\n魔法防御　" + mainPlayerStatus.playerMagicalDefense + " +" + magicalDefenseDiff + "\nクリティカルチャンス　" + mainPlayerStatus.playerCriticalChance + " +" 
            + criticalChanceDiff + "\nクリティカル倍率　" + mainPlayerStatus.playerCriticalDamage + " +" + criticalDamageDiff + "\n▶︎速度　" + mainPlayerStatus.playerSpeed + " +" + speedDiff + "\n決定\n元に戻す</color>";
        menuAction[9] = "<color=#ffffffff>" + mainPlayerStatus.playerName + "のステータス\n残りステータスポイント　" + statusPointsDiff + "\n\n最大HP　" 
            + mainPlayerStatus.playerMaxHp + " +" + maxHPDiff + "\n最大MP　" + mainPlayerStatus.playerMaxMp + " +" + maxMPDiff + "\n物理攻撃力　" + mainPlayerStatus.playerPhysicalAttack + " +" 
            + physicalAttackDiff + "\n魔法攻撃力　" + mainPlayerStatus.playerMagicalAttack + " +" + magicalAttackDiff + "\n物理防御　" + mainPlayerStatus.playerPhysicalDefense + " +" + physicalDefenseDiff 
            + "\n魔法防御　" + mainPlayerStatus.playerMagicalDefense + " +" + magicalDefenseDiff + "\nクリティカルチャンス　" + mainPlayerStatus.playerCriticalChance + " +" 
            + criticalChanceDiff + "\nクリティカル倍率　" + mainPlayerStatus.playerCriticalDamage + " +" + criticalDamageDiff + "\n速度　" + mainPlayerStatus.playerSpeed + " +" + speedDiff + "\n▶︎決定\n元に戻す</color>";
        menuAction[10] = "<color=#ffffffff>" + mainPlayerStatus.playerName + "のステータス\n残りステータスポイント　" + statusPointsDiff + "\n\n最大HP　" 
            + mainPlayerStatus.playerMaxHp + " +" + maxHPDiff + "\n最大MP　" + mainPlayerStatus.playerMaxMp + " +" + maxMPDiff + "\n物理攻撃力　" + mainPlayerStatus.playerPhysicalAttack + " +" 
            + physicalAttackDiff + "\n魔法攻撃力　" + mainPlayerStatus.playerMagicalAttack + " +" + magicalAttackDiff + "\n物理防御　" + mainPlayerStatus.playerPhysicalDefense + " +" + physicalDefenseDiff 
            + "\n魔法防御　" + mainPlayerStatus.playerMagicalDefense + " +" + magicalDefenseDiff + "\nクリティカルチャンス　" + mainPlayerStatus.playerCriticalChance + " +" 
            + criticalChanceDiff + "\nクリティカル倍率　" + mainPlayerStatus.playerCriticalDamage + " +" + criticalDamageDiff + "\n速度　" + mainPlayerStatus.playerSpeed + " +" + speedDiff + "\n決定\n▶︎元に戻す</color>";
    }

    public void setStatusExtraInfoText() {
        extraMenuInfo[0] = "<color=#ffffffff>最大HPが上昇します。</color>";
        extraMenuInfo[1] = "<color=#ffffffff>最大MPが上昇します。\nMPはスキルを使うのに必要です。</color>";
        extraMenuInfo[2] = "<color=#ffffffff>通常攻撃と物理攻撃を使用するスキルが強くなります。</color>";
        extraMenuInfo[3] = "<color=#ffffffff>魔法攻撃を使用するスキルが強くなります。</color>";
        extraMenuInfo[4] = "<color=#ffffffff>敵の物理攻撃と通常攻撃から受けるダメージが軽減されます。</color>";
        extraMenuInfo[5] = "<color=#ffffffff>敵の魔法攻撃から受けるダメージが軽減されます。</color>";
        extraMenuInfo[6] = "<color=#ffffffff>敵にクリティカルダメージを与える確率が上昇します。</color>";
        extraMenuInfo[7] = "<color=#ffffffff>敵に与えるクリティカルダメージ倍率が上昇します。</color>";
        extraMenuInfo[8] = "<color=#ffffffff>敵から受ける攻撃をかわす確率が上がります。\n敵に攻撃をかわされる確率が下がります。\n敵から逃げられる確率が上がります。</color>";
    }
    
    public void setArmourText() {
        float physicalAttackMultiplyer = battleController.calculatePhysicalAttackMultiplyer(), magicalAttackMultiplyer = battleController.calculateMagicalAttackMultiplyer(),
              physicalDefenseMultiplyer = battleController.calculatePhysicalDefenseMultiplyer(), magicalDefenseMultiplyer = battleController.calculateMagicalDefenseMultiplyer();
        
        menuAction[0] = "<color=#ffffffff>装備一覧\n▶︎頭　" + mainPlayerStatus.playerArmourHead.armourName + "\n体　" + mainPlayerStatus.playerArmourBody.armourName
            + "\n手　" + mainPlayerStatus.playerArmourHand.armourName + "\n足　" + mainPlayerStatus.playerArmourFeet.armourName 
            + "\n装飾品　" + mainPlayerStatus.playerNecklace.armourName + "\n装飾品　" + mainPlayerStatus.playerWristband.armourName 
            + "\n武器　" + mainPlayerStatus.playerWeapon.weaponName + "\n\n装備による倍率アップ合計\n物理攻撃上昇倍率" + physicalAttackMultiplyer + "\n魔法攻撃上昇倍率" 
            + magicalAttackMultiplyer + "\n物理防御上昇倍率" + physicalDefenseMultiplyer + "\n魔法防御上昇倍率" + magicalDefenseMultiplyer + "</color>";
        menuAction[1] = "<color=#ffffffff>装備一覧\n頭　" + mainPlayerStatus.playerArmourHead.armourName + "\n▶︎体　" + mainPlayerStatus.playerArmourBody.armourName
            + "\n手　" + mainPlayerStatus.playerArmourHand.armourName + "\n足　" + mainPlayerStatus.playerArmourFeet.armourName 
            + "\n装飾品　" + mainPlayerStatus.playerNecklace.armourName + "\n装飾品　" + mainPlayerStatus.playerWristband.armourName 
            + "\n武器　" + mainPlayerStatus.playerWeapon.weaponName + "\n\n装備による倍率アップ合計\n物理攻撃上昇倍率" + physicalAttackMultiplyer + "\n魔法攻撃上昇倍率" 
            + magicalAttackMultiplyer + "\n物理防御上昇倍率" + physicalDefenseMultiplyer + "\n魔法防御上昇倍率" + magicalDefenseMultiplyer + "</color>";
        menuAction[2] = "<color=#ffffffff>装備一覧\n頭　" + mainPlayerStatus.playerArmourHead.armourName + "\n体　" + mainPlayerStatus.playerArmourBody.armourName
            + "\n▶︎手　" + mainPlayerStatus.playerArmourHand.armourName + "\n足　" + mainPlayerStatus.playerArmourFeet.armourName 
            + "\n装飾品　" + mainPlayerStatus.playerNecklace.armourName + "\n装飾品　" + mainPlayerStatus.playerWristband.armourName 
            + "\n武器　" + mainPlayerStatus.playerWeapon.weaponName + "\n\n装備による倍率アップ合計\n物理攻撃上昇倍率" + physicalAttackMultiplyer + "\n魔法攻撃上昇倍率" 
            + magicalAttackMultiplyer + "\n物理防御上昇倍率" + physicalDefenseMultiplyer + "\n魔法防御上昇倍率" + magicalDefenseMultiplyer + "</color>";
        menuAction[3] = "<color=#ffffffff>装備一覧\n頭　" + mainPlayerStatus.playerArmourHead.armourName + "\n体　" + mainPlayerStatus.playerArmourBody.armourName
            + "\n手　" + mainPlayerStatus.playerArmourHand.armourName + "\n▶︎足　" + mainPlayerStatus.playerArmourFeet.armourName 
            + "\n装飾品　" + mainPlayerStatus.playerNecklace.armourName + "\n装飾品　" + mainPlayerStatus.playerWristband.armourName 
            + "\n武器　" + mainPlayerStatus.playerWeapon.weaponName + "\n\n装備による倍率アップ合計\n物理攻撃上昇倍率" + physicalAttackMultiplyer + "\n魔法攻撃上昇倍率" 
            + magicalAttackMultiplyer + "\n物理防御上昇倍率" + physicalDefenseMultiplyer + "\n魔法防御上昇倍率" + magicalDefenseMultiplyer + "</color>";
        menuAction[4] = "<color=#ffffffff>装備一覧\n頭　" + mainPlayerStatus.playerArmourHead.armourName + "\n体　" + mainPlayerStatus.playerArmourBody.armourName
            + "\n手　" + mainPlayerStatus.playerArmourHand.armourName + "\n足　" + mainPlayerStatus.playerArmourFeet.armourName 
            + "\n▶︎装飾品　" + mainPlayerStatus.playerNecklace.armourName + "\n装飾品　" + mainPlayerStatus.playerWristband.armourName 
            + "\n武器　" + mainPlayerStatus.playerWeapon.weaponName + "\n\n装備による倍率アップ合計\n物理攻撃上昇倍率" + physicalAttackMultiplyer + "\n魔法攻撃上昇倍率" 
            + magicalAttackMultiplyer + "\n物理防御上昇倍率" + physicalDefenseMultiplyer + "\n魔法防御上昇倍率" + magicalDefenseMultiplyer + "</color>";
        menuAction[5] = "<color=#ffffffff>装備一覧\n頭　" + mainPlayerStatus.playerArmourHead.armourName + "\n体　" + mainPlayerStatus.playerArmourBody.armourName
            + "\n手　" + mainPlayerStatus.playerArmourHand.armourName + "\n足　" + mainPlayerStatus.playerArmourFeet.armourName 
            + "\n装飾品　" + mainPlayerStatus.playerNecklace.armourName + "\n▶︎装飾品　" + mainPlayerStatus.playerWristband.armourName 
            + "\n武器　" + mainPlayerStatus.playerWeapon.weaponName + "\n\n装備による倍率アップ合計\n物理攻撃上昇倍率" + physicalAttackMultiplyer + "\n魔法攻撃上昇倍率" 
            + magicalAttackMultiplyer + "\n物理防御上昇倍率" + physicalDefenseMultiplyer + "\n魔法防御上昇倍率" + magicalDefenseMultiplyer + "</color>";
        menuAction[6] = "<color=#ffffffff>装備一覧\n頭　" + mainPlayerStatus.playerArmourHead.armourName + "\n体　" + mainPlayerStatus.playerArmourBody.armourName
            + "\n手　" + mainPlayerStatus.playerArmourHand.armourName + "\n足　" + mainPlayerStatus.playerArmourFeet.armourName 
            + "\n装飾品　" + mainPlayerStatus.playerNecklace.armourName + "\n装飾品　" + mainPlayerStatus.playerWristband.armourName 
            + "\n▶︎武器　" + mainPlayerStatus.playerWeapon.weaponName + "\n\n装備による倍率アップ合計\n物理攻撃上昇倍率" + physicalAttackMultiplyer + "\n魔法攻撃上昇倍率" 
            + magicalAttackMultiplyer + "\n物理防御上昇倍率" + physicalDefenseMultiplyer + "\n魔法防御上昇倍率" + magicalDefenseMultiplyer + "</color>";
    }

    public void setArmourExtraText() {
        extraMenuInfo[0] = getArmourMultiplyerInfo(mainPlayerStatus.playerArmourHead);
        extraMenuInfo[1] = getArmourMultiplyerInfo(mainPlayerStatus.playerArmourBody);
        extraMenuInfo[2] = getArmourMultiplyerInfo(mainPlayerStatus.playerArmourHand);
        extraMenuInfo[3] = getArmourMultiplyerInfo(mainPlayerStatus.playerArmourFeet);
        extraMenuInfo[4] = getArmourMultiplyerInfo(mainPlayerStatus.playerNecklace);
        extraMenuInfo[5] = getArmourMultiplyerInfo(mainPlayerStatus.playerWristband);
        extraMenuInfo[6] = getWeaponMultiplyerInfo(mainPlayerStatus.playerWeapon);
    }

    public string getArmourMultiplyerInfo(Armour armour) {
        string armourInfo = "<color=#ffffffff>";
        if(armour.physicalAttackMultiplyer != 1f) armourInfo += ("物理攻撃上昇倍率 " + armour.physicalAttackMultiplyer + "倍" + "\n");
        if(armour.magicalAttackMultiplyer != 1f) armourInfo += ("魔法攻撃上昇倍率 " + armour.magicalAttackMultiplyer + "倍" + "\n");
        if(armour.physicalDefenseMultiplyer != 1f) armourInfo += ("物理防御上昇倍率 " + armour.physicalDefenseMultiplyer + "倍" + "\n");
        if(armour.magicalDefenseMultiplyer != 1f) armourInfo += ("魔法防御上昇倍率 " + armour.magicalDefenseMultiplyer + "倍" + "\n");
        if(armour.criticalChanceMultiplyer != 1f) armourInfo += ("クリティカルチャンス上昇倍率 " + armour.criticalChanceMultiplyer + "倍" + "\n");
        if(armour.criticalDamageMultiplyer != 1f) armourInfo += ("クリティカル攻撃上昇倍率 " + armour.criticalDamageMultiplyer + "倍" + "\n");
        if(armour.healMultiplyer != 1f) armourInfo += ("回復量上昇倍率 " + armour.healMultiplyer + "倍" + "\n");
        armourInfo += "</color>";
        return armourInfo;
    }

    public string getWeaponMultiplyerInfo(Weapon weapon) {
        string weaponInfo = "<color=#ffffffff>";
        if(weapon.physicalAttackMultiplyer != 1f) weaponInfo += ("物理攻撃上昇倍率 " + weapon.physicalAttackMultiplyer + "倍" + "\n");
        if(weapon.magicalAttackMultiplyer != 1f) weaponInfo += ("魔法攻撃上昇倍率 " + weapon.magicalAttackMultiplyer　+ "倍" + "\n");
        if(weapon.physicalDefenseMultiplyer != 1f) weaponInfo += ("物理防御上昇倍率 " + weapon.physicalDefenseMultiplyer + "倍" + "\n");
        if(weapon.magicalDefenseMultiplyer != 1f) weaponInfo += ("魔法防御上昇倍率 " + weapon.magicalDefenseMultiplyer + "倍" + "\n");
        if(weapon.criticalChanceMultiplyer != 1f) weaponInfo += ("クリティカルチャンス上昇倍率 " + weapon.criticalChanceMultiplyer + "倍" + "\n");
        if(weapon.criticalDamageMultiplyer != 1f) weaponInfo += ("クリティカル攻撃上昇倍率 " + weapon.criticalDamageMultiplyer + "倍" + "\n");
        if(weapon.healMultiplyer != 1f) weaponInfo += ("回復量上昇倍率 " + weapon.healMultiplyer + "倍" + "\n");
        weaponInfo += "</color>";
        return weaponInfo;
    }

    public void chooseAction() {
        if(mainActionNumber == 0) {
            openMenu();
        }
        else if(mainActionNumber == 1) {
            openStatus();
        }
        else if(mainActionNumber == 2) {
            openSkill();
        }
        else if(mainActionNumber == 3) {
            openArmour();
        }
        else if(mainActionNumber == 4) {
            openSettings();
        }
        else if(mainActionNumber == 5) {
            goBackToHome();
        }
    }

    public void chooseStatusAction(bool aButton) {
        bool isStatusPointRemaining = statusPointsDiff > 0;
        bool decreaseable = false;
        if(statusActionNumber == 0) {
            decreaseable = maxHPDiff > 0 && mainPlayerStatus.playerStatusPoints > statusPointsDiff;
            if(aButton && isStatusPointRemaining) {
                maxHPDiff++;
                statusPointsDiff--;
                setStatusText();
            }
            else if(!aButton && decreaseable) {
                maxHPDiff--;
                statusPointsDiff++;
                setStatusText();
            }
        }
        else if(statusActionNumber == 1) {
            decreaseable = maxMPDiff > 0 && mainPlayerStatus.playerStatusPoints > statusPointsDiff;
            if(aButton && isStatusPointRemaining) {
                maxMPDiff++;
                statusPointsDiff--;
                setStatusText();
            }
            else if(!aButton && decreaseable) {
                maxMPDiff--;
                statusPointsDiff++;
                setStatusText();
            }
        }
        else if(statusActionNumber == 2) {
            decreaseable = physicalAttackDiff > 0 && mainPlayerStatus.playerStatusPoints > statusPointsDiff;
            if(aButton && isStatusPointRemaining) {
                physicalAttackDiff++;
                statusPointsDiff--;
                setStatusText();
            }
            else if(!aButton && decreaseable) {
                physicalAttackDiff--;
                statusPointsDiff++;
                setStatusText();
            }
        }
        else if(statusActionNumber == 3) {
            decreaseable = magicalAttackDiff > 0 && mainPlayerStatus.playerStatusPoints > statusPointsDiff;
            if(aButton && isStatusPointRemaining) {
                magicalAttackDiff++;
                statusPointsDiff--;
                setStatusText();
            }
            else if(!aButton && decreaseable) {
                magicalAttackDiff--;
                statusPointsDiff++;
                setStatusText();
            }
        }
        else if(statusActionNumber == 4) {
            decreaseable = physicalDefenseDiff > 0 && mainPlayerStatus.playerStatusPoints > statusPointsDiff;
            if(aButton && isStatusPointRemaining) {
                physicalDefenseDiff++;
                statusPointsDiff--;
                setStatusText();
            }
            else if(!aButton && decreaseable) {
                physicalDefenseDiff--;
                statusPointsDiff++;
                setStatusText();
            }
        }
        else if(statusActionNumber == 5) {
            decreaseable = magicalDefenseDiff > 0 && mainPlayerStatus.playerStatusPoints > statusPointsDiff;
            if(aButton && isStatusPointRemaining) {
                magicalDefenseDiff++;
                statusPointsDiff--;
                setStatusText();
            }
            else if(!aButton && decreaseable) {
                magicalDefenseDiff--;
                statusPointsDiff++;
                setStatusText();
            }
        }
        else if(statusActionNumber == 6) {
            decreaseable = criticalChanceDiff > 0 && mainPlayerStatus.playerStatusPoints > statusPointsDiff;
            if(aButton && isStatusPointRemaining) {
                criticalChanceDiff++;
                statusPointsDiff--;
                setStatusText();
            }
            else if(!aButton && decreaseable) {
                criticalChanceDiff--;
                statusPointsDiff++;
                setStatusText();
            }
        }
        else if(statusActionNumber == 7) {
            decreaseable = criticalDamageDiff > 0 && mainPlayerStatus.playerStatusPoints > statusPointsDiff;
            if(aButton && isStatusPointRemaining) {
                criticalDamageDiff++;
                statusPointsDiff--;
                setStatusText();
            }
            else if(!aButton && decreaseable) {
                criticalDamageDiff--;
                statusPointsDiff++;
                setStatusText();
            }
        }
        else if(statusActionNumber == 8) {
            decreaseable = speedDiff > 0 && mainPlayerStatus.playerStatusPoints > statusPointsDiff;
            if(aButton && isStatusPointRemaining) {
                speedDiff++;
                statusPointsDiff--;
                setStatusText();
            }
            else if(!aButton && decreaseable) {
                speedDiff--;
                statusPointsDiff++;
                setStatusText();
            }
        }
        else if(statusActionNumber == 9) {
            if(aButton) {
                applyDiffs();
                resetStatusDiffs();
                setStatusText();
            }
            else { goBack(); }
        }
        else if(statusActionNumber == 10) {
            if(aButton) {
                resetStatusDiffs();
                setStatusText();
            }
            else goBack();
        }
    }

    public void openMenu() {
        setMenuText();
        rpgMenuStatus = RpgMenuStatus.OPEN;
    }

    public void openItem() {
        rpgMenuStatus = RpgMenuStatus.OPENITEM;
    }
    public void openStatus() {
        statusActionNumber = 0;
        resetStatusDiffs();
        setStatusText();
        rpgMenuStatus = RpgMenuStatus.OPENSTATUS;
    }
    public void openSkill() {
        rpgMenuStatus = RpgMenuStatus.OPENSKILL;
    }
    public void openArmour() {
        armourActionNumber = 0;
        setArmourText();
        rpgMenuStatus = RpgMenuStatus.OPENARMOUR;
    }
    public void openSettings() {
        rpgMenuStatus = RpgMenuStatus.OPENSETTINGS;
    }
    public void goBackToHome() {
        rpgMenuStatus = RpgMenuStatus.GOTBACKTOHOME;
    }
    public void goBack() {
        if(rpgMenuStatus == RpgMenuStatus.OPEN) {
            mainRpgController.closeMenu();
        }
        else {
            setMenuText();
            rpgMenuStatus = RpgMenuStatus.OPEN;
        }
    }
    
    public void resetStatusDiffs() {
        statusPointsDiff = mainPlayerStatus.playerStatusPoints;
        maxHPDiff = 0;
        maxMPDiff = 0;
        physicalAttackDiff = 0;
        magicalAttackDiff = 0;
        physicalDefenseDiff = 0;
        magicalDefenseDiff = 0;
        criticalChanceDiff = 0;
        criticalDamageDiff = 0;
        speedDiff = 0; 
    }

    public void applyDiffs() {
        mainPlayerStatus.playerStatusPoints = statusPointsDiff;
        mainPlayerStatus.playerMaxHp += maxHPDiff; 
        mainPlayerStatus.playerCurrentHp += maxHPDiff; 
        mainPlayerStatus.playerMaxMp += maxMPDiff;
        mainPlayerStatus.playerCurrentMp += maxMPDiff;
        mainPlayerStatus.playerPhysicalAttack += physicalAttackDiff;
        mainPlayerStatus.playerMagicalAttack += magicalAttackDiff;
        mainPlayerStatus.playerPhysicalDefense += physicalDefenseDiff;
        mainPlayerStatus.playerMagicalDefense += magicalDefenseDiff;
        mainPlayerStatus.playerCriticalChance += criticalChanceDiff;
        mainPlayerStatus.playerCriticalDamage += criticalDamageDiff;
        mainPlayerStatus.playerSpeed += speedDiff;
    }
}
