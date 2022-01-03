////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: RoundObject.cs
//FileType: C# Unity Script
//
//Author: Adam Lucas
//Creation Date: Dec 30th, 2021
//Last Modified: 
//Copy Rights: Grover Games / Adam Lucas
//
//Description:
//Runs the game proper by doing all of the math and random selections for the chests to display in 
//the game proper by calling a function to pull out the next value until it reaches a zero.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RoundObject : MonoBehaviour
{
    //TEST VARIABLES
    //Toggle testingRoll in the Unity menu to be able to enter your own values for roll
    public bool testingRoll = false;
    public int roll = 1;
    
    //Reference to game manager to get the current round denomination.
    public GameManager Manager;

    //Reference to the chest enabler to lock all chests on a game over to prevent a game crash.
    public ChestEnabler ChestLocker;

    //Lists that can be made in the editor that will determine a randomly rolled multiplier
    //when a low, middle or high multiplier is rolled for the round.
    public List<int> MultiplierOddsLow = new List<int>();
    public List<int> MultiplierOddsMid = new List<int>();
    public List<int> MultiplierOddsHi = new List<int>();
    
    //Lists that contain the odds of getting each multiplier. MUST BE EQUAL IN LENGTH TO THE CORRESPONDING LIST
    //IN THE UNITY EDITOR! Each index MUST match the index of the desired multiplier in the other array, or else
    //the incorrect multiplier will be given those odds.
    public List<int> MultiplierOddsLowTable = new List<int>();
    public List<int> MultiplierOddsMidTable = new List<int>();
    public List<int> MultiplierOddsHiTable = new List<int>();

    //Target list for the final roll on the table.
    public List<int> MultiplierOddsFinal = new List<int>();

    //Current multiplier for the round.
    public int MultiplierCurrent = 0;

    //The determined amount that the player will win this round.
    public double WinForRound = 0;

    //These three lists contain the odds of how many chests the rewards are split into during the round.
    //Follows the same logic as the corresponding odds tables above. FIRST TWO MUST BE THE SAME LENGTH
    //IN UNITY EDITOR!
    public List<int> NumOfChestsPossible = new List<int>();
    public List<int> NumOfChestsOdds = new List<int>();
    public List<int> NumOfChestsFinal = new List<int>();


    //The order of how chests will give out rewards. Triggers game over at first zero value.
    public List<double> WinForRoundOrder = new List<double>();
    private int ChestIndex = 0;

    //UI elements for the cash win from chests and fail screens.
    public EnablerObject GameOverImage;
    public TextMeshProUGUI MoneyWonText;
    public EnablerObject MoneyWonImage;

    private void Start()
    {
        //Subscribes to the event to restart setup.
        Manager.AfterBuyIn += SetupTheGame;

        //Puts the odds of number of chests into a usable format at the start to save efficiency.
        RollTable(NumOfChestsPossible, NumOfChestsOdds, NumOfChestsFinal);
    }

    public void SetupTheGame()
    {
        //Initial roll. Dependant on testing status.
        if (!testingRoll)
        {
            roll = Random.Range(1, 100);
        }

        Debug.Log(roll + " is the initial roll.");

        if ((1 <= roll) && (roll <= 50))
        {
            MultiplierCurrent = 0;

            WinForRound = MultiplierCurrent * Manager.CashEvent;
        }else if ((51 <= roll) && (roll <= 80))
        {
            RollTable(MultiplierOddsLow, MultiplierOddsLowTable, MultiplierOddsFinal);

            MultiplierCurrent = MultiplierOddsFinal[Random.Range(0, MultiplierOddsFinal.Count - 1)];

            MultiplierOddsFinal.Clear();
            //TEST
            Debug.Log(MultiplierCurrent + " Is the current multiplier.");

            WinForRound = MultiplierCurrent * Manager.CashEvent;

            //TEST
            Debug.Log(WinForRound + " Is the current total the player will win this round.");
        }else if ((81 <= roll) && (roll <= 95))
        {
            RollTable(MultiplierOddsMid, MultiplierOddsMidTable, MultiplierOddsFinal);

            MultiplierCurrent = MultiplierOddsFinal[Random.Range(0, MultiplierOddsFinal.Count - 1)];

            MultiplierOddsFinal.Clear();
            //TEST
            Debug.Log(MultiplierCurrent + " Is the current multiplier.");

            WinForRound = MultiplierCurrent * Manager.CashEvent;

            //TEST
            Debug.Log(WinForRound + " Is the current total the player will win this round.");
        }else if ((96 <= roll) && (roll <= 100))
        {
            RollTable(MultiplierOddsHi, MultiplierOddsHiTable, MultiplierOddsFinal);

            MultiplierCurrent = MultiplierOddsFinal[Random.Range(0, MultiplierOddsFinal.Count - 1)];

            MultiplierOddsFinal.Clear();
            //TEST
            Debug.Log(MultiplierCurrent + " Is the current multiplier.");

            WinForRound = MultiplierCurrent * Manager.CashEvent;

            //TEST
            Debug.Log(WinForRound + " Is the current total the player will win this round.");
        }

        MultiplierOddsFinal.Clear();

        Splitter();
    }

    
    private void RollTable (List<int> source, List<int> table, List<int> destination)
    {
        if (source.Count != table.Count)
        {
            Debug.LogWarning("There is an unaccounted for multiplier in the odds tables. ROUNDOBJECT.CS");
        }

        int index = 0;

        for (int i = 0; i < source.Count; i++)
        {
            for (int f = 0; f < table[index]; f++)
            {
                destination.Add(source[i]);
            }
            index++;
        }

        return;
    }


    void Splitter()
    {

        int RandomNumOfChests = NumOfChestsFinal[Random.Range(0, NumOfChestsFinal.Count - 1)];
        List<double> IndividualWinnings = new List<double>();
        float TempTotalWinnings = (float)System.Math.Round((float)WinForRound / 5, 2);

        for (int i = 0; i < RandomNumOfChests - 1; i++)
        {
            if (TempTotalWinnings >= 0.01)
            {
                IndividualWinnings.Add(System.Math.Round(Random.Range(.01f, TempTotalWinnings), 2));
                TempTotalWinnings -= (float)IndividualWinnings[IndividualWinnings.Count - 1];
            }
            else
            {
                break;
            }
            
        }

        if (TempTotalWinnings >= 0.01)
        {
            IndividualWinnings.Add(System.Math.Round(TempTotalWinnings, 2));
        }

        int TempIndex;
        WinForRoundOrder.Clear();

        while (0 < IndividualWinnings.Count)
        {
            TempIndex = Random.Range(0, IndividualWinnings.Count - 1);
            if (IndividualWinnings[TempIndex] > 0)
            {
                WinForRoundOrder.Add(IndividualWinnings[TempIndex] * 5);
            }

            IndividualWinnings.RemoveAt(TempIndex);
        }

        for (int i = 0; i < 9; i++)
        {
            WinForRoundOrder.Add(0);
        }
    }

    public void PullChest()
    {
        //Pull the next available index in the order.
        if (0 < WinForRoundOrder[ChestIndex])
        {
            MoneyWonText.text = "$" + WinForRoundOrder[ChestIndex].ToString("F2");
            Manager.UpdateRunningBalance(WinForRoundOrder[ChestIndex]);
            MoneyWonImage.EnableObject();
            ChestLocker.Lock();

            ChestIndex++;
            return;
        }
        //If not end the round, and lock all chests to prevent a game crash by going past the end of
        //the WinForRoundOrder list.
        else
        {
            GameOverImage.EnableObject();
            ChestLocker.Lock();
            ChestIndex = 0;
            return;
        }
    }
}
