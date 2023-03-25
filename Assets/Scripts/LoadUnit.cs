using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUnit : MonoBehaviour
{
    List<Unit> Load(){

        List<Unit> answer = new List<Unit>();

        string loadText = (Resources.Load("UnitData",typeof(TextAsset)) as TextAsset).text;
        string[] loadUnit = loadText.Split(char.Parse("\n"));

        for(int i = 0; i < loadUnit.Length; i++){

            string[] UnitData = loadUnit[i].Split(char.Parse(","));
            Unit unit = new Unit(UnitData);
            answer.Add(unit);

        }

        return answer;

    } 

}