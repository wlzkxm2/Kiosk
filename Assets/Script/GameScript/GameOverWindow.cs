using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameOverWindow : MonoBehaviour
{
    // GameOver 되었을시 나오는 윈도우 창에 대한 동작 설정

    // 게임이 클리어 되었을때 나오는 유저 점수
    [SerializeField] private TextMeshProUGUI gameScoreValue;
    [SerializeField] private GameObject btn_pack;
    [SerializeField] private Button Replay;
    [SerializeField] private Button GoToMainMenu;

    private SoundManager soundManager;

    private float timer;
    private bool over = false;

    private void Start() {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        btn_pack.SetActive(false);
        timer = 0;

        Replay.onClick.AddListener(() => gotoReplay());
        GoToMainMenu.onClick.AddListener(() => gotoMain());
    }

    private void Update() {
        if(over){
            timer += Time.deltaTime;
            
            if(timer > 2f){
                set_ActivateButton();
            }
        }
    }

    private void gotoReplay(){
        // Debug.Log("Replay Button");
        soundManager.ClickSound();
        SceneManager.LoadScene("Game_Kiosk");
    }

    private void gotoMain(){
        soundManager.NagativeSound();
        SceneManager.LoadScene("Main");
    }

    // 전달 받은 값을 점수로 설정
    public void Set_ScoreValue(int Score){
        string score_str = string.Format("{0:D6}", (int)Score);
        gameScoreValue.SetText(score_str);
        

        over = true;
    }

    private void set_ActivateButton(){
        btn_pack.SetActive(true);
        timer = 0;
        over = false;
    }
}
