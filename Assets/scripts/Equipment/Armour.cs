using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armour : MonoBehaviour
{
    public string armourName = "test armour";        // 1
    public int armourNumber = 0;                     // 2
    public string armourType = "head";               // 3

    public float physicalAttackMultiplyer = 1f;      // 4
    public float magicalAttackMultiplyer = 1f;       // 5

    public float physicalDefenseMultiplyer = 1f;     // 6
    public float magicalDefenseMultiplyer = 1f;      // 7

    public float criticalChanceMultiplyer = 1f;      // 8
    public float criticalDamageMultiplyer = 1f;      // 9

    public float healMultiplyer = 1f;                // 10

    public void setArmourParameters(string name, int number, string type, float PAMulti, float MAMulti, float PDMulti,
        float MDMulti, float CCMulti, float CDMulti, float HMulti){
        
        armourName = name;
        armourNumber = number;
        armourType = type;

        physicalAttackMultiplyer = PAMulti;
        magicalAttackMultiplyer = MAMulti;

        physicalDefenseMultiplyer = PDMulti;
        magicalDefenseMultiplyer = MDMulti;

        criticalChanceMultiplyer = CCMulti;
        criticalDamageMultiplyer = CDMulti;

        healMultiplyer = HMulti;
    }

    public void setArmour(int chosenArmourNumber, string armourType){
        if(chosenArmourNumber == 0){
            if(armourType == "head") {
                setArmourParameters("empty head", chosenArmourNumber, armourType, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
            }
            else if(armourType == "body") {
                setArmourParameters("empty body", chosenArmourNumber, armourType, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
            }
            else if(armourType == "shoes") {
                setArmourParameters("empty shoes", chosenArmourNumber, armourType, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
            }
            else if(armourType == "hand") {
                setArmourParameters("empty hand", chosenArmourNumber, armourType, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
            }
            else if(armourType == "necklace") {
                setArmourParameters("empty necklace", chosenArmourNumber, armourType, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
            }
            else if(armourType == "wristband") {
                setArmourParameters("empty wristband", chosenArmourNumber, armourType, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
            }
        }
        else if(chosenArmourNumber == 1){
            if(armourType == "head") {
                setArmourParameters("test head", chosenArmourNumber, armourType, 1f, 1f, 1.2f, 1.2f, 1f, 1f, 1f);
            }
            else if(armourType == "body") {
                setArmourParameters("test body", chosenArmourNumber, armourType, 1f, 1f, 1.2f, 1.2f, 1f, 1f, 1f);
            }
            else if(armourType == "shoes") {
                setArmourParameters("test shoes", chosenArmourNumber, armourType, 1f, 1f, 1.2f, 1.2f, 1f, 1f, 1f);
            }
            else if(armourType == "hand") {
                setArmourParameters("test hand", chosenArmourNumber, armourType, 1f, 1f, 1.2f, 1.2f, 1f, 1f, 1f);
            }
            else if(armourType == "necklace") {
                setArmourParameters("test necklace", chosenArmourNumber, armourType, 1f, 1f, 1.2f, 1.2f, 1f, 1f, 1f);
            }
            else if(armourType == "wristband") {
                setArmourParameters("test wristband", chosenArmourNumber, armourType, 1f, 1f, 1.2f, 1.2f, 1f, 1f, 1f);
            }
        }
    }
}
