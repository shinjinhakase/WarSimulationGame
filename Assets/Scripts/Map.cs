using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour{

    string[,] mapData = new string[10,9];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++){
            for(int j = 0; j < 9; j++){
                mapData[i,j] = "grass";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
