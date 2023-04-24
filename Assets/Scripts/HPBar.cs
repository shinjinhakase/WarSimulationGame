using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour{
    
    Unit myUnit;

    public void setUnit(Unit unit){
        this.myUnit = unit;
    }

    void Update(){
        if(myUnit != null){
            RectTransform position = this.GetComponent<RectTransform>();
            position.anchoredPosition = new Vector2(myUnit.getPosition().x,myUnit.getPosition().y);
        }
    }

}