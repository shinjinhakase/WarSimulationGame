using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create UnitStatus")]
public class UnitStatus : ScriptableObject
{
    public int minHP;
    public int maxHP;
    public int minATK;
    public int maxATK;
}
