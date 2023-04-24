using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadUnit : MonoBehaviour
{
    [SerializeField] UnitStatusList usl;
    [SerializeField] Slider HPBar;
    [SerializeField] Canvas canvas;
    
    public List<Unit> Load(){

        List<Unit> answer = new List<Unit>();

        string loadText = (Resources.Load("UnitData",typeof(TextAsset)) as TextAsset).text;
        string[] loadUnit = loadText.Split(char.Parse("\n"));

        for(int i = 0; i < loadUnit.Length; i++){

            string[] UnitData = loadUnit[i].Split(char.Parse(","));
            Unit unit = new Unit(UnitData,usl);
            Slider hpbar = Instantiate(HPBar,canvas.transform);
            hpbar.GetComponent<HPBar>().setUnit(unit);
            answer.Add(unit);

        }

        return answer;

    }

}