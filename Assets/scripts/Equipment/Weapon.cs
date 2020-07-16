using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponName = "test weapon";        // 1
    public int weaponNumber = 0;                     // 2

    public float physicalAttackMultiplyer = 1f;      // 3
    public float magicalAttackMultiplyer = 1f;       // 4

    public float physicalDefenseMultiplyer = 1f;     // 5
    public float magicalDefenseMultiplyer = 1f;      // 6

    public float criticalChanceMultiplyer = 1f;      // 7
    public float criticalDamageMultiplyer = 1f;      // 8

    public float healMultiplyer = 1f;                // 9

    public void setweaponParameters(string name, int number, float PAMulti, float MAMulti, float PDMulti,
        float MDMulti, float CCMulti, float CDMulti, float HMulti){
        
        weaponName = name;
        weaponNumber = number;

        physicalAttackMultiplyer = PAMulti;
        magicalAttackMultiplyer = MAMulti;

        physicalDefenseMultiplyer = PDMulti;
        magicalDefenseMultiplyer = MDMulti;

        criticalChanceMultiplyer = CCMulti;
        criticalDamageMultiplyer = CDMulti;

        healMultiplyer = HMulti;
    }

    public void setweapon(int chosenweaponNumber){
        if(chosenweaponNumber == 0){
            setweaponParameters("enmty weapon", chosenweaponNumber, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
        }
        if(chosenweaponNumber == 1){
            setweaponParameters("test sword", chosenweaponNumber, 1.5f, 1f, 1f, 1f, 1f, 1f, 1f);
        }
        else if(chosenweaponNumber == 2){
            setweaponParameters("test staff", chosenweaponNumber, 1f, 1.5f, 1f, 1f, 1f, 1f, 1f);
        }
    }
}
