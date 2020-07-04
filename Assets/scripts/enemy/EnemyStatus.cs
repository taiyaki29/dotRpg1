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
    　
    public int enemyLevel = 10;

    public int enemyCurrentHp = 20;
    public int enemyMaxHp = 20;
    public int enemyCurrentMp = 20;
    public int enemyMaxMp = 20;

    public int enemyPhysicalDefense = 10;
    public int enemyMagicalDefense = 10;

    public int enemyPhysicalAttack = 10;
    public int enemyMagicalAttack = 10;

    public int enemySpeed = 10;

    void Start()
    {
        battleControl = battleController.GetComponent<BattleControl>();
    }

    void Update()
    {
        
    }

    public void chooseEnemy(){
        if(battleControl.chosenEnemy == this){
            battleControl.chosenEnemy = null;
        }
        else {
            battleControl.chosenEnemy = this;
        }
        Debug.Log(battleControl.chosenEnemy);
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
        
        enemyCurrentHp = enemyMaxHp = 10;
        enemyCurrentMp = enemyMaxMp = 10;

        enemyPhysicalDefense = 5;
        enemyMagicalDefense = 5;

        enemyPhysicalAttack = 1;
        enemyMagicalAttack = 1;

        enemySpeed = 1;
    }

    public void spawnJumpingSlime(){
        enemyName = "ジャンピングスライム";
        enemyImage = this.GetComponent<SpriteRenderer>();
        enemySprite = Resources.Load<Sprite>("sprites/enemy/mon1/mon_025");
        enemyImage.sprite = enemySprite;
        
        enemyCurrentHp = enemyMaxHp = 15;
        enemyCurrentMp = enemyMaxMp = 15;

        enemyPhysicalDefense = 7;
        enemyMagicalDefense = 7;

        enemyPhysicalAttack = 5;
        enemyMagicalAttack = 5;

        enemySpeed = 5;
    }

}
