using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour{

    string mapData = new String[6,11];
    // Start is called before the first frame update
    void Start()
    {
        foreach(var data in mapData)
        {
            data = "grass";    
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
