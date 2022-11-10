using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectedItem_result : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI result_text;

    private int resultPrice;

    public void SetSelectedItemResult(int price, bool sign){
        // 전달 받은 값이 참이면 +  전달 받은 값이 거짓이면 -
        if(sign)
            this.resultPrice += price;
        else
            this.resultPrice -= price;

        AddListItemResult(this.resultPrice);
    }

    private void AddListItemResult(int price){
        result_text.SetText(price.ToString());
    }

    public int get_resultPrice(){
        return resultPrice;
    }

    public void set_ClearPrice(){
        this.resultPrice = 0;
    }
}
