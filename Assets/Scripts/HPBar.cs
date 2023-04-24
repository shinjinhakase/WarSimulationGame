using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour{
    
    Unit myUnit;
    Slider bar;

    public void setUnit(Unit unit){
        this.myUnit = unit;
        bar = this.GetComponent<Slider>();
        bar.maxValue = myUnit.getMaxHP();
    }

    void Update(){
        if(myUnit != null){
            RectTransform position = this.GetComponent<RectTransform>();
            position.anchoredPosition = new Vector2(myUnit.getPosition().x,myUnit.getPosition().y);
            bar.value = myUnit.getHP();
        }
        if(myUnit.getHP() < 0){
            Destroy(this.gameObject);
        }
    }

}