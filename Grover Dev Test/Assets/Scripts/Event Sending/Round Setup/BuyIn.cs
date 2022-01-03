////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: BuyIn.cs
//FileType: C# Unity Script
//
//Author: Adam Lucas
//Completion Date: Jan 3rd, 2021
//Copy Rights: Grover Games / Adam Lucas
//
//Description:
//Checks to see if the player's balance is able to afford the value of the wager
//selected.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuyIn : MonoBehaviour
{
    [SerializeField] private double ThisAmount = 0;

    //Reference to game manager to fire the OnBuyIn event.
    public GameManager Manager;
    //Reference to the buy in manager to check if current balance can afford the button value.
    public BalanceChecker Checker;

    public void SendBuyIn()
    {
        if (Checker.BalanceCheck(ThisAmount))
        {
            //Brings this buttons denomination value into the manager via setter funciton
            Manager.SetCurrentDenomination(ThisAmount);
        }
        else
        {
            //TEST
            Debug.LogWarning("Insufficient funds.");

            //RETURNFLAG
            //Enumerate a message that there are insufficient funds. If button spammed, reset enumeration counter.

            //Unable to add this feature in time. As of now, nothing will happen to the balance.
        }


    }
}
