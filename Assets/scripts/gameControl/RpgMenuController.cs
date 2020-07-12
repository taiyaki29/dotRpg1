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

    public GameObject player;
    public MainPlayerStatus mainPlayerStatus;

    public string[] menuAction = new string[12];
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


    void Start(){
        rpgMenuText = rpgMenuTextholder.GetComponent<Text>();
        mainRpgController = mainRpgControl.GetComponent<MainRpgController>();
        mainPlayerStatus = player.GetComponent<MainPlayerStatus>();
    }

    void Update(){
        if(rpgMenuStatus == RpgMenuStatus.OPEN){
            rpgMenuText.text = menuAction[mainActionNumber];
        }
        else if(rpgMenuStatus == RpgMenuStatus.OPENITEM){

        }
        else if(rpgMenuStatus == RpgMenuStatus.OPENSTATUS){
            rpgMenuText.text = menuAction[statusActionNumber];
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

    public void setMenuText(){Debug.Log("set");
        mainActionNumber = 0;
        menuAction[0] = "<color=#ffffffff>▶︎アイテム\nステータス\nスキル\n装備\n設定\nメインメニューに戻る</color>";
        menuAction[1] = "<color=#ffffffff>アイテム\n▶︎ステータス\nスキル\n装備\n設定\nメインメニューに戻る</color>";
        menuAction[2] = "<color=#ffffffff>アイテム\nステータス\n▶︎スキル\n装備\n設定\nメインメニューに戻る</color>";
        menuAction[3] = "<color=#ffffffff>アイテム\nステータス\nスキル\n▶︎装備\n設定\nメインメニューに戻る</color>";
        menuAction[4] = "<color=#ffffffff>アイテム\nステータス\nスキル\n装備\n▶︎設定\nメインメニューに戻る</color>";
        menuAction[5] = "<color=#ffffffff>アイテム\nステータス\nスキル\n装備\n設定\n▶︎メインメニューに戻る</color>";
    }

    public void setStatusText(){Debug.Log("setStatus");
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

    public void chooseAction(){
        if(mainActionNumber == 0){
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

    public void chooseStatusAction(bool aButton){
        bool isStatusPointRemaining = statusPointsDiff > 0;
        Debug.Log(mainPlayerStatus.playerStatusPoints);
        Debug.Log(statusPointsDiff);
        bool decreaseable = false;
        if(statusActionNumber == 0){
            decreaseable = maxHPDiff > 0 && mainPlayerStatus.playerStatusPoints > statusPointsDiff;
            if(aButton && isStatusPointRemaining){
                maxHPDiff++;
                statusPointsDiff--;
                setStatusText();
            }
            else if(!aButton && decreaseable){
                maxHPDiff--;
                statusPointsDiff++;
                setStatusText();
            }
        }
        else if(statusActionNumber == 1){
            decreaseable = maxMPDiff > 0 && mainPlayerStatus.playerStatusPoints > statusPointsDiff;
            if(aButton && isStatusPointRemaining){
                maxMPDiff++;
                statusPointsDiff--;
                setStatusText();
            }
            else if(!aButton && decreaseable){
                maxMPDiff--;
                statusPointsDiff++;
                setStatusText();
            }
        }
        else if(statusActionNumber == 2){
            decreaseable = physicalAttackDiff > 0 && mainPlayerStatus.playerStatusPoints > statusPointsDiff;
            if(aButton && isStatusPointRemaining){
                physicalAttackDiff++;
                statusPointsDiff--;
                setStatusText();
            }
            else if(!aButton && decreaseable){
                physicalAttackDiff--;
                statusPointsDiff++;
                setStatusText();
            }
        }
        else if(statusActionNumber == 3){
            decreaseable = magicalAttackDiff > 0 && mainPlayerStatus.playerStatusPoints > statusPointsDiff;
            if(aButton && isStatusPointRemaining){
                magicalAttackDiff++;
                statusPointsDiff--;
                setStatusText();
            }
            else if(!aButton && decreaseable){
                magicalAttackDiff--;
                statusPointsDiff++;
                setStatusText();
            }
        }
        else if(statusActionNumber == 4){
            decreaseable = physicalDefenseDiff > 0 && mainPlayerStatus.playerStatusPoints > statusPointsDiff;
            if(aButton && isStatusPointRemaining){
                physicalDefenseDiff++;
                statusPointsDiff--;
                setStatusText();
            }
            else if(!aButton && decreaseable){
                physicalDefenseDiff--;
                statusPointsDiff++;
                setStatusText();
            }
        }
        else if(statusActionNumber == 5){
            decreaseable = magicalDefenseDiff > 0 && mainPlayerStatus.playerStatusPoints > statusPointsDiff;
            if(aButton && isStatusPointRemaining){
                magicalDefenseDiff++;
                statusPointsDiff--;
                setStatusText();
            }
            else if(!aButton && decreaseable){
                magicalDefenseDiff--;
                statusPointsDiff++;
                setStatusText();
            }
        }
        else if(statusActionNumber == 6){
            decreaseable = criticalChanceDiff > 0 && mainPlayerStatus.playerStatusPoints > statusPointsDiff;
            if(aButton && isStatusPointRemaining){
                criticalChanceDiff++;
                statusPointsDiff--;
                setStatusText();
            }
            else if(!aButton && decreaseable){
                criticalChanceDiff--;
                statusPointsDiff++;
                setStatusText();
            }
        }
        else if(statusActionNumber == 7){
            decreaseable = criticalDamageDiff > 0 && mainPlayerStatus.playerStatusPoints > statusPointsDiff;
            if(aButton && isStatusPointRemaining){
                criticalDamageDiff++;
                statusPointsDiff--;
                setStatusText();
            }
            else if(!aButton && decreaseable){
                criticalDamageDiff--;
                statusPointsDiff++;
                setStatusText();
            }
        }
        else if(statusActionNumber == 8){
            decreaseable = speedDiff > 0 && mainPlayerStatus.playerStatusPoints > statusPointsDiff;
            if(aButton && isStatusPointRemaining){
                speedDiff++;
                statusPointsDiff--;
                setStatusText();
            }
            else if(!aButton && decreaseable){
                speedDiff--;
                statusPointsDiff++;
                setStatusText();
            }
        }
        else if(statusActionNumber == 9) {
            if(aButton){
                applyDiffs();
                resetStatusDiffs();
                setStatusText();
            }
            else { goBack(); }
        }
        else if(statusActionNumber == 10) {
            if(aButton){
                resetStatusDiffs();
                setStatusText();
            }
            else goBack();
        }
    }

    public void openMenu(){
        setMenuText();
        rpgMenuStatus = RpgMenuStatus.OPEN;
    }

    public void openItem(){
        rpgMenuStatus = RpgMenuStatus.OPENITEM;
    }
    public void openStatus(){
        statusActionNumber = 0;
        resetStatusDiffs();
        setStatusText();
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
        else {
            setMenuText();
            rpgMenuStatus = RpgMenuStatus.OPEN;
        }
    }
    
    public void resetStatusDiffs(){
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

    public void applyDiffs(){
        mainPlayerStatus.playerStatusPoints = statusPointsDiff;
        mainPlayerStatus.playerMaxHp += maxHPDiff; 
        mainPlayerStatus.playerMaxMp += maxMPDiff;
        mainPlayerStatus.playerPhysicalAttack += physicalAttackDiff;
        mainPlayerStatus.playerMagicalAttack += magicalAttackDiff;
        mainPlayerStatus.playerPhysicalDefense += physicalDefenseDiff;
        mainPlayerStatus.playerMagicalDefense += magicalDefenseDiff;
        mainPlayerStatus.playerCriticalChance += criticalChanceDiff;
        mainPlayerStatus.playerCriticalDamage += criticalDamageDiff;
        mainPlayerStatus.playerSpeed += speedDiff;
    }
}
