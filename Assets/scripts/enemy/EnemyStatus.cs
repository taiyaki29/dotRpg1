using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour
{
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
        
    }

    void Update()
    {
        
    }

    public void spawnEnemy(int stageNumber){
        int randomSpawnNumber = UnityEngine.Random.Range(1,2);
        if(stageNumber == 1){
            if(randomSpawnNumber == 1){
                spawnSlime();
            }
        }
    }

    public void spawnSlime(){
        enemyName = "スライム製造";
        enemyImage = this.GetComponent<SpriteRenderer>();
        enemySprite = Resources.Load<Sprite>("sprites/enemy/mon1/mon_002");
        enemyImage.sprite = enemySprite;
        
        enemyCurrentHp = 10;
        enemyMaxHp = 10;
        enemyCurrentMp = 10;
        enemyMaxMp = 10;

        enemyPhysicalDefense = 5;
        enemyMagicalDefense = 5;

        enemyPhysicalAttack = 1;
        enemyMagicalAttack = 1;

        enemySpeed = 1;
    }
}
