using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalc : MonoBehaviour {

    public void Attack(Unit attacker,Unit difender){
        difender.Damage(attacker.getATK());Debug.Log(attacker.getName() + "が" + difender.getName() + "に攻撃 " + difender.getHP() + "/" + difender.getMaxHP());
        if(difender.getHP() < 0){
            Debug.Log(difender.getName() + "は息絶えた!");
            return;
        }else{
            StartCoroutine(wait());
            attacker.Damage(difender.getATK());Debug.Log(difender.getName() + "が" + attacker.getName() + "に反撃 " + attacker.getHP() + "/" + attacker.getMaxHP());
            if(attacker.getHP() < 0){
                Debug.Log(attacker.getName() + "は息絶えた!");
            }
        }

    }

    IEnumerator wait(){
        yield return new WaitForSeconds(1);
    }

}