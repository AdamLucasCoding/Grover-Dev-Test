using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablerObject : MonoBehaviour
{
    void EnableObject()
    {
        this.GetComponent<GameObject>().SetActive(true);
    }

    void DisableObject()
    {
        this.GetComponent<GameObject>().SetActive(true);
    }
}
