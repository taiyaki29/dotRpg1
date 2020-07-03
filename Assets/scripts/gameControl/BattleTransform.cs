using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTransform : MonoBehaviour
{
    public GameObject battleScreen;
    public GameObject player;
    Transform battleScreenPosition;
    void Start()
    {
        battleScreenPosition = battleScreen.GetComponent<Transform>();
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        battleScreenPosition.position = playerMovement.playerPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
