using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceScript : MonoBehaviour
{
    public float distance;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = distance - (Time.deltaTime);  
        
    }
    void distanceIncrease(float increase) {  
        distance =+ increase;  
        Debug.Log(distance);


    }
}
