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

    // Start is called before the first frame update
    void Start()
    {
        List<Unit> loadUnit = Load();

        moveScript = moveTest.GetComponent<Move>();

        for(int i = 0; i < maxX; i++){
            for(int j = 0; j < maxY; j++){

                groundMap.SetTile(new Vector3Int(i,j,0),ground);
                mapData[i,j] = "grass";

                if(loadUnit.Count > 0 
                && loadUnit[0].getPosition().x == i
                && loadUnit[0].getPosition().y == j){

                    unitData[i,j] = loadUnit[0];

                    switch(unitData[i,j].getTeam()){

                        case "villager":
                            unitMap.SetTile(new Vector3Int(i,j,0),villager);
                        break;
                        case "barbarian":
                            unitMap.SetTile(new Vector3Int(i,j,0),barbarian);
                        break;

                    }

                    loadUnit.RemoveAt(0);

                }

            }

        }

    }

    public List<Vector3Int> isMovableList(Vector3Int pickup){

        List<Vector3Int> MovableTileList = new List<Vector3Int>();

        for(int i = 0; i < maxX; i++){
            for(int j = 0; j < maxY; j++){

                int ManhattanDistance = Mathf.Abs(pickup.x - i) + Mathf.Abs(pickup.y - j);
                if(ManhattanDistance <= getUnitData(pickup).getSpeed()
                && groundMap.HasTile(new Vector3Int(i,j,0))
                && unitData[i,j] == null){
                    MovableTileList.Add(new Vector3Int(i,j,0));
                }

            }
        }
        
        return MovableTileList;

    }

}