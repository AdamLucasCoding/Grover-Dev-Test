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

        
        GetComponent<TextMeshProUGUI>().text = Balance.ToString("F2");

        //Subscribe to balance change.
    }
    //Balance has changed event.

    //Current balance changed.
}
