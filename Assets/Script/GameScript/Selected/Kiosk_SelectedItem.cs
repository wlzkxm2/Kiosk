using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiosk_SelectedItem {
    private string name;
    private int price;

    public Kiosk_SelectedItem(string name, int price){
        this.name = name;
        this.price = price;
    }

    // 상품 이름 반환
    public string getItemName(){
        return name;
    }
    
    // 상품 가격 반환
    public int getItemPrice(){
        return price;
    }

    // 입력받은 값을 비교하고 만약 맞다면 트루 반환
    public bool cData(string name, int price){
        if(this.name.Equals(name) && this.price.Equals(price)){
            return true;
        }
        return false;
    }
}
