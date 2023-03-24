using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Move : MonoBehaviour
{
    
    bool isSelected = false;
    Tile selectedChara;
    Vector3Int beforePosition;
    Vector3Int afterPosition;
    [SerializeField] Tilemap map;
    [SerializeField] Tilemap charaSheet;
    [SerializeField] GameObject MapData;
    Map mapData;
    [SerializeField] GameObject DrawMovableTile;
    DrawMovableTile dmtScript;
    [SerializeField] Tilemap movableMap;
    [SerializeField] GameObject Cursor;
    Cursor cursorScript;
    [SerializeField] GameObject TurnManager;
    TurnManager tmScript;

    void Start(){

        mapData = MapData.GetComponent<Map>();
        dmtScript = DrawMovableTile.GetComponent<DrawMovableTile>();
        cursorScript = Cursor.GetComponent<Cursor>();
        tmScript = TurnManager.GetComponent<TurnManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)){
            Select();
        }
    }

    void Select(){

        Vector3Int touchPointCell = cursorScript.getCurrentPosition();
        
        if(isSelected == false && validTouch(touchPointCell)){
            
            isSelected = true;
            beforePosition = touchPointCell;

            dmtScript.DrawTile(mapData.isMovableList(beforePosition));

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

    bool validTouch(Vector3Int touchPointCell){

        string currentTurn = tmScript.getTurn();
        return tmScript.getPlayer(currentTurn).isUnitExist(touchPointCell);

    }

}