using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestTouchEvent : MonoBehaviour
{
    
    Vector3 touchPoint;
    [SerializeField] Tilemap map;
    // Start is called before the first frame update
    void Start()
    {
        touchPoint = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            touchPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var getTile = map.WorldToCell(touchPoint);
            Debug.Log(getTile.x + "," + getTile.y);
        }
    }
}
