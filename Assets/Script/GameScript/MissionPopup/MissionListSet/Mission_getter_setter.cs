using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_getter_setter : MonoBehaviour
{
    private GameManager gameManager;
    private Dictionary<int, MissionList> missionDic;

    private int whatIsMission;

    private int missionNumber = 0;

    private void Awake() {
        gameManager = GetComponent<GameManager>();
        missionDic = new Dictionary<int, MissionList>();
    }

    private void Start() {
        missionDic.Add(0, new MissionList("불고기 버거를 포함하여 12000원~ 13000원 이내로 구매하기", "불고기 버거", 12000, 13000));
        missionDic.Add(1, new MissionList("16200 ~ 18200원 이내로 구입하세요", 16200, 18200));
        missionDic.Add(2, new MissionList("치즈스틱 세개가 먹고 싶어요", "치즈 스틱", 3));
        missionDic.Add(3, new MissionList("치킨마요 버거 5개 먹고싶어요", "치킨 마요 버거", 5));
        missionDic.Add(4, new MissionList("더블치즈 불고기버거를 포함해 30000원 이내로 구매하기", "더블치즈 불고기버거", 6400, 30000));
        missionDic.Add(5, new MissionList("콘샐러드 다섯개를 먹고싶어요", "콘 샐러드", 5));
        missionDic.Add(6, new MissionList("치킨버거 포함해서 5000원 이내로 구매해주세요", "치킨 버거", 3800, 5000));
        missionDic.Add(7, new MissionList("치킨만 먹고싶어요", "치킨", 1));
        missionDic.Add(8, new MissionList("아메리카노 다섯잔 주세요", "아메리카노", 5));
        missionDic.Add(9, new MissionList("오징어링 포함해서 1만원 어치 사주세요", "오징어링", 10000, 12000));
        missionDic.Add(10, new MissionList("더블치즈 불고기버거 10개 주세요", "더블치즈 불고기버거", 10));
        // missionDic.Add(0, new MissionList("불고기 버거를 포함하여 12000원~ 13000원 이내로 구매하기", 12000, 13000));
        // missionDic.Add(0, new MissionList("불고기 버거를 포함하여 12000원~ 13000원 이내로 구매하기", 12000, 13000));
        // missionDic.Add(0, new MissionList("불고기 버거를 포함하여 12000원~ 13000원 이내로 구매하기", 12000, 13000));
        // missionDic.Add(0, new MissionList("불고기 버거를 포함하여 12000원~ 13000원 이내로 구매하기", 12000, 13000));

    }

    public void callMission(){
        whatIsMission = Random.Range(0, 11);
        // Debug.Log(whatIsMission);
    }

    public void Update(){
        setMissionTitles();
    }

    private void setMissionTitles(){
        if(missionDic.ContainsKey(whatIsMission)){
            MissionList missionList = missionDic[whatIsMission];
            // 만약 랜덤으로 잡힌 미션중에 특정 아이템을 잡지 않아도 되는 경우
            if(missionList.getItemName() != ""){
                if(missionList.getItemCount() != 0){
                    gameManager.setMission(missionList.getMissionName(),missionList.getItemName(), missionList.getItemCount());
                }else{
                    gameManager.setMission(missionList.getMissionName(),missionList.getItemName(), missionList.getmin_rangeMoney(), missionList.getmax_rangeMoney());
                }
            }else{
                gameManager.setMission(missionList.getMissionName(), missionList.getmin_rangeMoney(), missionList.getmax_rangeMoney());
            }

            // Debug.Log(missionList.getMissionName());
            // Debug.Log(missionList.getItemName());
            // Debug.Log("ItemCount : " + missionList.getItemCount());
                
        }
    }



}
