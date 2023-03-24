using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    List<Unit> myUnits;
    string team;
    
    public Player(List<Unit> units,string team){
        myUnits = units;
        this.team = team;
    }

    public Unit getMyUnits(Vector3Int position){
        foreach(Unit unit in myUnits){
            if(unit.getPosition() == position){
                return unit;
            }
        }
        return null;
    }

    public string getName(){
        return team;
    }

    public bool isUnitExist(Vector3Int position){

        foreach(Unit unit in myUnits){
            if(unit.getPosition() == position){
                return true;
            }
        }

        return false;
        
    }

    public List<Unit> getAllUnits(){
        return myUnits;
    }

}
