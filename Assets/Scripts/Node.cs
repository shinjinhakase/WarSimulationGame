using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node{

    public enum Status {
        Nonw,
        Open,
        Closed
    };

    Vector3Int position;
    Status status;
    int cost;
    int manhattan;
    Node parent;

    public Node(Vector3Int position){
        this.position = position;
        this.status = Status.Nonw;
    }

    public void OpenNode(Node parent,Vector3Int startPosition){
        this.parent = parent;
        this.cost = parent.getScore() + 1;
        this.manhattan = CalcManhattan(this.position,startPosition);
        this.status = Status.Open;
    }

    int CalcManhattan(Vector3Int position,Vector3Int startPosition){
        return Mathf.Abs(position.x - startPosition.x) + Mathf.Abs(position.y - startPosition.y);
    }

    public int getScore(){
        return cost + manhattan;
    }

    public int getX(){
        return position.x;
    }

    public int getY(){
        return position.y;
    }

    public Vector3Int getPosition(){
        return position;
    }

    public bool isOpened(){
        if(status == Status.Nonw){
            return false;
        }
        return true;
    }

}