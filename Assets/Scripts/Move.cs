using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Move : MonoBehaviour
{
    
    bool isSelected = false;
    Tile selectedChara;
    Vector3Int selectedCharaPosition;
    [SerializeField] Tilemap map;
    [SerializeField] Tilemap charaSheet;
    [SerializeField] GameObject MapData;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){

            Vector3 touchPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int touchPointCell = new Vector3Int(map.WorldToCell(touchPoint).x,map.WorldToCell(touchPoint).y,0);
            
            if(charaSheet.HasTile(touchPointCell)){
                
                isSelected = true;
                selectedChara = charaSheet.GetTile<Tile>(touchPointCell);
                selectedCharaPosition = touchPointCell;

            }else{

                if(isSelected){
                    charaSheet.SetTile(selectedCharaPosition,null);
                    charaSheet.SetTile(touchPointCell,selectedChara);
                    Map mapData = MapData.GetComponent<Map>();
                    mapData.MoveUnit(selectedCharaPosition,touchPointCell);
                }
                isSelected = false;

            }

        }

    }

    public bool isUnitExist(int x,int y){

        Vector3Int searchPosition = new Vector3Int(x,y,0);
        return charaSheet.HasTile(searchPosition);

    }

}