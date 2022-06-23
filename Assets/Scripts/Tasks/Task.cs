using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    void Awake()
    {

    }

    public virtual void OpenUI()
    {
        Debug.Log("Task has been opened");
    }
}
