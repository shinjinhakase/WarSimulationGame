using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour{

    public int maxX;
    public int maxY;
    string[,] mapData;
    [SerializeField] Tilemap groundMap;
    [SerializeField] Tile ground;
    [SerializeField] Tilemap unitMap;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < maxX; i++){
            for(int j = 0; j < maxY; j++){
                groundMap.SetTile(new Vector3Int(i,j,0),ground);
                mapData[i,j] = "grass";
            }
        }
    }

    public List<Vector3Int> isMovableList(Unit moveUnit){

        List<Vector3Int> MovableTileList = new List<Vector3Int>();
        Vector3Int moveUnitPosition = moveUnit.getPosition();

        for(int i = 0; i < maxX; i++){
            for(int j = 0; j < maxY; j++){

                int ManhattanDistance = Mathf.Abs(moveUnitPosition.x - i) + Mathf.Abs(moveUnitPosition.y - j);
                if(ManhattanDistance <= moveUnit.getSpeed()
                && groundMap.HasTile(new Vector3Int(i,j,0))
                && !unitMap.HasTile(new Vector3Int(i,j,0))){
                    MovableTileList.Add(new Vector3Int(i,j,0));
                }

            }
        }
        
        return MovableTileList;

    }

}