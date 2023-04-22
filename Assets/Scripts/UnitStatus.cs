using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create UnitStatus")]
public class UnitStatus : ScriptableObject
{
    public string team;
    public int minHP;
    public int maxHP;
    public int minATK;
    public int maxATK;

    public string getTeam(){
        return team;
    }

    public int getMinHP(){
        return minHP;
    }

    public int getMaxHP(){
        return maxHP;
    }

    public int getMaxATK(){
        return maxATK;
    }

    public int getMinATK(){
        return minATK;
    }

}