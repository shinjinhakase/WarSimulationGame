using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DamageCalc : MonoBehaviour {

    TurnManager tm;
    [SerializeField] Tilemap charaSheet;

    public void setTM(TurnManager tm){
        this.tm = tm;
    }
    
    public void Attack(Unit attacker,Unit difender){
        difender.Damage(attacker.getATK());
        if(difender.getHP() < 0){
            Debug.Log(difender.getName() + "は息絶えた!");
            DeadUnit(difender);
            return;
        }else{
            StartCoroutine(wait());
            attacker.Damage(difender.getATK());
            if(attacker.getHP() < 0){
                Debug.Log(attacker.getName() + "は息絶えた!");
                DeadUnit(attacker);
            }
        }

    }

    public void DeadUnit(Unit deadUnit){
        charaSheet.SetTile(deadUnit.getPosition(),null);
        tm.getPlayer(deadUnit.getTeam()).DeadUnit(deadUnit);
    }

    IEnumerator wait(){
        yield return new WaitForSeconds(1);
    }

}