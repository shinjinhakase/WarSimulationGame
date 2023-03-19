using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    List<Unit> myUnits;
    
    public Player(List<Unit> units){
        myUnits = units;
    }

    public Unit getMyUnits(Vector3Int position){
        foreach(Unit unit in myUnits){
            if(unit.getPosition() == position){
                return unit;
            }
        }
        return null;
    }

}
