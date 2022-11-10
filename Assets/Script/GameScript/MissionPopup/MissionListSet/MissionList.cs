using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionList
{
    private string MissionName;

    private string ItemName = "";
    private int min_rangeMoney;
    private int max_rangeMoney;
    private int ItemCount;

    public MissionList(string MissionName, int min_rangeMoney, int max_rangeMoney){
        
        this.MissionName = MissionName;
        this.min_rangeMoney = min_rangeMoney;       // 최소값
        this.max_rangeMoney = max_rangeMoney;       // 최대값

    }

    public MissionList(string MissionName, string ItemName, int min_rangeMoney, int max_rangeMoney){

        this.MissionName = MissionName;

        this.ItemName = ItemName;
        this.min_rangeMoney = min_rangeMoney;
        this.max_rangeMoney = max_rangeMoney;

    }

    public MissionList(string MissionName, string ItemName, int ItemCount){
        this.MissionName = MissionName;
        this.ItemName = ItemName;
        this.ItemCount = ItemCount;
    }

    public string getMissionName(){
        return MissionName;
    }

    public string getItemName(){
        return this.ItemName;
    }

    public int getmin_rangeMoney(){
        return min_rangeMoney;
    }

    public int getmax_rangeMoney(){
        return max_rangeMoney;
    }

    public int getItemCount(){
        return ItemCount;
    }


}
