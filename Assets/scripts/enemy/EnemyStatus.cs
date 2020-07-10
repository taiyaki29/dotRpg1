using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour
{
    public GameObject battleController;
    BattleControl battleControl;

    public string enemyName = "テスト敵";

    public SpriteRenderer enemyImage;
    public Sprite enemySprite;

    public GameObject SkillsGameObject1;
    public GameObject SkillsGameObject2;
    public GameObject SkillsGameObject3;
    public GameObject SkillsGameObject4;
    　
    public int enemyLevel = 10;

    public int enemyExperience = 10;
    public int enemyGold = 10;

    public int enemyCurrentHp = 20;
    public int enemyMaxHp = 20;
    public int enemyCurrentMp = 20;
    public int enemyMaxMp = 20;

    public int enemyPhysicalDefense = 5;
    public int enemyMagicalDefense = 5;

    public int enemyPhysicalAttack = 5;
    public int enemyMagicalAttack = 5;

    public Skills[] enemySkills =new Skills[3];

    public int enemySpeed = 10;

    void Start()
    {
        battleControl = battleController.GetComponent<BattleControl>();
    }

    void Update()
    {
        
    }

    public void chooseEnemy(){
        if(battleControl.battleStatus == BattleStatus.PLAYERTURN || battleControl.battleStatus == BattleStatus.PLAYERTURNSKILL){
            if(battleControl.chosenEnemy == this){
                battleControl.chosenEnemy = null;
                battleControl.chosen1.SetActive(false);
                battleControl.chosen2.SetActive(false);
                battleControl.chosen3.SetActive(false);
            }
            else {
                battleControl.chosenEnemy = this;
            }
            if(battleControl.chosenEnemy == battleControl.enemy1Status && battleControl.enemy1Status.enemyCurrentHp > 0){
                battleControl.chosen1.SetActive(true);
                battleControl.chosen2.SetActive(false);
                battleControl.chosen3.SetActive(false);
            }
            else if(battleControl.chosenEnemy == battleControl.enemy2Status && battleControl.enemy2Status.enemyCurrentHp > 0){
                battleControl.chosen1.SetActive(false);
                battleControl.chosen2.SetActive(true);
                battleControl.chosen3.SetActive(false);
            }
            else if(battleControl.chosenEnemy == battleControl.enemy3Status && battleControl.enemy3Status.enemyCurrentHp > 0){
                battleControl.chosen1.SetActive(false);
                battleControl.chosen2.SetActive(false);
                battleControl.chosen3.SetActive(true);
            }
        }
    }

    public void getSkillsReady(){
        enemySkills[0] = SkillsGameObject1.GetComponent<Skills>();
        enemySkills[1] = SkillsGameObject2.GetComponent<Skills>();
        enemySkills[2] = SkillsGameObject3.GetComponent<Skills>();
        enemySkills[3] = SkillsGameObject4.GetComponent<Skills>();
        // normal attack
        for(int i=0; i<4; i++) enemySkills[i].setSkill(0);
    }

    public void spawnEnemy(int stageNumber){
        int randomSpawnNumber = UnityEngine.Random.Range(1,3);
        if(stageNumber == 1){
            if(randomSpawnNumber == 1){
                spawnSlime();
            }
            else if(randomSpawnNumber == 2){
                spawnJumpingSlime();
            }
        }
    }

    public void spawnSlime(){
        enemyName = "スライム";
        enemyImage = this.GetComponent<SpriteRenderer>();
        enemySprite = Resources.Load<Sprite>("sprites/enemy/mon1/mon_002");
        enemyImage.sprite = enemySprite;

        enemyExperience = 10;
        enemyGold = 10;
        
        enemyCurrentHp = enemyMaxHp = 10;
        enemyCurrentMp = enemyMaxMp = 10;

        enemyPhysicalDefense = 5;
        enemyMagicalDefense = 5;

        enemyPhysicalAttack = 1;
        enemyMagicalAttack = 1;

        getSkillsReady();
        enemySkills[1].setSkill(1);

        enemySpeed = 1;
    }

    public void spawnJumpingSlime(){
        enemyName = "ジャンピングスライム";
        enemyImage = this.GetComponent<SpriteRenderer>();
        enemySprite = Resources.Load<Sprite>("sprites/enemy/mon1/mon_025");
        enemyImage.sprite = enemySprite;

        enemyExperience = 15;
        enemyGold = 15;
        
        enemyCurrentHp = enemyMaxHp = 15;
        enemyCurrentMp = enemyMaxMp = 15;

        enemyPhysicalDefense = 7;
        enemyMagicalDefense = 7;

        enemyPhysicalAttack = 6;
        enemyMagicalAttack = 6;

        getSkillsReady();
        enemySkills[1].setSkill(2);

        enemySpeed = 5;
    }

}
