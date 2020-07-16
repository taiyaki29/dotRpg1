using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour {
    public string skillName = "スキル１";
    public int skillNumber = 0;
    public bool isSkillTargetMultiple = false;
    public bool isPhysicalAttack = true;
    public bool isAttack = true;
    public bool isHeal = false;

    public int MpCost = 10;

    public float physicalAttackMultiplyer = 1f;
    public float magicalAttackMultiplyer = 1f;

    public float physicalDefenseMultiplyer = 1f;
    public float magicalDefenseMultiplyer = 1f;

    public float criticalChanceMultiplyer = 1f;
    public float criticalDamageMultiplyer = 1f;

    public float healMultiplyer = 1f;

    public void setSkillParameters(string name, int number, bool multiple, bool physical, bool attack, bool heal, int cost,
        float PAMultiplyer, float MAMultiplyer, float PDMultiplyer, float MDMultiplyer, 
        float CCMultiplyer, float CDMultiplyer, float HMultiplyer){
    
        skillName = name;
        skillNumber = number;

        isSkillTargetMultiple = multiple;
        isPhysicalAttack = physical;
        isAttack = attack;
        isHeal = heal;

        MpCost = cost;

        physicalAttackMultiplyer = PAMultiplyer;
        magicalAttackMultiplyer = MAMultiplyer;

        physicalDefenseMultiplyer = PDMultiplyer;
        magicalDefenseMultiplyer = MDMultiplyer;

        criticalChanceMultiplyer = CCMultiplyer;
        criticalDamageMultiplyer = CDMultiplyer;

        healMultiplyer = HMultiplyer;
    }

    public void setSkill(int chosenSkillNumber){
        if(chosenSkillNumber == 0){
            setSkillParameters("attack", chosenSkillNumber, false, true, true, false, 0, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
        }
        else if(chosenSkillNumber == 1){
            setSkillParameters("strong attack 1", chosenSkillNumber, false, true, true, false, 10, 1.3f, 1f, 1f, 1f, 1f, 1f, 1f);
        }
        else if(chosenSkillNumber == 2){
            setSkillParameters("strong attack 2", chosenSkillNumber, false, true, true, false, 10, 1.5f, 1f, 1f, 1f, 1f, 1f, 1f);
        }
        else if(chosenSkillNumber == 3){
            setSkillParameters("all attack", chosenSkillNumber, true, true, true, false, 10, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
        }
        else if(chosenSkillNumber == 4){
            setSkillParameters("all attack 2", chosenSkillNumber, true, true, true, false, 10, 1.2f, 1f, 1f, 1f, 1f, 1f, 1f);
        }
        else if(chosenSkillNumber == 5){
            setSkillParameters("all attack 3", chosenSkillNumber, true, true, true, false, 10, 1.5f, 1f, 1f, 1f, 1f, 1f, 1f);
        }
        else if(chosenSkillNumber == 6){
            setSkillParameters("all attack 4", chosenSkillNumber, true, true, true, false, 10, 2f, 1f, 1f, 1f, 1f, 1f, 1f);
        }
        else if(chosenSkillNumber == 7){
            setSkillParameters("all attack magic", chosenSkillNumber, true, false, true, false, 10, 1f, 1.5f, 1f, 1f, 1f, 1f, 1f);
        }
    }
}
