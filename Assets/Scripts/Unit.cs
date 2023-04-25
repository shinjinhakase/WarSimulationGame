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
        this.team = data[1];
        foreach(UnitStatus us in usl.unitStatusList){
            if(us.getTeam() == this.team){
                maxHP = Random.Range(us.getMinHP(),us.getMaxHP());
                HP = maxHP;
                ATK = Random.Range(us.getMinATK(),us.getMaxATK());
            }
        }
        Position = new Vector3Int(
            int.Parse(data[2]),
            int.Parse(data[3]),
            0
        );
        isMoved = false;
    }

    public void setName(string newName){
        this.name = newName;
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
        foreach(Vector3Int ep in epl){
            if(calc.Distance(ep,this.Position) == reach){
                return tm.getUnit(ep);
            }
        }
        return null;
    }

    public int getHP(){
        return HP;
    }

    public int getATK(){
        return ATK;
    }

    public int getMaxHP(){
        return maxHP;
    }

    public void Damage(int damage){
        this.HP -= damage;
    }

}