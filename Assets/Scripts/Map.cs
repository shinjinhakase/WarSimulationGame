using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour{

    string[,] mapData = new string[13,11];
    Unit[,] unitData = new Unit[13,11];
    [SerializeField] GameObject moveTest;
    Move moveScript;
    // Start is called before the first frame update
    void Start()
    {
        moveScript = moveTest.GetComponent<Move>();
        for(int i = 0; i < 13; i++){
            for(int j = 0; j < 11; j++){

                mapData[i,j] = "grass";

                if(moveScript.isUnitExist(i,j)){
                    unitData[i,j] = new Unit();
                }else{
                    unitData[i,j] = null;
                }

            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveUnit(Vector3Int before,Vector3Int after){

        Unit moveUnit = unitData[before.x,before.y];
        unitData[after.x,after.y] = moveUnit;
        unitData[before.x,before.y] = null;

    }

}
