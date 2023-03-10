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
    [SerializeField] GameObject Cursor;
    Cursor cursorScript;

    void Start(){

        mapData = MapData.GetComponent<Map>();
        dmtScript = DrawMovableTile.GetComponent<DrawMovableTile>();
        cursorScript = Cursor.GetComponent<Cursor>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)){

            Vector3Int touchPointCell = cursorScript.getCurrentPosition();
            
            if(charaSheet.HasTile(touchPointCell) && isSelected == false){
                
                isSelected = true;
                selectedChara = charaSheet.GetTile<Tile>(touchPointCell);
                selectedCharaPosition = touchPointCell;

                dmtScript.DrawTile(mapData.isMovableList(touchPointCell));

            }else{

                if(isSelected && movableMap.HasTile(touchPointCell)){

                    charaSheet.SetTile(selectedCharaPosition,null);
                    charaSheet.SetTile(touchPointCell,selectedChara);
                    mapData.MoveUnit(selectedCharaPosition,touchPointCell);
                    
                }

                dmtScript.DeleteTile(isSelected);
                isSelected = false;

            }

        }

    }

    public bool isUnitExist(int x,int y){

        Vector3Int searchPosition = new Vector3Int(x,y,0);
        return charaSheet.HasTile(searchPosition);

    }

}