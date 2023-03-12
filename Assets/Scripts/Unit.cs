using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit
{
    int speed = 4;
    string team;

    public Unit(string team){
        this.team = team;
    }

    public int getSpeed(){
        return speed;
    }

    public string getTeam(){
        return team;
    }

}