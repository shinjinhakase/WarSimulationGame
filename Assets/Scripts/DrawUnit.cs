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

    // Start is called before the first frame update
    void Start()
    {
        tmScript = TurnManager.GetComponent<TurnManager>();
    }

    public void getUnits(List<Player> playerList){

        arriveUnits.Clear();

        foreach(Player player in PlayerList){
            arriveUnits.Add(player.getAllUnits());
        }

    }

    public void Draw(){
        foreach(Unit unit in arriveUnits){
            Tile correctTile = UnitTileList[tmScript.NumberOfTeam(unit.getTeam())];
            Vector3Int drawPosition = unit.getPosition();
            UnitMap.SetTile(drawPosition,correctTile);
        }
    }

}