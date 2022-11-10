using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Kiosk_ChoiceMenu : MonoBehaviour
{
    // 제작한 메뉴 프리팹
    [SerializeField] private Transform Kiosk_FoodPrefab;
    // 프리팹을 담을 컨테이너
    [SerializeField] private Transform Kiosk_FoodContainerTransform;


    
    public void CreateMenuList(string[,] MenuListName){
        foreach(Transform buttonTransform in Kiosk_FoodContainerTransform){
            Destroy(buttonTransform.gameObject);
        }

        for (int i = 0; i < (MenuListName.Length / 3); i++)
        {
            // Debug.Log("Create");
            // Debug.Log(MenuListName[i, 0]);
            Debug.Log(MenuListName[i, 1]);
            // Debug.Log("MenuListName.Length : " + MenuListName.Length);
            // Debug.Log("MenuListName.Length / 2 : " + MenuListName.Length / 2);
            // 인스턴트 생성
            Transform menuTransform = Instantiate(Kiosk_FoodPrefab, Kiosk_FoodContainerTransform);
            // 생성한 인스턴트의 아이템 프리팹에 접근
            Kisok_btn kisok_btn = menuTransform.GetComponent<Kisok_btn>();
            kisok_btn.SetName(MenuListName[i,0], MenuListName[i, 1], MenuListName[i, 2]);   // 접근 후 아이템 이름 설정
        }
    
    }
    

    private void Start() {
        // CreateMenuList();
    }



}
