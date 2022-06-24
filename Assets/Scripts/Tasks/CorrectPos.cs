using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectPos : MonoBehaviour
{
        public float correctPOS;
    void Update()
    {
        if (correctPOS == transform.eulerAngles.z)
    {
        Debug.Log("correct pos");
    }
    else 
    {
        Debug.Log("keep rotating");
    }
    }
}
