////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: DisplayBalance.cs
//FileType: C# Unity Script
//
//Author: Adam Lucas
//Completion Date: Jan 3rd, 2021
//Copy Rights: Grover Games / Adam Lucas
//
//Description:
//A simple script that subscribes to any changes to the current balance in the game
//manager, and updates them to all versions of this script in the scene.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayBalance : MonoBehaviour
{
    public GameManager Manager;

    private double Balance = 0;



    private void Start()
    {
        //initialize variables
        Balance = Manager.CurrentBalance;

        GetComponent<TextMeshProUGUI>().text = "$" + Balance.ToString("F2");

        //Subscribe to balance change.
        Manager.OnBalanceUpdate += UpdateBalance;
    }

    //Current balance changed. Update display.
    void UpdateBalance()
    {
        //initialize variables
        Balance = Manager.CurrentBalance;

        GetComponent<TextMeshProUGUI>().text = "$" + Balance.ToString("F2");
    }
}
