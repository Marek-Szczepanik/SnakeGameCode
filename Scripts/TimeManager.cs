using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    //float timer = 0;
    int minutes;
    int seconds;
    private void Start() {
        minutes = 0;
        seconds = 0;
    }
    void FixedUpdate()
    {
        RunTimer();
    }
     private void RunTimer() {
        Database.Dbtimer = Time.timeSinceLevelLoad;
     minutes = Mathf.FloorToInt(Database.Dbtimer / 60F);
     seconds = Mathf.FloorToInt(Database.Dbtimer - minutes * 60);
     string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
     timerText.text = niceTime;
 }
}
