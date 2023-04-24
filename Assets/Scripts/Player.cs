using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    List<Unit> myUnits;
    string team;
    GameObject map;
    TurnManager tm;
    
    public Player(string team,GameObject map,TurnManager tm){
        this.team = team;
        myUnits = new List<Unit>();
        this.map = map;
        this.tm = tm;
    }

    public void AddUnit(Unit unit){
        myUnits.Add(unit);
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

    public void DeadUnit(Unit unit){
        for(int i = 0; i < myUnits.Count; i++){
            if(unit.getPosition() == myUnits[i].getPosition()){
                myUnits.RemoveAt(i);
                return;
            }
        }
    }

}
