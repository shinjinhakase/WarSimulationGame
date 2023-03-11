using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DrawMovableTile : MonoBehaviour
{
    [SerializeField] Tilemap movableMap;
    [SerializeField] Tile movableTile;
    List<Vector3Int> saveTiles;
    
    public void DrawTile(List<Vector3Int> cells){

        saveTiles = cells;
        foreach(Vector3Int cell in cells){
            movableMap.SetTile(cell,movableTile);
        }

    }

    public void DeleteTile(){

        foreach(Vector3Int cell in saveTiles){
            movableMap.SetTile(cell,null);
        }

    }

}