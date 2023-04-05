using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create UnitStatusList")]
public class UnitStatusList : ScriptableObject
{
    public List<UnitStatus> unitStatusList;
}
