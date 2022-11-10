using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameEventPopUpObject;   // 팝업의 대한 오브젝트를 담고 있는 오브젝트
    private Mission_getter_setter mission_getter_setter;   // 팝업의 대한 오브젝트를 담고 있는 오브젝트

    [SerializeField] private GameObject startMissionPopupInfo;
    [SerializeField] private Button startMissionPopupStart_btn;     // 게임 시작 버튼

    [SerializeField] private GameObject inGameMissionPopUpView;     // 인게임 미션 팝업 뷰
    [SerializeField] private GameObject gameOverPopUpView;

    [SerializeField] private GameObject[] playerHP;

    [SerializeField] private AmountManager amountManager;        // 미션 계산 결과를 계산할 스크립트

    [SerializeField] private CameraShake cameraShake;    // 패배시 카메라 흔들림

    [SerializeField] private GamePlay_time gamePlay_time;        // 게임 시간

    [SerializeField] private ScoreManager scoreManager;     // 점수 계산을 할 스코어 매니저

    [SerializeField] private Kiosk_Manager kiosk_Manager;

    private SoundManager soundManager;


    private int PlayerHP_int;

    private void Awake() {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        PlayerHP_int = 3;       // 기본 체력은 3
        
        mission_getter_setter = GetComponent<Mission_getter_setter>();
        gameOverPopUpView.SetActive(false);

        callMission_();
        // gamePlay_time = GetComponent<GamePlay_time>();
    }

    private void Start() {
        

        // 버튼 클릭시 미션 창이 닫히고 게임시작
        startMissionPopupStart_btn.onClick.AddListener(() => startMissionStartBtnEvent());
    
    }

    private void Update() {
        // Debug.Log(gamePlay_time.get_time());
        float limiteTime = gamePlay_time.get_time();
        if(limiteTime <= 0)
            PlayerHP_int = 0;
    }

    private void LateUpdate() {
        CheakPlayerHP();
    }

    private void SaveScore(int score){
        // 내부에 저장된 값을 확인후 최고 점수를 찾음
        if(PlayerPrefs.HasKey("HighScore")){
            // 저장된 최고점수가 있을때 해당 값을 불러옴
            int saveHighScore = PlayerPrefs.GetInt("HighScore");
            
            // 불러온 값이 유저 하이스코어보다 작다면 유저 하이스코어를 삽입
            if(saveHighScore < score)
                PlayerPrefs.SetInt("HighScore", score);
        }else{
            // 만약 저장된 하이스코어값이 없다면 새로운 하이스코어 값 저장
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    private void callMission_(){
        soundManager.PopUpSound();
        mission_getter_setter.callMission();
        gameEventPopUpObject.SetActive(true);
        
    }

    private void startMissionStartBtnEvent(){
        soundManager.ClickSound();

        gameEventPopUpObject.SetActive(false);
        startTimeSet();
        gamePlay_time.MoveTime();
    }

    // 미션에 대한 내용을 출력하기 위한 함수
    public void setMission(string title, int min_price, int max_price){
        setMissionPopupText(title);

        amountManager.setMission_info(min_price, max_price);
    }

    // 미션에 대한 내용을 출력하나 아이템 이름이 추가된 함수
    public void setMission(string title, string itemName, int min_price, int max_price){
        setMissionPopupText(title);

        // Debug.Log("아이템이름" + itemName);
        amountManager.setMission_info(itemName, min_price, max_price);
    }

    // 미션에 대해 내용을 출력하나 아이템 이름과 갯수가 추가된 함수
    public void setMission(string title, string itemName, int itemCount){
        setMissionPopupText(title);

        // Debug.Log("아이템이름" + itemName);
        amountManager.setMission_info(itemName, itemCount);
    }

    private void setMissionPopupText(string title){
        MissionPopUpView missionPopUpView =  startMissionPopupInfo.GetComponent<MissionPopUpView>();
        InGameMissionPopUpView inGameMissionPopUpView = this.inGameMissionPopUpView.GetComponent<InGameMissionPopUpView>();

        missionPopUpView.SetPopupInfo("오늘의 미션", title);
        inGameMissionPopUpView.setPopupText("오늘의 미션", title);
    }
    


    public void DamagedPlayer(){
        if(PlayerHP_int == 1){
            PlayerHP_int -= 1;      // 틀릴때마다 체력의 카운트를 -1
            playerHP[PlayerHP_int].SetActive(false);
            cameraShake.VibrateForTime(0.5f);
            amountManager.set_comboReset();
        }else{
            PlayerHP_int -= 1;
            playerHP[PlayerHP_int].SetActive(false);
            cameraShake.VibrateForTime(0.5f);
            amountManager.set_comboReset();
        }
        // Debug.Log(PlayerHP_int);
    }

    private void CheakPlayerHP(){
        if(PlayerHP_int <= 0){
            // 만약 플레이어 체력이 0보다 작다면 즉 -1 이하라면
            gameOverPopUpView.SetActive(true);
            
            // 팝업 사운드
            soundManager.PopUpSound();

            gamePlay_time.gameover();
            setGameOverViewSet();
            
        }
    }

    private void startTimeSet(){
        gamePlay_time.setTime(15);
    }

    public void ClearStage(float score){
        AddScore(score);
        gamePlay_time.StopTime();       // 클리어 후 새로운 미션을 할당받을때 까지 시간 멈춤
        kiosk_Manager.DeleteAllItemList();
        callMission_();
        // kiosk_Manager.DeleteAllItemList();
    }

    private void AddScore(float score){
        scoreManager.addScore(score);
    }

    private void setGameOverViewSet(){
        // gameOverPopUpView.GetComponent<GameOverWindow>().Set_ScoreValue(scoreManager.get_Score());
        GameOverWindow gameOverWindow = gameOverPopUpView.GetComponent<GameOverWindow>();
        // gamePlay_time.StopTime();

        gameOverWindow.Set_ScoreValue(scoreManager.get_Score());
        SaveScore(scoreManager.get_Score());
        
    }

    public void stopTime(){
        gamePlay_time.StopTime();
    }

}
