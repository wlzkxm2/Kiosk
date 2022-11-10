using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField] private Button back;

    private void Start() {
        back.onClick.AddListener(() => ClosedPopup());
    }

    private void ClosedPopup(){
        this.gameObject.SetActive(false);
    }
}
