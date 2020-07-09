using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerPosition;
    public Vector3 playerPos, nextPosition;
    public Animator walkingAnimator;

    public GameObject mainRpgControl;
    MainRpgController mainRpgController;

    public GameObject battleControl;
    BattleControl battleController;

    public GameObject player;
    MainPlayerStatus mainPlayerStatus;

    public float movementSpeed = 0.1f;

    bool playerMovingUp =false;
    bool playerMovingDown =false;
    bool playerMovingLeft =false;
    bool playerMovingRight =false;

    bool holdMoveUp =false;
    bool holdMoveDown =false;
    bool holdMoveLeft =false;
    bool holdMoveRight =false;

    public int playerStepsLimit = 200;

    void Start(){
        mainRpgController = mainRpgControl.GetComponent<MainRpgController>();
        battleController = battleControl.GetComponent<BattleControl>();
        mainPlayerStatus = player.GetComponent<MainPlayerStatus>();
    }

    void Update(){
        playerPosition = this.transform;
        playerPos = playerPosition.position;
    }

    void FixedUpdate(){ 
        //called every 0.05 seconds
        if(holdMoveUp){
            MoveUp();
        }
        else if(holdMoveDown){
            MoveDown();
        }
        else if(holdMoveLeft){
            MoveLeft();
        }
        else if(holdMoveRight){
            MoveRight();
        }
        if(playerMovingUp){
            walkingAnimator.SetFloat("horizontal", 1);
            walkingAnimator.SetFloat("vertical", 0);
            if(playerPosition.position.y < nextPosition.y){
                playerPos.y += movementSpeed;
                playerPos.y *= 10;
                playerPos.y = Convert.ToSingle(Math.Round(playerPos.y)) / 10;
                playerPosition.position = playerPos;
            }
            checkNextMove();
        }
        else if(playerMovingDown){
            walkingAnimator.SetFloat("horizontal", -1);
            walkingAnimator.SetFloat("vertical", 0);
            if(playerPosition.position.y > nextPosition.y){
                playerPos.y -= movementSpeed;
                playerPos.y *= 10;
                playerPos.y = Convert.ToSingle(Math.Round(playerPos.y)) / 10;
                playerPosition.position = playerPos;
            }
            checkNextMove();
        }
        else if (playerMovingLeft){
            walkingAnimator.SetFloat("vertical", -1);
            walkingAnimator.SetFloat("horizontal", 0);
            if(playerPosition.position.x > nextPosition.x){
                playerPos.x -= movementSpeed;
                playerPos.x *= 10;
                playerPos.x = Convert.ToSingle(Math.Round(playerPos.x)) / 10;
                playerPosition.position = playerPos;
            }
            checkNextMove();
        }
        else if(playerMovingRight){
            walkingAnimator.SetFloat("vertical", 1);
            walkingAnimator.SetFloat("horizontal", 0);
            if(playerPosition.position.x < nextPosition.x){
                playerPos.x += movementSpeed;
                playerPos.x *= 10;
                playerPos.x = Convert.ToSingle(Math.Round(playerPos.x)) / 10;
                playerPosition.position = playerPos;
            }
            checkNextMove();
        }
    }

    public bool isPlayerMoving(){
        return (playerMovingUp || playerMovingDown || playerMovingLeft || playerMovingRight);
    }

    public void checkNextMove(){
        if(playerPosition.position == nextPosition) {
            playerStepsLimit--;
            if(playerMovingUp){
                playerMovingUp = false;
                if(!isPointerDown()){
                    walkingAnimator.SetBool("moving", false);
                    walkingAnimator.SetBool("lookUp", true);
                    walkingAnimator.SetBool("lookDown", false);
                    walkingAnimator.SetBool("lookLeft", false);
                    walkingAnimator.SetBool("lookRight", false);
                }
            }
            else if(playerMovingDown){
                playerMovingDown = false;
                if(!isPointerDown()){
                    walkingAnimator.SetBool("moving", false);
                    walkingAnimator.SetBool("lookDown", true);
                    walkingAnimator.SetBool("lookUp", false);
                    walkingAnimator.SetBool("lookLeft", false);
                    walkingAnimator.SetBool("lookRight", false);    
                }
            }
            else if(playerMovingLeft){
                playerMovingLeft = false;
                if(!isPointerDown()){
                    walkingAnimator.SetBool("moving", false);
                    walkingAnimator.SetBool("lookLeft", true);
                    walkingAnimator.SetBool("lookDown", false);
                    walkingAnimator.SetBool("lookUp", false);
                    walkingAnimator.SetBool("lookRight", false);
                }
            }
            else if(playerMovingRight){
                playerMovingRight = false;
                if(!isPointerDown()){
                    walkingAnimator.SetBool("moving", false);
                    walkingAnimator.SetBool("lookRight", true);
                    walkingAnimator.SetBool("lookDown", false);
                    walkingAnimator.SetBool("lookLeft", false);
                    walkingAnimator.SetBool("lookUp", false);
                }
            }
        } 
    }

    //button functions
    public void MoveUpPointerDown(){
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){
            holdMoveUp = true;
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BATTLE){
            if(battleController.battleStatus == BattleStatus.PLAYERTURN){
                if(battleController.actionNumber > 0) battleController.actionNumber--;
                else if(battleController.actionNumber == 0) battleController.actionNumber = 3;
            }
            else if(battleController.battleStatus == BattleStatus.PLAYERTURNSKILL){
                if(battleController.skillNumber > 0) battleController.skillNumber--;
                else if(battleController.skillNumber == 0) battleController.skillNumber = mainPlayerStatus.playerSkillCount - 1;
            }
        }
    }
    public void MoveUpPointerUp(){
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){
            holdMoveUp = false;
        }
    }
    public void MoveDownPointerDown(){
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){
            holdMoveDown = true;
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BATTLE){
            if(battleController.battleStatus == BattleStatus.PLAYERTURN){
                if(battleController.actionNumber < 3)battleController.actionNumber++;
                else if(battleController.actionNumber == 3)battleController.actionNumber = 0;
            }
            else if(battleController.battleStatus == BattleStatus.PLAYERTURNSKILL){
                if(battleController.skillNumber < mainPlayerStatus.playerSkillCount - 1) battleController.skillNumber++;
                else if(battleController.skillNumber == mainPlayerStatus.playerSkillCount - 1) battleController.skillNumber = 0;
            }
        }
    }
    public void MoveDownPointerUp(){
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){
            holdMoveDown = false;
        }
    }
    public void MoveLeftPointerDown(){
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){
            holdMoveLeft = true;
        }
    }
    public void MoveLeftPointerUp(){
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){
            holdMoveLeft = false;
        }
    }
    public void MoveRightPointerDown(){
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){
            holdMoveRight = true;
        }
    }
    public void MoveRightPointerUp(){
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){
            holdMoveRight = false;
        }
    }

    public bool isPointerDown(){
        return (holdMoveUp || holdMoveDown || holdMoveLeft || holdMoveRight);
    }

    // player movement direction
    public void MoveUp(){
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){
            if(!isPlayerMoving()){
                playerMovingUp = true;
                walkingAnimator.SetBool("moving", true);
                nextPosition = playerPos;
                nextPosition.y = Convert.ToSingle(Math.Ceiling(playerPos.y + 1f));
            }
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BATTLE){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BOSS){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.SHOP){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.MENU){
            
        }
    }
    public void MoveDown(){
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){
            if(!isPlayerMoving()){
                playerMovingDown = true;
                walkingAnimator.SetBool("moving", true);
                nextPosition = playerPos;
                nextPosition.y = Convert.ToSingle(Math.Ceiling(playerPos.y - 1f));
            }
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BATTLE){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BOSS){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.SHOP){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.MENU){
            
        }
    }
    public void MoveLeft(){
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){
            if(!isPlayerMoving()){
                playerMovingLeft = true;
                walkingAnimator.SetBool("moving", true);
                nextPosition = playerPos;
                nextPosition.x = Convert.ToSingle(Math.Ceiling(playerPos.x - 1f));
            }
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BATTLE){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BOSS){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.SHOP){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.MENU){
            
        }
    }
    public void MoveRight(){
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){
           if(!isPlayerMoving()){
                playerMovingRight = true;
                walkingAnimator.SetBool("moving", true);
                nextPosition = playerPos;
                nextPosition.x = Convert.ToSingle(Math.Ceiling(playerPos.x + 1f));
            }
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BATTLE){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BOSS){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.SHOP){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.MENU){
            
        }
    }

    // player animations
    public void setDirectionToNull(){
        walkingAnimator.SetBool("lookRight", false);
        walkingAnimator.SetBool("lookDown", false);
        walkingAnimator.SetBool("lookLeft", false);
        walkingAnimator.SetBool("lookUp", false);
    }

    // public void setPlayerStepCountToZero(){
    //     playerStepsLimit = 0;
    // }
}
