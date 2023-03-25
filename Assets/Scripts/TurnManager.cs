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
    

    int turn;

    void Start(){
        mapData = Map.GetComponent<Map>();
        playerList = new List<Player>();
        teamList = new List<string>();
        InitSetUp();
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
            getPlayer(unit.getTeam()).AddUnit(unit);
        }

        turn = 0;

    }

    void Update(){

        if(Input.GetKeyUp(KeyCode.T)){
            if(turn < teamList.Count - 1){
                turn++;
            }else{
                turn = 0;
            }
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
            if(name == teamName){
                return i;
            }
        }

        return -1;

    }

    public Unit getUnit(Vector3Int position){
        return getPlayer(getTurn()).getMyUnits(position);
    } 

}