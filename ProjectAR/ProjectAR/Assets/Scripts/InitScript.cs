using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScript : MonoBehaviour
{
    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        //Set in build settings in player settings in player in resolution and presentation in default orientation
        //Screen.orientation = ScreenOrientation.Portrait;
        Application.targetFrameRate = 60;

    }
}
