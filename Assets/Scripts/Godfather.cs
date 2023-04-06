using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Godfather : MonoBehaviour
{
    public int people;
    List<string> littleChars = new List<string>(){"ャ","ュ","ョ","ァ","ィ","ゥ","ェ","ォ"};
	void Start(){
        
        List<List<List<string>>> dataset = DataMoulding();
        Debug.Log(RandomParam(dataset));

    }

    void SimpleGenerate(){

        List<int> nameLengthList = new List<int>();
		for(int i = 0; i < people; i++){
			nameLengthList.Add(Random.Range(2,8));
		}
		
		string plane = "アイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワンー" ;
		List<string> chars = new List<string>();
		for(int i = 0; i < plane.Length; i++){
			chars.Add(plane[i].ToString());
		}
		
		foreach(int nameLength in nameLengthList){
			string name = "";
			int nameGenerateLength = 0;
			while(nameGenerateLength < nameLength){
				string nextChar = chars[Random.Range(0,chars.Count)];
				if(nextChar == "ー" || nextChar == "ン"){
			    	nextChar = "";
		        }
				if(nextChar.Length == 1){
					name += nextChar;
					nameGenerateLength++;
				}
				
			}
		}

    }

    List<string> Load(string assetName){

        string loadText = (Resources.Load(assetName,typeof(TextAsset)) as TextAsset).text;
        string[] loadTextLine = loadText.Split(char.Parse("\n"));

        List<string> loadTextList = new List<string>();
        for(int i = 0; i < loadTextLine.Length; i++){
            loadTextList.Add(loadTextLine[i]);
        }

        return loadTextList;

    }

    List<string> SplitName(string nameOrigin){

        List<string> answer = new List<string>();
        int originLength = nameOrigin.Length - 1;
        
        while(originLength >= 0){

            string oneLetter = nameOrigin[originLength].ToString();

            if(littleChars.Contains(oneLetter)){
                oneLetter = nameOrigin[originLength - 1].ToString() + oneLetter;
                originLength--;
            }

            answer.Add(oneLetter);
            originLength--;

        }

        answer.Reverse();
        return answer;

    }

    List<List<string>> NameLengthList(int nameLength,List<List<string>> nameList){

        nameLength++;
        List<List<string>> answer = new List<List<string>>();

        for(int i = 0; i < nameList.Count; i++){
            if(nameList[i].Count == nameLength){
                answer.Add(nameList[i]);
            }
        }

        return answer;

    }

    List<List<List<string>>> DataMoulding(){

        List<List<List<string>>> answer = new List<List<List<string>>>();
        List<string> loadTextList = Load("NameManEnglish");

        List<List<string>> nameList = new List<List<string>>();
        for(int i = 0; i < loadTextList.Count; i++){
            nameList.Add(SplitName(loadTextList[i]));
        }

        for(int i = 0; i < 8; i++){
            List<List<string>> nameLength = NameLengthList(i,nameList);
            answer.Add(nameLength);
        }

        return answer;

    }

    string RandomParam(List<List<List<string>>> dataset){

        string answer = "";

        for(int i = 0; i < dataset.Count; i++){
            List<string> charList = new List<string>();
            List<int> pList = new List<int>();
            answer += i.ToString() + "文字の確率\n";

            for(int j = 0; j < dataset[i].Count; j++){
                for(int k = 0; k < dataset[i][j].Count - 1; k++){
                    if(!charList.Contains(dataset[i][j][k])){
                        charList.Add(dataset[i][j][k]);
                    }
                }
            }

            for(int j = 0; j < charList.Count; j++){
                pList.Add(0);
            }

            for(int j = 0; j < dataset[i].Count; j++){
                for(int k = 0; k < dataset[i][j].Count; k++){
                    for(int l = 0; l < charList.Count; l++){
                        if(charList[l] == dataset[i][j][k]){
                            pList[l]++;
                        }
                    }
                }
            }

            for(int j = 0; j < charList.Count; j++){
                answer += charList[j] + "," + pList[j].ToString() + "\n";
            }

            answer += "\n";

        }

        return answer;

    }

}