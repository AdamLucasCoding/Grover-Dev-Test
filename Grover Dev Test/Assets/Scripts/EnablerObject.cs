////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: EnablerObject.cs
//FileType: C# Unity Script
//
//Author: Adam Lucas
//Completion Date: Jan 3rd, 2021
//Copy Rights: Grover Games / Adam Lucas
//
//Description:
//Allows the empty "Enabler" objects in the Unity Hierarchy to be commanded to enable
//or disable all of their child game objects.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnablerObject : MonoBehaviour
{
    public void EnableObject()
    {
        this.gameObject.SetActive(true);
    }

    public void DisableObject()
    {
        this.gameObject.SetActive(false);

    }
}
