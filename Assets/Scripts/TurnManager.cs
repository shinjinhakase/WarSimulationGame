using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] GameObject Map;
    Map mapData;
    List<Player> playerList;

    enum Turn{
        villager,
        barbarian
    };

    Turn turn;

    void Start(){
        mapData = Map.GetComponent<Map>();
    }
    
    public void SetUp(List<Unit> playerUnits,List<Unit> cpuUnits){

        turn = Turn.villager;
        playerList.Add(new Player(playerUnits,"villager"));
        playerList.Add(new Player(cpuUnits,"barbarian"));

    }

    void Update(){

        if(Input.GetKeyUp(KeyCode.T)){
            if(turn == Turn.villager){
                turn = Turn.barbarian;
                mapData.newTurn("barbarian");
            }else{
                turn = Turn.villager;
                mapData.newTurn("villager");
            }
        }
        
    }

    public string getTurn(){
        return turn.ToString();
    }

    public Player getPlayer(string teamName){

        foreach(Player person in playerList){
            if(person.getName() == teamName){
                return person;
            }
        }

        return null;

    }

}