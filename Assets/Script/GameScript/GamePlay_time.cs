using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class GamePlay_time : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI time_text;
    [SerializeField] private Slider time_slider;

    private float time;
    private float Slider_time;
    private bool startTime;

    private void Start() {
        time = 0;
        startTime = true;
    }

    private void Update() {
        if(startTime){
            if(time > 0){
                time_moves();
                slider_moves();
            }
        }
    }

    // 시간을 설정
    public void setTime(int time){
        startTime = true;
        this.time = time;
        this.Slider_time = time;
    }

    private void time_moves(){
        this.time -= Time.deltaTime;

        // Debug.Log(this.time);
        int time = (int)this.time;
        setTimeText(time);
    }
    
    private void slider_moves(){
        time_slider.value = time / Slider_time;
    }

    public float get_time(){
        return time_slider.value;
    }

    private void setTimeText(int time){
        time_text.SetText(time.ToString());
    }

    // 시간이 멈춤
    public void StopTime(){
        Time.timeScale = 0;
    }

    // 시간이 움직임
    public void MoveTime(){
        Time.timeScale = 1;
    }

    public void gameover(){
        startTime = false;
    }
}
