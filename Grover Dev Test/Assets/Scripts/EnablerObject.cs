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
