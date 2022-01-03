////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: ChestEnabler.cs
//FileType: C# Unity Script
//
//Author: Adam Lucas
//Completion Date: Jan 3rd, 2021
//Copy Rights: Grover Games / Adam Lucas
//
//Description:
//Keeps a public list of every chest button and is capable of resetting all of them at the end
//of a round or locking all of them upon .command
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestEnabler : MonoBehaviour
{
    public List<Button> ChestReenablers;

    public void Reinstate()
    {
        for (int i = 0; i < ChestReenablers.Count; i++)
        {
            ChestReenablers[i].interactable = true;
        }
    }

    public void Lock()
    {
        for (int i = 0; i < ChestReenablers.Count; i++)
        {
            ChestReenablers[i].interactable = false;
        }
    }

    public void Reset()
    {
        for (int i = 0; i < ChestReenablers.Count; i++)
        {
            ChestReenablers[i].gameObject.SetActive(true);
        }

        Reinstate();
    }
}
