using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    // 카메라 흔들림의 중량
    private float ShakeAmount = 0.05f;
    private float ShakeTime;        // 카메라가 흔들리는 시간
    private Vector3 initialPosition;        // 카메라가 흔들리는 위치

    private void Start() {
        initialPosition = new Vector3(0f, 0f, -10f);    // 흔들릴 카메라의 위치
    }

    private void Update() {
        // 흔들림감지
        if(ShakeTime > 0){
            // 흔들림의 중량만큼 카메라를 흔들어줌
            transform.position = Random.insideUnitSphere * ShakeAmount + initialPosition;
            ShakeTime -= Time.deltaTime;
        }else{
            ShakeTime = 0.0f;
            transform.position = initialPosition;
            // canvas.renderMode = RenderMode.ScreenSpaceCamera;
        }
    }

    // 시간을 넣어주면 해당 시간만큼 카메라가 흔들림
    public void VibrateForTime(float time){
        ShakeTime = time;
        // canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.renderMode = RenderMode.WorldSpace;
    }
}
