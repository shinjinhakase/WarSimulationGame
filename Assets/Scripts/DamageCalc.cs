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
    
    public IEnumerator Attack(Unit attacker,Unit difender){
        yield return new WaitForSeconds(1);
        difender.Damage(attacker.getATK());
        if(difender.getHP() < 0){
            DeadUnit(difender);
        }else{
            yield return new WaitForSeconds(1);
            attacker.Damage(difender.getATK());
            if(attacker.getHP() < 0){
                DeadUnit(attacker);
            }
        }

    }

    public void DeadUnit(Unit deadUnit){
        charaSheet.SetTile(deadUnit.getPosition(),null);
        tm.getPlayer(deadUnit.getTeam()).DeadUnit(deadUnit);
    }

}