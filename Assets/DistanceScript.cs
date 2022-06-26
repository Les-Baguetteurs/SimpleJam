using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceScript : MonoBehaviour
{
    public float distance;  
    public bool started = false;  
    // Start is called before the first frame update
    public void Start()
    {
        distance = distance - (Time.deltaTime);


        Debug.Log(distance + "m");
    }

    // Update is called once per frame
    public void Update()
    {
        
        
        
        
        distance = distance - (Time.deltaTime);  
        Debug.Log(distance + "m");  
        
        }


    public void distanceDecrease(float decrease)    {

    }
    
    public void distanceIncrease(float increase) {  
        distance =+ increase;  
        Debug.Log(distance + "m");  


    }
    
    
    
    
}
