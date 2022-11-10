using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScorePopup : MonoBehaviour
{
    [SerializeField] private Button back;

    [SerializeField] private user_ScoreManager userScore;

    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;

    private float lerpTime = 1f;      // 팝업창이 올라올 속도
    private float currentTime = 0;

    private void Start() {
        this.transform.position = startPosition.position;

        // 점수가 존재하지 않을때 예외처리
        try{

        }catch(Exception ex){
            Debug.Log(ex);
        }

        // back.onClick.AddListener(() => this.gameObject.SetActive(false));
        back.onClick.AddListener(() => ClosedPopup());
    }

    private void Update() {
        userScore.setValueScore();
    }

    public void OpenPopup(){
        StartCoroutine(MovePopup(startPosition, endPosition, true));
        // this.gameObject.SetActive(true);
    }

    private void ClosedPopup(){
        StartCoroutine(MovePopup(endPosition, startPosition, false));
    }

    IEnumerator MovePopup(Transform startPosition, Transform endPosition, bool where){
        float popupStep = currentTime / lerpTime;
        float value;
        if(where)
            value = 0.99f;
        else{
            this.transform.position = endPosition.position;
            yield break;
        }
            
        do{
            currentTime += Time.deltaTime;
        
            popupStep = currentTime / lerpTime;
            popupStep = Mathf.Sin(popupStep * Mathf.PI * 0.5f);

            Debug.Log(popupStep);
            this.transform.position = Vector3.Lerp(startPosition.position, new Vector3(0, 0, 0), popupStep);
            yield return null;
        }while(popupStep <= value);

        
        currentTime = 0;
        yield return null;
    }

}
