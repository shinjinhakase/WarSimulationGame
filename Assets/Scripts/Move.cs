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
    [SerializeField] GameObject DrawUnit;
    DrawUnit duScript;
    [SerializeField] GameObject DrawMovableTile;
    DrawMovableTile dmtScript;
    [SerializeField] Tilemap movableMap;
    [SerializeField] GameObject Cursor;
    Cursor cursorScript;
    [SerializeField] GameObject TurnManager;
    TurnManager tmScript;
    [SerializeField] GameObject SelectUI;
    ActionSelectUI asuiScript;

    void Start(){

        dmtScript = DrawMovableTile.GetComponent<DrawMovableTile>();
        cursorScript = Cursor.GetComponent<Cursor>();
        tmScript = TurnManager.GetComponent<TurnManager>();
        duScript = DrawUnit.GetComponent<DrawUnit>();
        asuiScript = SelectUI.GetComponent<ActionSelectUI>();

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

            dmtScript.DrawTile(tmScript.getUnit(touchPointCell));

        }else{

            if(asuiScript.IsOpen()){
                
                dmtScript.DeleteTile(isSelected);
                isSelected = false;
                asuiScript.Invisible();
                
            }
            
            if(isSelected && movableMap.HasTile(touchPointCell)){

                afterPosition = touchPointCell;
                tmScript.getUnit(beforePosition).Move(afterPosition);
                duScript.DrawMove(beforePosition,afterPosition);
                asuiScript.Visible();
                tmScript.getUnit(afterPosition).Moved();
                
            }


        }
    }

    bool validTouch(Vector3Int touchPointCell){
        string currentTurn = tmScript.getTurn();
        if(tmScript.getPlayer(currentTurn).isUnitExist(touchPointCell)){
            if(!tmScript.getUnit(touchPointCell).getMoved()){
                return true;
            }
        }
        return false;
    }

}