////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: CanvasHandler.cs
//FileType: C# Unity Script
//
//Author: Adam Lucas
//Completion Date: Jan 3rd, 2021
//Copy Rights: Grover Games / Adam Lucas
//
//Description:
//In Charge of switching UI game states as directed by the game manager.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CanvasHandler : MonoBehaviour
{
    //Reference to game manager to subscribe to the AfterBuyIn event.
    public GameManager Manager;
    //Grabs the play button to subscribe to the initiating event.
    public RoundStart Player;

    //List of enablers in the scene.
    public EnablerObject PlayEnabler;
    public EnablerObject BuyEnabler;
    public EnablerObject SetupEnabler;
    public EnablerObject ChestEnabler;

    // Start is called before the first frame update
    void Start()
    {
        Player.OnRoundStarted += RoundStarted;
        Manager.AfterBuyIn += BoughtIn;
        Manager.OnGameOver += GameOverReset;
    }

    public void RoundStarted()
    {
        //Disable the play button canvas
        PlayEnabler.DisableObject();

        //Enable the Buy In Canvas
        BuyEnabler.EnableObject();
        //Insert call or event to trigger UI animations
    }

    
    public void BoughtIn()
    {
        //Disables setup enabler leaving the Play Screen enabler off for quick replay cycles.
        SetupEnabler.DisableObject();

        //Enables the Chest Screens enabler to start the game proper.
        ChestEnabler.EnableObject();
    }

    public void GameOverReset()
    {
        /*List of enablers in the scene.
        public EnablerObject PlayEnabler;
        public EnablerObject BuyEnabler;
        public EnablerObject SetupEnabler;
        public EnablerObject ChestEnabler; 
         */

        ChestEnabler.DisableObject();
        SetupEnabler.EnableObject();
    }
}
