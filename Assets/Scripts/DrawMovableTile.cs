using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DrawMovableTile : MonoBehaviour
{
    [SerializeField] Tilemap movableMap;
    [SerializeField] Tile movableTile;
    
    public void DrawTile(int x,int y){

        for(int i = 0; i < x; i++){
            for(int j = 0; j < y; j++){
                movableMap.SetTile(new Vector3Int(i,j,0),movableTile);
            }
        }

    }

    public void DeleteTile(int x,int y){

        for(int i = 0; i < x; i++){
            for(int j = 0; j < y; j++){
                movableMap.SetTile(new Vector3Int(i,j,0),null);
            }
        }

    }

}