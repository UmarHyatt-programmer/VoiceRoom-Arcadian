using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public PlayfabAuthentication playfabAuthentication;
    public static UIManager Instance;
    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }
    public Text logTxt;
    public GameObject authPanel;
    public async void Log(string log, int time)
    {
        logTxt.text = log;
        await System.Threading.Tasks.Task.Delay(time);
        logTxt.text = "";
    }
    public void Log(string log)
    {
        logTxt.text = log;
    }
}
