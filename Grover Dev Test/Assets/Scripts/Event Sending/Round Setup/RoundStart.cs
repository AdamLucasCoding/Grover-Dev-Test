////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: RoundStart.cs
//FileType: C# Unity Script
//
//Author: Adam Lucas
//Completion Date: Jan 3rd, 2021
//Copy Rights: Grover Games / Adam Lucas
//
//Description:
//Starts the game by invoking a C# event.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class RoundStart : MonoBehaviour
{
    //Creates an event for other scripts to subscribe to,
    //so the code can maintain flexibility.
    public event Action OnRoundStarted;

    public void SendStartOfRound()
    {
        //Fires event
        OnRoundStarted?.Invoke();

        return;
    }
}
