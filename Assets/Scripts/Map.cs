using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour{

    string[,] mapData = new string[6,11];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 6; i++){
            for(int j = 0; j < 11; j++){
                mapData[i,j] = "grass";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
