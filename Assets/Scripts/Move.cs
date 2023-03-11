using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Move : MonoBehaviour
{
    
    Vector3 touchPoint;
    [SerializeField] Tilemap map;
    [SerializeField] Tilemap charaSheet;
    
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
            
            var selectedChara = charaSheet.GetTile(new Vector3Int(getTile.x,getTile.y,0));
            if(selectedChara != null){
                Debug.Log("選択された");
            }
        }
    }
}
