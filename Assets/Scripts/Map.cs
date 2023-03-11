using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour{

    public int maxX;
    public int maxY;
    string[,] mapData;
    Unit[,] unitData;
    [SerializeField] Tilemap groundMap;
    [SerializeField] Tile ground;
    [SerializeField] GameObject moveTest;
    Move moveScript;

    // Start is called before the first frame update
    void Start()
    {
        
        mapData = new string[maxX,maxY];
        unitData = new Unit[maxX,maxY];
        moveScript = moveTest.GetComponent<Move>();
        for(int i = 0; i < maxX; i++){
            for(int j = 0; j < maxY; j++){

                groundMap.SetTile(new Vector3Int(i,j,0),ground);
                
                mapData[i,j] = "grass";

                if(moveScript.isUnitExist(i,j)){
                    unitData[i,j] = new Unit();
                }else{
                    unitData[i,j] = null;
                }

            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveUnit(Vector3Int before,Vector3Int after){

        Unit moveUnit = unitData[before.x,before.y];
        unitData[after.x,after.y] = moveUnit;
        unitData[before.x,before.y] = null;

    }

    public Unit getUnitData(Vector3Int position){
        return unitData[position.x,position.y];
    }

    public List<Vector3Int> isMovableList(Vector3Int pickup){

        List<Vector3Int> MovableTileList = new List<Vector3Int>();

        for(int i = 0; i < maxX; i++){
            for(int j = 0; j < maxY; j++){

                int ManhattanDistance = Mathf.Abs(pickup.x - i) + Mathf.Abs(pickup.y - j);
                if((ManhattanDistance <= getUnitData(pickup).getSpeed())&&(groundMap.HasTile(new Vector3Int(i,j,0)))){
                    MovableTileList.Add(new Vector3Int(i,j,0));
                }

            }
        }
        
        return MovableTileList;

    }

}
