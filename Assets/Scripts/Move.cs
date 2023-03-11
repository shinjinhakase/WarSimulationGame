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
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){

            Vector3 touchPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var touchPointCell = map.WorldToCell(touchPoint);
            
            if(charaSheet.HasTile(new Vector3Int(touchPointCell.x,touchPointCell.y,0))){
                
                isSelected = true;
                selectedChara = charaSheet.GetTile<Tile>(touchPointCell);
                selectedCharaPosition = new Vector3Int(touchPointCell.x,touchPointCell.y,0);

            }else{

                if(isSelected){
                    charaSheet.SetTile(selectedCharaPosition,null);
                    charaSheet.SetTile(touchPointCell,selectedChara);
                }
                isSelected = false;

            }

        }

    }

}