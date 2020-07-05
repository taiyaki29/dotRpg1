using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour {
    public string skillName = "スキル１";
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

    public void useSkill(int skillNumber){
        if(skillNumber == 0){
            skillName = "攻撃";
            isSkillTargetMultiple = false;
            physicalAttackMultiplyer = 1f;
            MpCost = 0;
        }
        else if(skillNumber == 1){
            skillName = "強打1";
            isSkillTargetMultiple = false;
            physicalAttackMultiplyer = 1.3f;
        }
        else if(skillNumber == 2){
            skillName = "強打2";
            isSkillTargetMultiple = false;
            physicalAttackMultiplyer = 1.5f;
        }
        else if(skillNumber == 3){
            skillName = "大振り";
            isSkillTargetMultiple = true;
            physicalAttackMultiplyer = 1.3f;
        }
    }

    public string returnSkillName(int skillNumber){
        if(skillNumber == 0){
            return "攻撃";
        }
        else if(skillNumber == 1){
            return "強打1";
        }
        else if(skillNumber == 2){
            return "強打2";
        }
        else if(skillNumber == 3){
            return "大振り";
        }
        else return "error";
    }
}
