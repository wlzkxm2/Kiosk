using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class user_ScoreManager : MonoBehaviour
{
    // [SerializeField] private TextMeshProUGUI grade;
    // [SerializeField] private TextMeshProUGUI day;
    [SerializeField] private TextMeshProUGUI score;

    public void setValueScore(){
        if(PlayerPrefs.HasKey("HighScore")){
            // Debug.Log(PlayerPrefs.GetInt("HighScore").ToString());
            // grade.SetText("1");
            // day.SetText("2022/10/01");
            score.SetText(PlayerPrefs.GetInt("HighScore").ToString());
        }else{

            score.SetText("게임을 한 기록이 없습니다.");
            Debug.Log("저장된 값이 없습니다");
        }
    }

}
