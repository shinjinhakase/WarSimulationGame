using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    [SerializeField] GameObject Map;
    List<Player> playerList;
    [SerializeField] List<string> teamList;
    [SerializeField] GameObject LoadUnit;
    [SerializeField] GameObject DrawUnit;
    DrawUnit drawUnit;
    int turn;
    [SerializeField] GameObject cpuMove;
    CPUMove cpum;
    [SerializeField] GameObject aster;
    bool once;
    public float cooltime;
    [SerializeField] GameObject DamageCalc;
    [SerializeField] Text turnUnit;

    void Start(){
        playerList = new List<Player>();
        teamList = new List<string>();
        drawUnit = DrawUnit.GetComponent<DrawUnit>();
        InitSetUp();
    }

    void InitSetUp(){

        LoadUnit loadUnit = LoadUnit.GetComponent<LoadUnit>();
        List<Unit> loadUnitList = loadUnit.Load();

        foreach(Unit unit in loadUnitList){
            if(!teamList.Contains(unit.getTeam())){
                teamList.Add(unit.getTeam());
            }
        }

        foreach(string teamName in teamList){
            Player player = new Player(teamName,Map,this.GetComponent<TurnManager>());
            playerList.Add(player);
        }

        foreach(Unit unit in loadUnitList){
            unit.SetTM(this.GetComponent<TurnManager>(),aster.GetComponent<Aster>());
            getPlayer(unit.getTeam()).AddUnit(unit);
        }

        drawUnit.Draw(loadUnitList,this.GetComponent<TurnManager>());
        turn = 0;

    }

    void Update(){

        /*プレイヤーがいるときのみ使用
            if(Input.GetKeyUp(KeyCode.T)){
                if(turn < teamList.Count - 1){
                    turn++;
                }else{
                    turn = 0;
                }
                moveReset();
            }
        */

        if(Input.GetKeyUp(KeyCode.Space)){

            if(turn < teamList.Count - 1){
                turn++;
            }else{
                turn = 0;
            }

            once = false;

        }

        if(!once){
            once = true;
            cpum = cpuMove.GetComponent<CPUMove>();
            StartCoroutine(PlayerTest());
        }
        
    }

    
    IEnumerator PlayerTest(){
        DamageCalc DC = DamageCalc.GetComponent<DamageCalc>();
        DC.setTM(this.GetComponent<TurnManager>());
        foreach(Unit unit in playerList[turn].getAllUnits().ToList()){
            if(getUnit(unit.getPosition()) == null) continue;
            turnUnit.text = unit.getTeam() + "陣営/" +unit.getName() + "の戦術";
            if(unit.EnemyExistInReach() == null){
                cpum.Move(unit);
                if(unit.EnemyExistInReach() != null){
                    yield return StartCoroutine(DC.Attack(unit,unit.EnemyExistInReach()));
                }
            }else{
                yield return StartCoroutine(DC.Attack(unit,unit.EnemyExistInReach()));
            }
            yield return new WaitForSeconds(cooltime);
        }
    }

    public string getTurn(){
        return teamList[turn];
    }

    public Player getPlayer(string teamName){

        foreach(Player person in playerList){
            if(person.getName() == teamName){
                return person;
            }
        }

        return null;

    }

    public int NumberOfTeam(string teamName){

        for(int i = 0; i < teamList.Count; i++){
            if(teamList[i] == teamName){
                return i;
            }
        }

        return -1;

    }

    public Unit getUnit(Vector3Int position){
        foreach(Player player in playerList){
            if(player.getMyUnits(position) != null){
                return player.getMyUnits(position);
            }
        }
        return null;
    }

    void moveReset(){
        foreach(Unit unit in getPlayer(getTurn()).getAllUnits()){
            unit.resetMove();
        }
    }

    public List<Unit> getAllUnits(){
        List<Unit> answer = new List<Unit>();
        foreach(Player player in playerList){
            answer.AddRange(player.getAllUnits());
        }
        return answer;
    }
    
    public List<Vector3Int> EnemyPositionList(string friend){
        List<Vector3Int> answer = new List<Vector3Int>();
        List<Unit> allUnits = getAllUnits();
        foreach(Unit unit in allUnits){
            if(unit.getTeam() != friend){
                answer.Add(unit.getPosition());
            }
        }
        return answer;
    }

}