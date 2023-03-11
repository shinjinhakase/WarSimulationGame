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
    Map mapData;
    [SerializeField] GameObject DrawMovableTile;
    DrawMovableTile dmtScript;
    [SerializeField] Tilemap movableMap;

    void Start(){

        mapData = MapData.GetComponent<Map>();
        dmtScript = DrawMovableTile.GetComponent<DrawMovableTile>();

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

                //移動可能判定
                dmtScript.DrawTile(mapData.isMovableList(touchPointCell));

            }else{

                //条件を改修する
                if(isSelected && movableMap.HasTile(touchPointCell)){
                    charaSheet.SetTile(selectedCharaPosition,null);
                    charaSheet.SetTile(touchPointCell,selectedChara);
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