using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    Player player,cpu;
    
    enum Turn{
        villager,
        barbarian
    };

    Turn turn;
    
    public void SetUp(List<Unit> playerUnits,List<Unit> cpuUnits){

        player = new Player(playerUnits);
        cpu = new Player(cpuUnits);
        turn = Turn.villager;

    }

}