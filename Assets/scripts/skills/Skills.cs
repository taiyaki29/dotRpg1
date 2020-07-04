using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour {
    public string skillName = "スキル１";

    public float physicalAttackMultiplyer = 1f;
    public float magicalAttackMultiplyer = 1f;

    public float physicalDefenseMultiplyer = 1f;
    public float magicalDefenseMultiplyer = 1f;

    public float criticalChanceMultiplyer = 1f;
    public float criticalDamageMultiplyer = 1f;

    public float healMultiplyer = 1f;

    public void useSkill(int skillNumber){
        if(skillNumber == 0){
            skillName = "強打";
            physicalAttackMultiplyer = 1.3f;
        }
        else if(skillNumber == 1){
            skillName = "強打2";
            physicalAttackMultiplyer = 1.3f;
        }
        else if(skillNumber == 2){
            skillName = "強打3";
            physicalAttackMultiplyer = 1.3f;
        }
    }

    public string returnSkillName(int skillNumber){
        if(skillNumber == 0){
            return "強打";
        }
        else if(skillNumber == 1){
            return "強打2";
        }
        else if(skillNumber == 2){
            return "強打3";
        }
        else return "error";
    }
}
