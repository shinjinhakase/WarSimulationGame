using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Godfather : MonoBehaviour
{
    public int people;
    List<string> littleChars = new List<string>(){"ャ","ュ","ョ","ァ","ィ","ゥ","ェ","ォ"};
    List<string> headInvalid = new List<string>(){"ー","ン","ッ"};
	void Start(){
        
        /*
        List<List<List<string>>> dataset = DataMoulding();
        string param = RandomParam(dataset);

        string path = Application.dataPath + "/Resources/dataset.txt";
        File.WriteAllText(path,param);
        */
        
        List<string> testNames = new List<string>();
        for(int i = 0; i < 100; i++){
            testNames.Add(GenerateName());
        }
        Debug.Log(string.Join("\n",testNames));

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

        for(int i = 0; i < 9; i++){
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

            int sum = 0;
            for(int j = 0; j < charList.Count; j++){
                sum += pList[j];
                answer += charList[j] + "," + pList[j].ToString() + "\n";
            }

            answer += "合計" + sum + "\n";

        }

        return answer;

    }

    string GenerateName(){
        
        string name = "";
        
        string loadText = (Resources.Load("dataset",typeof(TextAsset)) as TextAsset).text;
        string[] paramSplit = loadText.Split(char.Parse("\n"));
        int generateNameLength = Random.Range(2,8);
        string startStr = generateNameLength.ToString() + "文字の確率";
        List<int> probabList = new List<int>();
        List<string> probabLetter = new List<string>();
        bool loadFlag = false;
        int probabSum = 0;
        for(int i = 0; i < paramSplit.Length; i++){
            
            if(loadFlag){
                if(paramSplit[i].Contains("合計")){
                    probabSum = int.Parse(paramSplit[i].Replace("合計",""));
                    break;
                }
                probabLetter.Add((paramSplit[i].Split(char.Parse(",")))[0].ToString());
                probabList.Add(int.Parse((paramSplit[i].Split(char.Parse(",")))[1]));
            }
            if(startStr == paramSplit[i]){
                loadFlag = true;
            }

        }

        for(int i = 0; i < generateNameLength; i++){

            int decideLetter = Random.Range(0,probabSum);
            for(int j = 0; j < probabList.Count; j++){
                decideLetter -= probabList[j];
                if(decideLetter <= 0){
                    if(isValidName(name,probabLetter[j],(i == generateNameLength - 1))){
                        name += probabLetter[j];
                        break;
                    }else{
                        decideLetter = Random.Range(0,probabSum);
                        j = 0;
                        continue;
                    }
                }
            }

        }

        return name;

    }

    bool isValidName(string name,string addLetter,bool isLastLetter){

        
        if(name.Length == 0){
            if(headInvalid.Contains(addLetter)){
                return false;
            }
        }else if(name.Length >= 2){
            if(name[name.Length - 1].Equals(name[name.Length - 2]) && name[name.Length - 1].Equals(char.Parse(addLetter))){
                return false;
            }else if(headInvalid.Contains(name[name.Length - 1].ToString()) && headInvalid.Contains(addLetter)){
                return false;
            }
        }

        if(isLastLetter){
            if(addLetter.Equals("ッ")){
                return false;
            }
        }

        return true;

    }

}