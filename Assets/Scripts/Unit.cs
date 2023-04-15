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
    int maxHP;
    int HP;
    int ATK;
    TurnManager tm;

    public Unit(string[] data,UnitStatusList usl){
        this.name = data[0];
        this.team = data[1];
        foreach(UnitStatus us in usl.unitStatusList){
            if(us.team == this.team){
                maxHP = Random.Range(us.minHP,us.maxHP);
                HP = maxHP;
                ATK = Random.Range(us.minATK,us.maxATK);
            }
        }
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

    public void SetTM(TurnManager tm){
        this.tm = tm;
        tm.ReferenceTest();
    }

}