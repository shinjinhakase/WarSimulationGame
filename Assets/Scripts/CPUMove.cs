using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CPUMove : MonoBehaviour
{

    [SerializeField] Tilemap charaSheet;

    public void Move(Unit unit){
        Vector3Int goal = decideGoal(unit,unit.getNearestEnemy());
        Tile chara = (Tile)charaSheet.GetTile(unit.getPosition());
        charaSheet.SetTile(goal,chara);
        charaSheet.SetTile(unit.getPosition(),null);
        unit.Move(goal);
    }

    Vector3Int decideGoal(Unit unit,List<Vector3Int> route){
        Vector3Int answer;
        if(route.Count > unit.getSpeed()){
            answer = route[unit.getSpeed() - 1];
        }else if(route.Count == 0){
            return unit.getPosition();
        }else{
            answer = route[route.Count - 1];
        }
        return answer;
    }

}
