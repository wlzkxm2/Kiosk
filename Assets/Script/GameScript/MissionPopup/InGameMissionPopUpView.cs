using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameMissionPopUpView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI main;

    public void setPopupText(string title, string main){
        this.title.SetText(title);
        this.main.SetText(main);
    }


}
