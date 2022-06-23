using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{


    public float score = 0;  
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null) {  
            score += 1 * Time.deltaTime;  
          
            
        }
    }
}
