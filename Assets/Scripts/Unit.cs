using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit
{
    string name;
    int speed = 4;
    string team;
    Vector3Int initPosition;
    bool isMoved;

    public Unit(string[] data){
        this.name = data[0];
        this.team = data[1];
        initPosition = new Vector3Int(
            int.Parse(data[2]),
            int.Parse(data[3]),
            0
        );
        isMoved = false;
    }

    public string getName(){
        return name;
    }

    public int getSpeed(){
        return speed;
    }

    public string getTeam(){
        return team;
    }

    public Vector3Int getPosition(){
        return initPosition;
    }

    public Moved(){
        isMoved = true;
    }

    public resetMove(){
        isMoved = false;
    }

}