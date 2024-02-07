using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeState : MonoBehaviour
{
    public bool IsPlaying => Time.timeScale > 0;

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }
}
