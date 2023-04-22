using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit
{
    string name;
    int speed = 4;
    int reach = 1;
    string team;
    Vector3Int Position;
    bool isMoved;
    int maxHP;
    int HP;
    int ATK;
    TurnManager tm;
    Aster aster;

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

    public int getreach(){
        return reach;
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

    public void SetTM(TurnManager tm,Aster aster){
        this.tm = tm;
        this.aster = aster;
    }

    public List<Vector3Int> getNearestEnemy(){
        List<Vector3Int> routeNearestEnemy = null;
        List<Vector3Int> epl = tm.EnemyPositionList(this.team);
        foreach(Vector3Int ep in epl){
            List<Vector3Int> routeEp = aster.Route(Position,ep);
            if(routeNearestEnemy == null || routeEp.Count < routeNearestEnemy.Count){
                routeNearestEnemy = routeEp;
            }
        }
        return routeNearestEnemy;
    }

    public Unit EnemyExistInReach(){
        List<Vector3Int> epl = tm.EnemyPositionList(this.team);
        Manhattan calc = new Manhattan();
        foreach(Vector3Int ep in epl){Debug.Log(this.name + " distance " + tm.getUnit(ep).getName() + " " + calc.Distance(ep,this.Position));
            if(calc.Distance(ep,this.Position) == reach){
                return tm.getUnit(ep);
            }
        }
        return null;
    }

}