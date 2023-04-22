using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manhattan{
    
    public int Distance(Vector3Int a,Vector3Int b){
        int x = Mathf.Abs(a.x - b.x);
        int y = Mathf.Abs(a.y - b.y);
        return x + y;
    }
    
}