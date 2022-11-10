using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score_text;
    [SerializeField] private TextMeshProUGUI scoreShadow_text;
    // [SerializeField] private Transform addScore;
    [SerializeField] private TextMeshProUGUI addScore_text;

    private float score;
    private string score_str;

    private void Awake() {
        score = 0;
        setStrScore(score);
    }

    private void Update() {
        setStrScore(score);
    }

    public void addScore(float score){
        this.score += score;
        // addScoreAnimation(score);
    }

    private void addScoreAnimation(float score){
        GameObject ScoreUp_prefab = addScore_text.GetComponent<GameObject>();
        Instantiate(ScoreUp_prefab);
        addScore_text.SetText(score.ToString());

        Destroy (ScoreUp_prefab, 5f);
    }

    private void setStrScore(float score){
        score_str = string.Format("{0:D8}", (int)score);
        
        score_text.SetText(score_str);
        scoreShadow_text.SetText(score_str);
    }

    public int get_Score(){
        return (int)score;
    }


}
