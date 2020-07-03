using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonControls : MonoBehaviour
{
    public GameObject mainRpgControl;
    MainRpgController mainRpgController;

    public GameObject BButton;
    Text bButtonText;

    void Start()
    {
        mainRpgController = mainRpgControl.GetComponent<MainRpgController>();
        bButtonText = BButton.GetComponent<Text>();
    }

    void Update(){

    }

    void FixedUpdate()
    {
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){
            bButtonText.text = "<b>m</b>";
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BATTLE){
            bButtonText.text = "<b>戻る</b>";
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.BOSS){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.SHOP){
            
        }
        else if(mainRpgController.mainRpgStatus == MainRpgStatus.MENU){
            
        }
    }

    public void A_Button(){
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){

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

    public void B_Button(){
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){

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

    public void menuButton(){
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){

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

    // TEMPLATE //
    public void template(){
        if(mainRpgController.mainRpgStatus == MainRpgStatus.WALK){

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
    // TEMPLATE //
}
