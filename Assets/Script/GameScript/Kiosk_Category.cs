using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kiosk_Category : MonoBehaviour
{
    [SerializeField] private Button buttons;
    [SerializeField] private GameObject MenuContainer;

    // 메인 음식
    private string[,] MainFood = new string[,] {
        {"불고기 버거" , "3900", "BulgoggiBuger"}, {"치킨 버거" , "3700", "ChikenBurger"}, 
        {"새우 버거" , "4500", "shrimpBurger"}, {"더블 불고기버거" , "5900", "DoubleBulgoggiBuger"}, 
        {"치즈 버거" , "4900", "CheaseBurger"}, {"치즈 불고기버거" , "5900", "CheaseBulgogiBurger"}, 
        {"소불고기 버거" , "8000", "CowBulgogiBurger"}, {"더블치즈 불고기버거" , "6300", "DoubleCheaseBurger"},
        {"치킨 마요 버거" , "4000", "ChikenMayoBurger"}
    }; 


    // 서브 음식
    private string[,] SubFood = new string[,]{
        {"치즈 스틱" , "2000", "Cheasestick"}, {"감자 튀김" , "1500", "Potato"},
        {"치킨 너겟" , "1500", "ChikenNutget"}, {"치킨" , "8000", "chiken"},
        {"콘 샐러드" , "1800", "ConSalada"}, {"콘 치즈 샐러드" , "2500", "ConSalada"}
    };

    // 음료
    private string[,] Drink = new string[,]{
        {"콜라" , "1700", "Cola"}, {"콜라 제로" , "1700", "Cola"}, 
        {"사이다" , "1700", "cider"}, {"사이다 제로" , "1700", "cider"}, 
        {"아메리카노" , "1000", "Americano"}, {"환타" , "2500", "Fanta"},
        {"오렌지 주스" , "2500", "OrangeJuce"}
    };

    // 디저트
    private string [,] Dessert = new string[,] {
        {"아이스크림" , "800", "Icecream"}, {"아이스크림 쉐이크" , "1800", "IcecreamShake"}, 
        {"모짜 치즈볼" , "1500", "CheaseBall"}, {"애플 파이" , "2000", "applePie"}, 
        {"오징어링" , "1000", "OctRing"}
    };

    private void Awake() {
        buttons = GetComponent<Button>();
    }

    public void ActionButton(){
        Debug.Log(buttons.name);
        if(buttons.name.Equals("Btn_MainMenu"))
            MenuContainer.GetComponent<Kiosk_ChoiceMenu>().CreateMenuList(MainFood);
        else if(buttons.name.Equals("Btn_SubMenu"))
            MenuContainer.GetComponent<Kiosk_ChoiceMenu>().CreateMenuList(SubFood);
        else if(buttons.name.Equals("Btn_Drink"))
            MenuContainer.GetComponent<Kiosk_ChoiceMenu>().CreateMenuList(Drink);
        else if(buttons.name.Equals("Btn_Dessert"))
            MenuContainer.GetComponent<Kiosk_ChoiceMenu>().CreateMenuList(Dessert);
        
    }
}
