using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    Player player,cpu;
    [SerializeField] GameObject Map;
    Map mapData;
    enum Turn{
        villager,
        barbarian
    };

    Turn turn;

    void Start(){
        mapData = Map.GetComponent<Map>();
    }
    
    public void SetUp(List<Unit> playerUnits,List<Unit> cpuUnits){

        player = new Player(playerUnits);
        cpu = new Player(cpuUnits);
        turn = Turn.villager;

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

}