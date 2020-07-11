using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour {
    public string skillName = "スキル１";
    public int skillNumber = 0;
    public bool isSkillTargetMultiple = false;
    public bool isPhysicalAttack = true;
    public bool isHeal = false;

    public int MpCost = 10;

    public float physicalAttackMultiplyer = 1f;
    public float magicalAttackMultiplyer = 1f;

    public float physicalDefenseMultiplyer = 1f;
    public float magicalDefenseMultiplyer = 1f;

    public float criticalChanceMultiplyer = 1f;
    public float criticalDamageMultiplyer = 1f;

    public float healMultiplyer = 1f;

    public void setSkill(int chosenSkillNumber){
        if(chosenSkillNumber == 0){
            skillName = "攻撃";
            skillNumber = chosenSkillNumber;

            isSkillTargetMultiple = false;
            isPhysicalAttack = true;
            isHeal = false;

            MpCost = 0;

            physicalAttackMultiplyer = 1f;
            magicalAttackMultiplyer = 1f;

            physicalDefenseMultiplyer = 1f;
            magicalDefenseMultiplyer = 1f;

            criticalChanceMultiplyer = 1f;
            criticalDamageMultiplyer = 1f;
        }
        else if(chosenSkillNumber == 1){
            skillName = "強打１";
            skillNumber = chosenSkillNumber;

            isSkillTargetMultiple = false;
            isPhysicalAttack = true;
            isHeal = false;

            MpCost = 10;

            physicalAttackMultiplyer = 1.3f;
            magicalAttackMultiplyer = 1f;

            physicalDefenseMultiplyer = 1f;
            magicalDefenseMultiplyer = 1f;

            criticalChanceMultiplyer = 1f;
            criticalDamageMultiplyer = 1f;
        }
        else if(chosenSkillNumber == 2){
            skillName = "強打２";
            skillNumber = chosenSkillNumber;

            isSkillTargetMultiple = false;
            isPhysicalAttack = true;
            isHeal = false;

            MpCost = 15;

            physicalAttackMultiplyer = 1.5f;
            magicalAttackMultiplyer = 1f;

            physicalDefenseMultiplyer = 1f;
            magicalDefenseMultiplyer = 1f;

            criticalChanceMultiplyer = 1f;
            criticalDamageMultiplyer = 1f;
        }
        else if(chosenSkillNumber == 3){
            skillName = "大振り";
            skillNumber = chosenSkillNumber;

            isSkillTargetMultiple = true;
            isPhysicalAttack = true;
            isHeal = false;

            MpCost = 20;

            physicalAttackMultiplyer = 1f;
            magicalAttackMultiplyer = 1f;

            physicalDefenseMultiplyer = 1f;
            magicalDefenseMultiplyer = 1f;

            criticalChanceMultiplyer = 1f;
            criticalDamageMultiplyer = 1f;
        }
        else if(chosenSkillNumber == 4){
            skillName = "大振り1";
            skillNumber = chosenSkillNumber;

            isSkillTargetMultiple = true;
            isPhysicalAttack = true;
            isHeal = false;

            MpCost = 20;

            physicalAttackMultiplyer = 1f;
            magicalAttackMultiplyer = 1f;

            physicalDefenseMultiplyer = 1f;
            magicalDefenseMultiplyer = 1f;

            criticalChanceMultiplyer = 1f;
            criticalDamageMultiplyer = 1f;
        }
        else if(chosenSkillNumber == 5){
            skillName = "大振り2";
            skillNumber = chosenSkillNumber;

            isSkillTargetMultiple = true;
            isPhysicalAttack = true;
            isHeal = false;

            MpCost = 20;

            physicalAttackMultiplyer = 1f;
            magicalAttackMultiplyer = 1f;

            physicalDefenseMultiplyer = 1f;
            magicalDefenseMultiplyer = 1f;

            criticalChanceMultiplyer = 1f;
            criticalDamageMultiplyer = 1f;
        }
        else if(chosenSkillNumber == 6){
            skillName = "大振り3";
            skillNumber = chosenSkillNumber;

            isSkillTargetMultiple = true;
            isPhysicalAttack = true;
            isHeal = false;

            MpCost = 20;

            physicalAttackMultiplyer = 1f;
            magicalAttackMultiplyer = 1f;

            physicalDefenseMultiplyer = 1f;
            magicalDefenseMultiplyer = 1f;

            criticalChanceMultiplyer = 1f;
            criticalDamageMultiplyer = 1f;
        }
        else if(chosenSkillNumber == 7){
            skillName = "大振り4";
            skillNumber = chosenSkillNumber;

            isSkillTargetMultiple = true;
            isPhysicalAttack = true;
            isHeal = false;

            MpCost = 20;

            physicalAttackMultiplyer = 1f;
            magicalAttackMultiplyer = 1f;

            physicalDefenseMultiplyer = 1f;
            magicalDefenseMultiplyer = 1f;

            criticalChanceMultiplyer = 1f;
            criticalDamageMultiplyer = 1f;
        }
    }
}
