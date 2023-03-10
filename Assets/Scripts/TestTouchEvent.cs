using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTouchEvent : MonoBehaviour
{
    
    Vector2 touchPoint;
    // Start is called before the first frame update
    void Start()
    {
        touchPoint = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            touchPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(touchPoint.x + "," + touchPoint.y);
        }
    }
}
