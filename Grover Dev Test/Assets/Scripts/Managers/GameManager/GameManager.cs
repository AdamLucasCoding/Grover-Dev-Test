////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: GameManager.cs
//FileType: C# Unity Script
//
//Author: Adam Lucas
//Completion Date: Jan 3rd, 2021
//Copy Rights: Grover Games / Adam Lucas
//
//Description:
//This script acts as a central hub for the rest of the code to come together
//around in the for of event subscriptions. Also stores money information and
//is in charge of changing game states by invoking events.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    //Balance for the Player
    public double CurrentBalance = 10.00f;
    public double RunningBalance = 0.0f;
    public double CashEvent = 0.0f;

    public delegate void NoParameters();

    //Event List.
    public event NoParameters OnBuyIn;
    public event NoParameters AfterBuyIn;
    public event NoParameters OnBalanceUpdate;
    public event NoParameters OnStolenUpdate;
    public event NoParameters OnGameOver;

    // Start is called before the first frame update
    void Start()
    {
        OnBuyIn += BoughtIn;
    }

    public void SetCurrentDenomination(double amount)
    {
        CashEvent = amount;
        OnBuyIn?.Invoke();

        return;
    }

    public void BoughtIn()
    {
        //Edit player balance.
        CurrentBalance -= CashEvent;

        //Insert card functions here.

        //Update the Balance.
        OnBalanceUpdate?.Invoke();

        //Start the game.
        AfterBuyIn?.Invoke();

        return;
    }

    public void UpdateRunningBalance(double amount)
    {
        RunningBalance += amount;

        OnStolenUpdate?.Invoke();
        return;
    }

    public void ResetGame()
    {
        CurrentBalance += RunningBalance;
        RunningBalance = 0.0f;

        OnBalanceUpdate?.Invoke();
        OnStolenUpdate?.Invoke();

        OnGameOver?.Invoke();
    }
}
