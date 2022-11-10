using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//*****************************************************
//                  Popup03_Light
//*****************************************************

public class MissionPopUpView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Title;     // 미션 내용 간략타이틀
    [SerializeField] private TextMeshProUGUI Main;      // 미션 상세 내용

    public void SetPopupInfo(string title_text, string main_text){
        Title.SetText(title_text);
        Main.SetText(main_text);

    }

}
