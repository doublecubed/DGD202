using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStupidObject : MonoBehaviour
{
    public static GlobalStupidObject Instance;

    public Animator moonAnimator;
    
    private void Awake()
    {
        Instance = this;
    }

    public void SlowTheMoon()
    {
        moonAnimator.SetFloat("moonspeed" , 0.1f);
    }

    public void SpeedUpTheMoon()
    {
        moonAnimator.SetFloat("moonspeed", 0.5f);
    }
    
}
