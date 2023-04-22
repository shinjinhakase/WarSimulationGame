using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Aster : MonoBehaviour
{

    [SerializeField] Tilemap groundMap;
    [SerializeField] Tilemap characterMap;
    List<Node> nodeList;
    Vector3Int startPosition;
    Vector3Int goalPosition;
    Node startPositionNode;
    Node goalPositionNode;

    public void NodeSetUp(){
        this.nodeList = NodeList();
    }

    public List<Vector3Int> Route(Vector3Int start,Vector3Int goal){
        NodeSetUp();
        startPosition = start;
        goalPosition = NormalizeGoal(goal);
        startPositionNode = new Node(startPosition);
        goalPositionNode = new Node(goalPosition);
        AroundNodeOpen(startPosition);
        startPositionNode.Close();
        nodeList.Add(goalPositionNode);
        return goalNode().Route(new List<Vector3Int>());
    }

    Vector3Int NormalizeGoal(Vector3Int trueGoal){
        Vector3Int answer = trueGoal;
        foreach(Node node in nodeList){
            int ManhattanDistance = Mathf.Abs(trueGoal.x - node.getPosition().x) + Mathf.Abs(trueGoal.y - node.getPosition().y);
            if(answer == trueGoal || ManhattanDistance == 1){
                answer = node.getPosition();
            }
        }
        return answer;
    }

    Node goalNode(){

        List<Node> openNodeList = OpenNodeList();
        foreach(Node node in openNodeList){
            if(node.getPosition() == goalPosition){
                return node;
            }
        }

        Node nextBaseNode = null;
        foreach(Node node in openNodeList){
            if(nextBaseNode == null){
                nextBaseNode = node;
            }
            if(node.getScore() < nextBaseNode.getScore()){
                nextBaseNode = node;
            }
        }
        AroundNodeOpen(nextBaseNode.getPosition());
        return goalNode();

    }

    void AroundNodeOpen(Vector3Int baseNodePosition){
        Vector3Int right = new Vector3Int(baseNodePosition.x + 1,baseNodePosition.y);
        if(pickupNode(right) != null && pickupNode(right).isOpened() == false){
            pickupNode(right).Open(pickupNode(baseNodePosition),startPosition);
        }
        Vector3Int left = new Vector3Int(baseNodePosition.x - 1,baseNodePosition.y);
        if(pickupNode(left) != null && pickupNode(left).isOpened() == false){
            pickupNode(left).Open(pickupNode(baseNodePosition),startPosition);
        }
        Vector3Int up = new Vector3Int(baseNodePosition.x,baseNodePosition.y + 1);
        if(pickupNode(up) != null && pickupNode(up).isOpened() == false){
            pickupNode(up).Open(pickupNode(baseNodePosition),startPosition);
        }
        Vector3Int down = new Vector3Int(baseNodePosition.x,baseNodePosition.y - 1);
        if(pickupNode(down) != null && pickupNode(down).isOpened() == false){
            pickupNode(down).Open(pickupNode(baseNodePosition),startPosition);
        }
        if(pickupNode(baseNodePosition) != null){
            pickupNode(baseNodePosition).Close();
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
            if(node.isOpenNow()){
                answer.Add(node);
            }
        }
        return answer;
    }

}