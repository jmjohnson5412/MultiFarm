using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class TimeHandler : NetworkHandler {

    //ME
    private TimeHandler instance;

    //CONST
    public const string SPRING = "spring";
    public const string SUMMER = "summer";
    public const string FALL = "fall";
    public const string WINTER = "winter";

    private const float minutesInHour = 60;
    private const float hoursInDay = 24;
    private const int daysInSeason = 30;
    private const int seasonsInYear = 4;

    private const float timePerInGameSecond = .01f;
    private const float timeTrackedInGame = 10;

    private const float timeHoursInDay = 24;
    private const float timeDaysInSeason = 30;

    //VARS
    [SyncVar]
    public int season;

    [SyncVar]
    public int year;

    [SyncVar]
    public int day;

    [SyncVar]
    public float hour;

    [SyncVar]
    public float minute;

    private float timeTrack;
    private float timeSinceZero;

    //OBJECTS
    public GameObject timeText;
    public GameObject seasonText;
    public GameObject dayText;

    //LOG
    private Logger log;

	public override void HandlerStart_S() {
        timeTrack = 0;
        timeSinceZero = 0;
	}

    public override void HandlerStart_C() {
        UpdateTimeUI();
    }
	
	public override void HandlerUpdate_S() {
        Debug.Log("HandlerUpdate_S");

        timeTrack += Time.deltaTime;
        timeSinceZero += Time.deltaTime;
		if(timeTrack > (timeTrackedInGame * timePerInGameSecond)) {
            timeTrack = 0;
            IncrementBy(timeTrackedInGame);
        }
	}

    public override void HandlerUpdate_C() {
        Debug.Log("HandlerUpdate_C");

        UpdateTimeUI();
    }

    public void IncrementBy(float increment) {
        minute += increment;

        if(minute >= minutesInHour) {
            minute -= minutesInHour;
            hour += 1;
        }
        if(hour >= hoursInDay) {
            hour -= hoursInDay;
            day += 1;
        }
        if(day >= daysInSeason) {
            day -= daysInSeason;
            season += 1;
        }
        if(season >= seasonsInYear) {
            season -= seasonsInYear;
            year += 1;
        }
    }

    public string TimeToString() {
        string ret = "";
        ret += hour + ":";
        if(minute < 10) {
            ret += "0";
        }
        ret += minute;
        return ret;
    }

    public string SeasonToString() {
        switch(season) {
            case 3:
                return WINTER;
            case 2:
                return FALL;
            case 1:
                return SUMMER;
            case 0:
                return SPRING;
            default:
                Debug.Log("TIMEHANDLER ERROR: Bad season, season value - " + season);
                return null;
        }
    }

    private void UpdateTimeUI() {
        timeText.GetComponent<Text>().text = TimeToString();
        dayText.GetComponent<Text>().text = (day+1).ToString();
        seasonText.GetComponent<Text>().text = SeasonToString();
    }
}
