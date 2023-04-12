using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Aster : MonoBehaviour
{

    [SerializeField] Tilemap groundMap;
    [SerializeField] Tilemap characterMap;
    [SerializeField] Vector3Int testVector;

    public void CallDebug(){
        List<Node> nodeList = NodeList();
        foreach(Node node in nodeList){
            if(testVector == node.getPosition()){
                node.Open(null,testVector);
                break;
            }
        }
    }

    public List<Node> NodeList(){

        List<Node> answer = new List<Node>();

        List<Vector3Int> nodePosition = NodePosition();
        foreach(Vector3Int position in nodePosition){
            Node node = new Node(position);
            answer.Add(node);
        }

        return answer;

    }

    List<Vector3Int> NodePosition(){

        List<Vector3Int> answer = new List<Vector3Int>();

        List<Vector3Int> ground = VectorList(groundMap);
        List<Vector3Int> someoneHere = VectorList(characterMap);
        
        foreach(Vector3Int pos in ground){
            bool flag = false;
            foreach(Vector3Int someone in someoneHere){
                if(someone == pos){
                    flag = true;
                    break;
                }
            }
            if(!flag){
                answer.Add(pos);
            }
        }

        return answer;

    }

    List<Vector3Int> VectorList(Tilemap targetMap){

        List<Vector3Int> answer = new List<Vector3Int>();

        foreach(var pos in targetMap.cellBounds.allPositionsWithin){

            Vector3Int cellPosition = new Vector3Int(pos.x,pos.y,pos.z);
            if(targetMap.HasTile(cellPosition)){
                answer.Add(cellPosition);
            }

        }

        return answer;

    }

}