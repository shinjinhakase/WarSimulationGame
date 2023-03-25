using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DrawMovableTile : MonoBehaviour
{
    [SerializeField] Tilemap movableMap;
    [SerializeField] Tile movableTile;
    List<Vector3Int> saveTiles;
    [SerializeField] GameObject Map;
    Map mapData;

    void Start(){
        mapData = Map.GetComponent<Map>();
    }
    
    public void DrawTile(Unit unit){

        List<Vector3Int> cells = mapData.isMovableList(unit);
        saveTiles = cells;
        foreach(Vector3Int cell in cells){
            movableMap.SetTile(cell,movableTile);
        }

    }

    public void DeleteTile(bool selected){

        if(selected){

            foreach(Vector3Int cell in saveTiles){
                movableMap.SetTile(cell,null);
            }

        }else{
            return;
        }
        
    }

}