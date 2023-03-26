using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit
{
    string name;
    int speed = 4;
    string team;
    Vector3Int Position;
    bool isMoved;

    public Unit(string[] data){
        this.name = data[0];
        this.team = data[1];
        Position = new Vector3Int(
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
        return Position;
    }

    public void Move(Vector3Int goal){
        Position = goal;
    }
    
    public void Moved(){
        isMoved = true;
    }

    public void resetMove(){
        isMoved = false;
    }

    public bool getMoved(){
        return isMoved;
    }

}