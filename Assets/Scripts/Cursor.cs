using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Cursor : MonoBehaviour
{
    public Vector3Int init;
    Vector3Int currentPosition;
    [SerializeField] Tilemap cursorMap;
    [SerializeField] Tile cursorTile;

    // Start is called before the first frame update
    void Start()
    {
        cursorMap.SetTile(init,cursorTile);
        currentPosition = init;
        Vector3 v = transform.position;
        v.x = init.x;
        v.y = init.y;
        transform.position = v;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.UpArrow)){
            cursorMove(currentPosition,new Vector3Int(currentPosition.x,currentPosition.y + 1,0));
        }
        if(Input.GetKeyUp(KeyCode.DownArrow)){
            cursorMove(currentPosition,new Vector3Int(currentPosition.x,currentPosition.y - 1,0));
        }
        if(Input.GetKeyUp(KeyCode.RightArrow)){
            cursorMove(currentPosition,new Vector3Int(currentPosition.x + 1,currentPosition.y,0));
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow)){
            cursorMove(currentPosition,new Vector3Int(currentPosition.x - 1,currentPosition.y,0));
        }
    }

    void cursorMove(Vector3Int before,Vector3Int after){

        cursorMap.SetTile(before,null);
        cursorMap.SetTile(after,cursorTile);
        currentPosition = after;
        Vector3 v = transform.position;
        v.x = after.x;
        v.y = after.y;
        transform.position = v;

    }
}
