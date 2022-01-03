////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: GameOverButton.cs
//FileType: C# Unity Script
//
//Author: Adam Lucas
//Completion Date: Jan 3rd, 2021
//Copy Rights: Grover Games / Adam Lucas
//
//Description:
//Starts the process of restarting the game from the game over screen.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverButton : MonoBehaviour
{
    public ChestEnabler ChestLocker;
    public EnablerObject GameOverEnabler;
    public GameManager Manager;

    public void RestartGame()
    {
        GameOverEnabler.DisableObject();
        ChestLocker.Reset();
        Manager.ResetGame();
    }
}
