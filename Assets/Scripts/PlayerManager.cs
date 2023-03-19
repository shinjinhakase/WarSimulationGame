using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Player player,cpu;
    
    public void SetUp(List<Unit> playerUnits,List<Unit> cpuUnits){

        player = new Player(playerUnits);
        cpu = new Player(cpuUnits);

    }

}