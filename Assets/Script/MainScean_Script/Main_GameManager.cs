using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_GameManager : MonoBehaviour
{
    [SerializeField] private Button GameStartBtn;
    [SerializeField] private Button GameScoreBtn;
    [SerializeField] private Button GameSettingBtn;

    [SerializeField] private GameObject GameScorePopup;
    [SerializeField] private GameObject GameSettingPopup;
    // [SerializeField] private GameObject ScorePopup;

    // [SerializeField] private Transform Potato;
    // [SerializeField] private Transform PotatoTransform;

    private SoundManager soundManager;

    private float times;
    private float potatoPositionX;
    private float potatoPositionY;


    private void Start() {

        // GameScorePopup.SetActive(false);

        GameStartBtn.onClick.AddListener(() => StartGame());
        GameScoreBtn.onClick.AddListener(() => LoadSaveScore());
        GameSettingBtn.onClick.AddListener(() => GameSettingPopup.SetActive(true));
    }
    
    private void Update() {
        times += Time.deltaTime;
        if(times > 2f){
            times = 0;
            CreatePotato();
        }
    }

    private void LoadSaveScore(){
        // GameScorePopup.SetActive(true);
        ScorePopup scorePopup = GameScorePopup.GetComponent<ScorePopup>();
        scorePopup.OpenPopup();
    }

    private void StartGame(){
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        soundManager.ClickSound();
        SceneManager.LoadScene("Game_SelectedStage");
    }

    private void CreatePotato(){

        potatoPositionX = Random.Range(-800, 800);
        potatoPositionY = Random.Range(1700, 2000);

        // Transform potatoDropDown = Instantiate(Potato, PotatoTransform);
        // potatoDropDown.transform.Translate(potatoPositionX, potatoPositionY, 0f);

        
    }
}
