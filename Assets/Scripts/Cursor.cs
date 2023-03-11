using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Cursor : MonoBehaviour
{
    public Vector3Int init;
    
    [SerializeField] Tilemap cursorMap;
    [SerializeField] Tile cursorTile;

    // Start is called before the first frame update
    void Start()
    {
        cursorMap.SetTile(init,cursorTile);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
