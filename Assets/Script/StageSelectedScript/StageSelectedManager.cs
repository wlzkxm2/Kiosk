using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectedManager : MonoBehaviour
{

    [SerializeField] private Button stage;
    [SerializeField] private Button back;
    
    private void Start() {
        stage.onClick.AddListener(() => clickStage());
        back.onClick.AddListener(() => clickBack());
    }

    private void clickStage(){
        SoundManager soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        soundManager.ClickSound();

        SceneManager.LoadScene("LoadingScenes");
    }

    private void clickBack(){
        SoundManager soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        soundManager.NagativeSound();
        
        SceneManager.LoadScene("Main");

    }
}
