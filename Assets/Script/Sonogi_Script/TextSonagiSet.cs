using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class korean_word{
    public int id;
    public string word;

    public korean_word(int id, string word){
        this.id = id;
        this.word = word;

    }


    public void printword(){
        Debug.Log(word);
    }
}

public class wordData{
    public List<korean_word> words;
}

public class TextSonagiSet : MonoBehaviour
{

    // 전달받을 시작점
    // 전달받을 끝날점
    private Transform startPos;
    private Transform endPos;

    private float lerpTime = 10f;      // 소나기가 떨어질속도
    private float currentTime = 0;

    public void setSonagiText(Transform startPos, Transform endPos){
        this.startPos = startPos;
        this.endPos = endPos;
    }

    private void Update() {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x, endPos.transform.position.y, gameObject.transform.position.z), Time.deltaTime * 15f);
    }

    // private static string savePath => Application.persistentDataPath + "/Json/";
    private void Start() {
        string filePath = Path.Combine(Application.persistentDataPath, "korean_word");
        string file = File.ReadAllText("C:/Users/NeTk_/Kiosk/Assets/Json/korean_word.json");

        wordData word = JsonUtility.FromJson<wordData>(file);
        foreach(korean_word kw in word.words){
            kw.printword();
        }
    }

}
