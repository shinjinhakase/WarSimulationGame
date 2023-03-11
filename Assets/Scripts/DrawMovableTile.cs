using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DrawMovableTile : MonoBehaviour
{
    [SerializeField] Tilemap movableMap;
    [SerializeField] Tile movableTile;
    
    public void DrawTile(List<Vector3Int> cells){

        foreach(Vector3Int cell in cells){
            movableMap.SetTile(cell,movableTile);
        }

    }

    public void DeleteTile(List<Vector3Int> cells){

        foreach(Vector3Int cell in cells){
            movableMap.SetTile(cell,null);
        }

    }

}