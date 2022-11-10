using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScenen : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private string SceneName = "Game_Kiosk";

    private float time;
    
    void Start()
    {
        StartCoroutine(LoadAsynSceneCoroutine());
    }

    // public LoadingScenen(string SceneName){
    //     this.SceneName = SceneName;
    // }

    IEnumerator LoadAsynSceneCoroutine(){
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);

        operation.allowSceneActivation = false;

        while(!operation.isDone){
            time += Time.time;

            slider.value = time*5f;

            if(time > 10){
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
