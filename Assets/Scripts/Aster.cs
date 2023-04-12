using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Aster : MonoBehaviour
{

    [SerializeField] Tilemap groundMap;
    [SerializeField] Tilemap characterMap;
    [SerializeField] Vector3Int testVector;
    List<Node> nodeList;
    Vector3Int startPosition;

    public void CallDebug(){
        nodeList = NodeList();
        startPosition = testVector;
        FirstNodeOpen(startPosition);
        AroundNodeOpen(startPosition);
        foreach(Node node in OpenNodeList()){
            Debug.Log(node.getX() + "," + node.getY());
        }
    }

    void AroundNodeOpen(Vector3Int baseNodePosition){
        Vector3Int right = new Vector3Int(baseNodePosition.x + 1,baseNodePosition.y);
        if(pickupNode(right) != null){
            pickupNode(right).Open(pickupNode(baseNodePosition),startPosition);
        }
        Vector3Int left = new Vector3Int(baseNodePosition.x - 1,baseNodePosition.y);
        if(pickupNode(left) != null){
            pickupNode(left).Open(pickupNode(baseNodePosition),startPosition);
        }
        Vector3Int up = new Vector3Int(baseNodePosition.x,baseNodePosition.y + 1);
        if(pickupNode(up) != null){
            pickupNode(up).Open(pickupNode(baseNodePosition),startPosition);
        }
        Vector3Int down = new Vector3Int(baseNodePosition.x,baseNodePosition.y - 1);
        if(pickupNode(down) != null){
            pickupNode(down).Open(pickupNode(baseNodePosition),startPosition);
        }
    }

    void FirstNodeOpen(Vector3Int startPosition){
        foreach(Node node in nodeList){
            if(startPosition == node.getPosition()){
                node.Open(null,startPosition);
                return;
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

    Node pickupNode(Vector3Int pickup){
        foreach(Node node in nodeList){
            if(pickup == node.getPosition()){
                return node;
            }
        }
        return null;
    }

    List<Node> OpenNodeList(){
        List<Node> answer = new List<Node>();
        foreach(Node node in nodeList){
            if(node.isOpened()){
                answer.Add(node);
            }
        }
        return answer;
    }

}