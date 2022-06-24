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
        Instantiate(gameObject);
    }

    public virtual void CloseUI()
    {
        Destroy(gameObject);
    }
}
