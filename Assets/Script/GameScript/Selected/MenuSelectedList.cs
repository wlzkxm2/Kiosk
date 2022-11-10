using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//*****************************************************
//              Btn_SelectedItems Prefab
//*****************************************************

public class MenuSelectedList : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI SelectedName;
   [SerializeField] private TextMeshProUGUI SelectedPrice;
   [SerializeField] private Button CloseButton;
   private Kiosk_Manager kiosk_Manager;

   private string Name;
   private int price;

    private void Awake() {
        kiosk_Manager = GameObject.Find("KioskManager").GetComponent<Kiosk_Manager>();
    }

    // 아이템이 선택 되었을때 받는 아이템을 표시되는 아이템들
    public void SelectedItem(string SelectedName, int SelectedPrice){
        this.Name = SelectedName;
        this.price = SelectedPrice;

        this.SelectedName.SetText(this.Name);
        this.SelectedPrice.SetText(this.price.ToString());

    }

    private void Start() {
        CloseButton.onClick.AddListener(() => DeleteItem(Name, price));
    }

    public void DeleteItem(string SelectedName, int SelectedPrice){
        kiosk_Manager.DeleteItemList(SelectedName, SelectedPrice);
    }
}
