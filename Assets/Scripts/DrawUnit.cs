using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DrawUnit : MonoBehaviour
{
    [SerializeField] Tilemap UnitMap;
    [SerializeField] List<Tile> UnitTileList;

    public void Draw(List<Unit> allUnits,TurnManager tmScript){
        foreach(Unit unit in allUnits){
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

}