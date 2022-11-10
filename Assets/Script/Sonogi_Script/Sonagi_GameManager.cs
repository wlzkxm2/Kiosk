using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonagi_GameManager : MonoBehaviour
{
    [SerializeField] private RectTransform sonagiText;

    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;

    private float time;

    private void Start() {
        setPositionText();
        // Invoke("setPositionText", 2f);
    }


    private void Update() {
        
    }

    private void setTime(int time){
        this.time = time;
    }


    private void setPositionText(){
        float randPositionX = Random.Range(-150, 150);
        // Debug.Log(randPositionX);

        // 소나기 텍스쳐 클론 생성및 위치 초기화
        RectTransform sonagiInstant = Instantiate(sonagiText, startPosition);
        // sonagiInstant.anchoredPosition = new Vector2(randPositionX, sonagiInstant.position.y);

        sonagiInstant.anchoredPosition = new Vector3(randPositionX, 0, 0);
        
        sonagiInstant.GetComponent<TextSonagiSet>().setSonagiText(sonagiInstant, endPosition);

        Invoke("setPositionText", 2f);
    }
}
