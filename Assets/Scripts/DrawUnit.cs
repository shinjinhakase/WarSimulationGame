using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DrawUnit : MonoBehaviour
{
    
    [SerializeField] GameObject TurnManager;
    TurnManager tmScript;
    [SerializeField] Tilemap UnitMap;
    [SerializeField] List<Tile> UnitTileList; 
    List<Unit> arriveUnits;
    
    TextAsset textAsset;

    // Start is called before the first frame update
    void Start()
    {
        tmScript = TurnManager.GetComponent<TurnManager>();
    }

    public void getUnits(List<Player> playerList){

        arriveUnits.Clear();

        foreach(Player player in playerList){
            arriveUnits.AddRange(player.getAllUnits());
        }

    }

    public void Draw(){
        foreach(Unit unit in arriveUnits){
            Tile correctTile = UnitTileList[tmScript.NumberOfTeam(unit.getTeam())];
            Vector3Int drawPosition = unit.getPosition();
            UnitMap.SetTile(drawPosition,correctTile);
        }
    }

    public void DrawMove(Vector3Int beforePosition,Vector3Int afterPosition){
        Tile MoveTile = (Tile)UnitMap.GetTile(beforePosition);
        UnitMap.SetTile(afterPosition,MoveTile);
        UnitMap.SetTile(beforePosition,null);
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