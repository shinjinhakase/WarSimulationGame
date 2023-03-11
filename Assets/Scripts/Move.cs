using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Move : MonoBehaviour
{
    
    bool isSelected;
    [SerializeField] Tilemap map;
    [SerializeField] Tilemap charaSheet;
    
    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){

            Vector3 touchPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var getTile = map.WorldToCell(touchPoint);
            
            var selectedChara = charaSheet.GetTile(new Vector3Int(getTile.x,getTile.y,0));
            if(selectedChara == null){
                if(isSelected == true){
                    Debug.Log("移動先" + getTile.x + "," + getTile.y);
                }
                isSelected = false;
            }else if(isSelected == false){
                isSelected = true;
            }

        }

    }

}