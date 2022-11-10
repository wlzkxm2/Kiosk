using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiosk_Manager : MonoBehaviour
{
    [SerializeField] private Transform SelectedItemPrefab;
    [SerializeField] private Transform SelectedItemContainerTransform;
    [SerializeField] private SelectedItem_result selectedItem_result;
    private Kiosk_SelectedItem selectedItem;

    private Dictionary <int, Kiosk_SelectedItem> ItemDic;

    private SoundManager soundManager;

    // 아이템의 수를 체크
    private int itemcount = 0;

    private void Awake() {
        ItemDic = new Dictionary<int, Kiosk_SelectedItem>();
    }

    private void Start() {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    private void Update() {
        // foreach(KeyValuePair<int, Kiosk_SelectedItem> items in ItemDic){
        //     Kiosk_SelectedItem getItem = items.Value;
        //     Debug.Log(getItem.getItemName());
        // }
    }

    // 아이템 을 딕셔너리에 추가
    // 키오스크 아이템 에서 전달받은 정보를 처리
    public void AddItemList(string ItemName, int ItemPrice){
        // Debug.Log("키오스크 매니저 아이템 전송 받음" + ItemName + " / " + ItemPrice);
        // 딕셔너리에 해당 아이템에 대한 정보를 저장
        ItemDic.Add(itemcount, new Kiosk_SelectedItem(ItemName, ItemPrice));
        itemcount++;

        // 아이템 추가 사운드
        soundManager.ClickSound();

        // 저장될때마다 아이템 리스트 뷰를 초기화
        CreateSelectedItemList(ItemDic);
        
        // 전달되면 해당 아이템의 총 합 값을 세팅
        selectedItem_result.SetSelectedItemResult(ItemPrice, true);
    }


    public void DeleteItemList(string ItemName, int ItemPrice){
        // Kiosk_SelectedItem deleteItem = new Kiosk_SelectedItem(ItemName, int.Parse(ItemPrice));
        Debug.Log("DeleteItemList 실행" + ItemName + " / " + ItemPrice);
        // Debug.Log("DeleteItemList 실행" + ItemDic.Values + " / " + ItemDic.Keys);

        // 아이템 삭제 사운드
        soundManager.NagativeSound();

        foreach(KeyValuePair<int, Kiosk_SelectedItem> items in ItemDic){
            Kiosk_SelectedItem getItem = items.Value;
            bool searchData = getItem.cData(ItemName, ItemPrice);

            if(searchData){
                ItemDic.Remove(items.Key);
                break;
            }
        }

        CreateSelectedItemList(ItemDic);
        selectedItem_result.SetSelectedItemResult(ItemPrice, false);
    }

    public void DeleteAllItemList(){
        ItemDic.Clear();
        CreateSelectedItemList(ItemDic);
        selectedItem_result.set_ClearPrice();
    }

    private void CreateSelectedItemList(Dictionary<int, Kiosk_SelectedItem> ItemDic){
        foreach(Transform container in SelectedItemContainerTransform){
            Destroy(container.gameObject);
        }

        foreach(KeyValuePair<int, Kiosk_SelectedItem> items in ItemDic){
            Kiosk_SelectedItem getItem = items.Value;
            Transform selectedTransform = Instantiate(SelectedItemPrefab, SelectedItemContainerTransform);
            MenuSelectedList menuSelectedList = selectedTransform.GetComponent<MenuSelectedList>();
            menuSelectedList.SelectedItem(getItem.getItemName(), getItem.getItemPrice());
        }
    }

    public Dictionary<int, Kiosk_SelectedItem> getSelectedItemList(){
        return ItemDic;
    }
}
