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
    TextAsset textAsset;
    [SerializeField] Tilemap unitMap;
    [SerializeField] Tile villager;
    [SerializeField] Tile barbarian;
    [SerializeField] GameObject PlayerManager;
    PlayerManager pmScript;

    // Start is called before the first frame update
    void Start()
    {
        List<Unit> loadUnit = Load();
        
        mapData = new string[maxX,maxY];
        unitData = new Unit[maxX,maxY];
        moveScript = moveTest.GetComponent<Move>();
        pmScript = PlayerManager.GetComponent<PlayerManager>();

        List<Unit> playerUnits=new List<Unit>();
        List<Unit> cpuUnits = new List<Unit>();
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
                            playerUnits.Add(unitData[i,j]);
                            unitMap.SetTile(new Vector3Int(i,j,0),villager);
                        break;
                        case "barbarian":
                            cpuUnits.Add(unitData[i,j]);
                            unitMap.SetTile(new Vector3Int(i,j,0),barbarian);
                        break;

                    }

                    loadUnit.RemoveAt(0);

                }

            }

            pmScript.SetUp(playerUnits,cpuUnits);

        }

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
                if(ManhattanDistance <= getUnitData(pickup).getSpeed()
                && groundMap.HasTile(new Vector3Int(i,j,0))
                && unitData[i,j] == null){
                    MovableTileList.Add(new Vector3Int(i,j,0));
                }

            }
        }
        
        return MovableTileList;

    }

    List<Unit> Load(){

        List<Unit> answer = new List<Unit>();

        string loadText = (Resources.Load("UnitData",typeof(TextAsset)) as TextAsset).text;
        string[] loadUnit = loadText.Split(char.Parse("\n"));

        for(int i = 0; i < loadUnit.Length; i++){

            string[] UnitData = loadUnit[i].Split(char.Parse(","));
            Unit unit = new Unit(UnitData);
            answer.Add(unit);

        }

        return answer;

    }

}