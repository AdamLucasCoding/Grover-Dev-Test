////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: BalanceChecker.cs
//FileType: C# Unity Script
//
//Author: Adam Lucas
//Completion Date: Jan 3rd, 2021 
//Copy Rights: Grover Games / Adam Lucas
//
//Description:
//Runs a simple check on if an amount passed is less that the current balance.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceChecker : MonoBehaviour
{
    //Reference to game manager to fire the OnBuyIn event.
    public GameManager Manager;


    public bool BalanceCheck (double amount)
    {
        return amount <= Manager.CurrentBalance;
    }
}
