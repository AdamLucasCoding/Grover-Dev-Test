////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: ChestEvent.cs
//FileType: C# Unity Script
//
//Author: Adam Lucas
//Completion Date: Jan 3rd, 2021
//Copy Rights: Grover Games / Adam Lucas
//
//Description:
//A simple function to be called on the event invoked by a the click of the 9 chest buttons.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestEvent : MonoBehaviour
{
    public RoundObject RoundInfo;

    public void OpenChest()
    {
        RoundInfo.PullChest();

        this.gameObject.SetActive(false);
    }

}
