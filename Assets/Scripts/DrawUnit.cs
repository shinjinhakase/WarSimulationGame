using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DrawUnit : MonoBehaviour
{
    
    [SerializeField] GameObject TurnManager;
    TurnManager tmScript;
    List<Unit> arriveUnits;

    // Start is called before the first frame update
    void Start()
    {
        tmScript = TurnManager.GetComponent<TurnManager>();
    }

    public void getUnits(List<Player> playerList){

        arriveUnits.Clear();

        foreach(Player player in PlayerList){
            arriveUnits.Add(player.getAllUnits());
        }
        
    }
}
