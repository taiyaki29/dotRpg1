using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class MapControl : MonoBehaviour
{
    [SerializeField]
    public Grid isometricGrid;

    [SerializeField]
    public Tilemap layerGround;

    void Start() {
        renderMapItems();
    }

    void Update() {
        
    }

    public void renderMapItems() {
        Vector3Int testPosition = randomPosition(5,5); // No.1
        Tile testTile = Resources.Load<Tile>("sprites/ground_tiles/ground_grass/BrightForest-A2_130"); // No.2
        layerGround.SetTile(testPosition, testTile); // No.3
    }

    public Vector3Int randomPosition(int maxX, int maxY) {
        int x = UnityEngine.Random.Range(-1 * maxX, maxX);
        int y = UnityEngine.Random.Range(-1 * maxY, maxY);

        Vector3Int randomPosition = new Vector3Int(x, y, 0);
        return randomPosition; 
    }
}
