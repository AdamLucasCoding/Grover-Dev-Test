using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayCanvasChecker : MonoBehaviour
{
    public RoundStart Player;
    public EnablerObject PlayEnabler;
    public EnablerObject BuyEnabler;

    // Start is called before the first frame update
    void Start()
    {
        Player.OnRoundStarted += RoundStarted;
    }

    public void RoundStarted()
    {
        //Disable the play button canvas
        PlayEnabler.DisableObject();

        //Enable the Buy In Canvas
        BuyEnabler.EnableObject();
        //Insert call or event to trigger UI animations
    }
}
