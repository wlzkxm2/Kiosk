using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 계산 결과
public class AmountManager : MonoBehaviour
{
    private const int defaultScore = 100;

    [SerializeField] private Button itemBuyBtn;
    [SerializeField] private Kiosk_Manager kiosk_Manager;
    [SerializeField] private SelectedItem_result selectedItem_result;   // 장바구니에 담은 아이템의 총 합
    [SerializeField] private GameManager gameManager;

    private Kiosk_SelectedItem selectedItem;        // 선택된 아이템을 확인하기위해

    private Dictionary<int, Kiosk_SelectedItem> ItemDic;

    private string itemName = null;       // 미션 이름
    // 금액 범위
    private int min;                    // 미션 최소값
    private int max;                    // 미션 최대값
    private int itemCount;

    private bool itemCheck = false;     // 장바구니안에 미션 아이템이 있는지 여부 체크
    private int result_Price;
    private int itemCount_Check;

    private int cartInItems;

    private float combo;      // 클리어 시 콤보

    private void Awake() {
        ItemDic = new Dictionary<int, Kiosk_SelectedItem>();
        combo = 1f;
    }

    private void Start() {
        itemBuyBtn.onClick.AddListener(() => BuyingItems());
    }

    public void setMission_info(int min, int max){
        this.min = min;
        this.max = max;

        this.itemCount = -1;
        this.itemName = null;
    }

    public void setMission_info(string itemName, int min, int max){
        this.itemName = itemName;
        this.min = min;
        this.max = max;
        this.itemCount = -1;     // 갯수제한이 없다는 의미
    }

    // 아이템의 갯수
    public void setMission_info(string itemName, int itemCount){
        this.itemName = itemName;
        this.itemCount = itemCount;
        
        this.min = 0;
        this.max = int.MaxValue;        // int 형의 최대 값을 넣어 범위를 지정
    }

    private void BuyingItems(){
        itemCheck = false;
        itemCount_Check = 0;
        cartInItems = 0;

        ItemDic = kiosk_Manager.getSelectedItemList();

        // 만약 전송받은 아이템이름이 없을때에는 체크를 해 줄 필요가 없음
        if(itemName == null)
            itemCheck = true;

        // 장바구니 리스트에 퀘스트 아이템이 있는지 확인
        foreach(KeyValuePair<int, Kiosk_SelectedItem> items in ItemDic){
            Kiosk_SelectedItem getItem = items.Value;
        
            if(getItem.getItemName().Equals(itemName)){
                itemCheck = true;
                itemCount_Check += 1;
            }
            cartInItems++;
        }

        AmountItems(itemCount_Check, cartInItems, itemCheck);

        // Debug.Log("아이템 갯수 : " + itemCount_Check + "미션 아이템 갯수 : " + itemCount);

        // if(itemCount_Check == itemCount)
        //     Debug.Log("갯수 맞음");
        
    }

    private void AmountItems(int itemCount_Check, int cartInItems, bool itemCheck){
        result_Price = selectedItem_result.get_resultPrice();
        Debug.Log(itemCheck);
        // 계산 조건식
        // 전달 받은 아이템 갯수 조건이 있을때
        if(itemCount > -1){
            // Debug.Log("1");
            // 전달받은 아이템의 갯수와 장바구니에 있는 해당 아이템 갯수가 같을때
            if(itemCount == itemCount_Check){
                // 만약 장바구니 아이템이 전달받은 아이템 갯수보다 많을때
                if(cartInItems > itemCount){
                    gameManager.DamagedPlayer();
                }else{
                    Debug.Log("클리어");
                    // Clear Event
                    ClearStageAddScore();
                }
            }else{
                gameManager.DamagedPlayer();
            }

        }else{      // 만약 아이템 갯수가 중요하지 않을 때
            // Debug.Log("2");
            // 장바구니 아이템가격이 해당 범위 안에있는지 체크
            if(min <= result_Price && result_Price <= max){
            // 리스트에 퀘스트 아이템이 있었는지 체크
                if(itemCheck){
                    // Clear event
                    Debug.Log("클리어");
                    ClearStageAddScore();
                }else{
                    gameManager.DamagedPlayer();
                }
            }else{
                gameManager.DamagedPlayer();
            }
            
        }
    }

    public void set_comboReset(){
        combo = 1f;
    }

    private void ClearStageAddScore(){
        combo *= 1.2f;

        gameManager.ClearStage(defaultScore * combo);
    }
}
