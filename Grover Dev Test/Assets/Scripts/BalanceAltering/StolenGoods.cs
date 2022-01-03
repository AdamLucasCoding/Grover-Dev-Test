////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: StolenGoods.cs
//FileType: C# Unity Script
//
//Author: Adam Lucas
//Completion Date: Jan 3rd, 2021
//Copy Rights: Grover Games / Adam Lucas
//
//Description:
//Keeps track of changes to the running balance in the game manager to be displayed
//during the selections.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StolenGoods : MonoBehaviour
{
    public GameManager Manager;

    private double Balance = 0;



    private void Start()
    {
        //initialize variables
        Balance = Manager.RunningBalance;


        GetComponent<TextMeshProUGUI>().text = "$" + Balance.ToString("F2");

        //Subscribe to balance change.
        Manager.OnStolenUpdate += UpdateBalance;
    }

    //Current balance changed. Update display.
    void UpdateBalance()
    {
        //initialize variables
        Balance = Manager.RunningBalance;


        GetComponent<TextMeshProUGUI>().text = "$" + Balance.ToString("F2");
    }
}
