using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] GameObject Map;
    Map mapData;
    List<Player> playerList;
    [SerializeField] List<string> teamList;

    int turn;

    void Start(){
        mapData = Map.GetComponent<Map>();
        turn = 0;
    }
    
    public void SetUp(List<Unit> playerUnits,List<Unit> cpuUnits){

        playerList.Add(new Player(playerUnits,"villager"));
        playerList.Add(new Player(cpuUnits,"barbarian"));

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