////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: PlayScript1.cs
//FileType: C# Unity Script
//
//Author: Adam Lucas
//Creation Date: Dec 30th, 2021
//Last Modified: 
//Copy Rights: Grover Games / Adam Lucas
//
//Description:
//Starts the game by firing a C# event.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class PlayScript1 : MonoBehaviour
{
    //Creates delegate and event for other scripts to subscribe to,
    //so the code can maintain flexibility.
    public event EventHandler OnRoundStarted;

    public void SendStartOfRound()
    {
        //Fires event
        OnRoundStarted?.Invoke(this.OnRoundStarted, EventArgs.Empty);

        //Debug test message DELETE
        Debug.Log("StartOfRound event fired.");

        return;
    }
}
