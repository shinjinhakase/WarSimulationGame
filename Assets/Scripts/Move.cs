using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Move : MonoBehaviour
{
    
    bool isSelected　= false;
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
                Debug.Log("選択された");
            }else{
                isSelected = false;
                Debug.Log("選択解除");
            }

        }

    }

}