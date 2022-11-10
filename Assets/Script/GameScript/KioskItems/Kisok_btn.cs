using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//*****************************************************
//                    Btn_Item Prefab
//*****************************************************

public class Kisok_btn : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI MenuName;
    [SerializeField] private TextMeshProUGUI MenuPrice;
    [SerializeField] private Image image;

    [SerializeField] private Sprite[] sprites;

    [SerializeField] private Button button;
    private Kiosk_Manager kiosk_Manager;
/*
    Americano.png
    applePie.png
    BulgoggiBuger.png
    CheaseBall.png
    CheaseBulgogiBurger.png
    CheaseBurger.png
    Cheasestick.png
    chiken.png
    ChikenBurger.png
    ChikenMayoBurger.png
    ChikenNutget.png
    cider.png
    Cola.png
    ConSalada.png
    CowBulgogiBurger.png
    DoubleBulgoggiBuger.png
    DoubleCheaseBurger.png
    Fanta.png
    Icecream.png
    IcecreamShake.png
    OctRing.png
    OrangeJuce.png
    Potato.png
    shrimpBurger.png
*/
    

    private string name;
    private int price;
    private string spirteName;
    
    private void Awake() {
        kiosk_Manager = GameObject.Find("KioskManager").GetComponent<Kiosk_Manager>();
        // image = GetComponent<Image>();
        // foreach(Sprite sprite in sprites){
        //     Debug.Log(sprite.ToString().ToUpper());
        // }
    }

    private void Start() {
        // 선택한 아이템을 키오스크 매니저로 정보를 보냄
        button.onClick.AddListener(() => getName());
        // foreach(Sprite sprite in sprites){
        //     Debug.Log("spritename : " + sprite.ToString().ToUpper());
            
        // }
    }

    private void Update() {
        // sprite 위치 찾기

        // for (int i = 0; i < sprites.Length; i++)
        // {
        //     if(spirteName.Equals(sprites[i].ToString().ToUpper())){
        //         image.sprite = sprites[i];
        //     }
        // }
    }

    private void LateUpdate() {
        setSprite();
    }

    public void SetName(string MenuName, string MenuPrice, string spirteName){
        this.MenuName.SetText(MenuName);
        this.MenuPrice.SetText(MenuPrice);
        
        this.name = MenuName;
        this.price = int.Parse(MenuPrice);
        this.spirteName = spirteName.ToUpper();
        // Debug.Log(name + " / " + price);
        // Debug.Log(this.spirteName);

        // setSprite();
    }

    private void setSprite(){
        foreach(Sprite sprite in sprites){
            // Debug.Log(sprite.ToString().ToUpper());
            string spriteArrName = sprite.ToString().ToUpper();
            spriteArrName = spriteArrName.Substring(0, spriteArrName.Length - 21);
            if(spirteName.Equals(spriteArrName)){
                image.sprite = sprite;
                // Debug.Log("equals");
                break;
            }else{
                // Debug.Log("-------------------------------------------------------");
                // Debug.Log(spirteName.GetType());
                // Debug.Log(spriteArrName.GetType());
                // Debug.Log(spirteName);
                // Debug.Log(sprite.ToString().ToUpper());
                // Debug.Log(spriteArrName);
                // Debug.Log("-------------------------------------------------------");
                // Debug.Log("Not");
                // Debug.Log("spirteName : " + spirteName);
                // Debug.Log("sprite.ToString().ToUpper()) : " + sprite.ToString().ToUpper());
                // Debug.Log("-------------------------------------------------------");
            }
        }
    }

    private void getName(){
        // SelectedItemView.GetComponent<Kiosk_Manager>().AddItemList(name, price);
        // Debug.Log("버튼 이벤트 체크" + name);
        // Debug.Log("버튼 이벤트 체크" + price);
        kiosk_Manager.AddItemList(name, price);
    }

    
}
