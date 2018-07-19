using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime {

    //Const
    private const float minutesInHour = 60;

    public const string SPRING = "spring";
    public const string SUMMER = "summer";
    public const string FALL = "fall";
    public const string winter = "winter";

    //Var
    public string season;
    public int year;
    public int day;
    public float hour;
    public float minute;

    public GameTime(float hour, float minute) {
        this.hour = hour;
        this.minute = minute;
    }

    public void IncrementBy(float increment) {
        minute += increment;

        if(minute >= minutesInHour) {
            minute -= minutesInHour;
            hour+=1;
        }
    }
}
