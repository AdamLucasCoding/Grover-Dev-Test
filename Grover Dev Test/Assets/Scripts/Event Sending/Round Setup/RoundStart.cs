////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: RoundStart.cs
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


public class RoundStart : MonoBehaviour
{
    //Creates delegate and event for other scripts to subscribe to,
    //so the code can maintain flexibility.
    public event Action OnRoundStarted;

    public void SendStartOfRound()
    {
        //Fires event
        OnRoundStarted?.Invoke();

        //Debug test message DELETE
        Debug.Log("StartOfRound event fired.");

        return;
    }
}
