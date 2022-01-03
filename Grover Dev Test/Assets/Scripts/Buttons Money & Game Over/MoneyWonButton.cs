////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: MoneyWonButton.cs
//FileType: C# Unity Script
//
//Author: Adam Lucas
//Completion Date: Jan 3rd, 2021
//Copy Rights: Grover Games / Adam Lucas
//
//Description:
//Brings the player back to the game after winning some of the money.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyWonButton : MonoBehaviour
{
    public ChestEnabler ChestLocker;
    public EnablerObject CashTakenEnabler;

    public void ClaimMoney()
    {
        CashTakenEnabler.DisableObject();
        ChestLocker.Reinstate();
    }
}
