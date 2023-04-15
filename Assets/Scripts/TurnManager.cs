using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] GameObject Map;
    Map mapData;
    List<Player> playerList;
    [SerializeField] List<string> teamList;
    [SerializeField] GameObject LoadUnit;
    [SerializeField] GameObject DrawUnit;
    DrawUnit drawUnit;
    int turn;
    [SerializeField] GameObject aster;

    void Start(){
        mapData = Map.GetComponent<Map>();
        playerList = new List<Player>();
        teamList = new List<string>();
        drawUnit = DrawUnit.GetComponent<DrawUnit>();
        InitSetUp();
        foreach(Unit unit in getAllUnits()){
            unit.getNearestEnemyTest();
        }
    }

    void InitSetUp(){

        LoadUnit loadUnit = LoadUnit.GetComponent<LoadUnit>();
        List<Unit> loadUnitList = loadUnit.Load();

        foreach(Unit unit in loadUnitList){
            if(!teamList.Contains(unit.getTeam())){
                teamList.Add(unit.getTeam());
            }
        }

        foreach(string teamName in teamList){
            Player player = new Player(teamName);
            playerList.Add(player);
        }

        foreach(Unit unit in loadUnitList){
            unit.SetTM(this.GetComponent<TurnManager>(),aster.GetComponent<Aster>());
            getPlayer(unit.getTeam()).AddUnit(unit);
        }

        drawUnit.Draw(loadUnitList,this.GetComponent<TurnManager>());
        aster.GetComponent<Aster>().NodeSetUp();
        turn = 0;

    }

    void Update(){

        if(Input.GetKeyUp(KeyCode.T)){
            if(turn < teamList.Count - 1){
                turn++;
            }else{
                turn = 0;
            }
            moveReset();
        }
        
    }

    public string getTurn(){
        return teamList[turn];
    }

    public Player getPlayer(string teamName){

        foreach(Player person in playerList){
            if(person.getName() == teamName){
                return person;
            }
        }

        return null;

    }

    public int NumberOfTeam(string teamName){

        for(int i = 0; i < teamList.Count; i++){
            if(teamList[i] == teamName){
                return i;
            }
        }

        return -1;

    }

    public Unit getUnit(Vector3Int position){
        return getPlayer(getTurn()).getMyUnits(position);
    }

    void moveReset(){
        foreach(Unit unit in getPlayer(getTurn()).getAllUnits()){
            unit.resetMove();
        }
    }

    public List<Unit> getAllUnits(){
        List<Unit> answer = new List<Unit>();
        foreach(Player player in playerList){
            answer.AddRange(player.getAllUnits());
        }
        return answer;
    }
    
    public List<Vector3Int> EnemyPositionList(string friend){
        List<Vector3Int> answer = new List<Vector3Int>();
        List<Unit> allUnits = getAllUnits();
        foreach(Unit unit in allUnits){
            if(unit.getTeam() != friend){
                answer.Add(unit.getPosition());
            }
        }
        return answer;
    }

}