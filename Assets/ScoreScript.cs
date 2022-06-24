using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{


    public float score = 0;  
    
    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log(score);  
        score =+ 1;  
    }

    // Update is called once per frame
    public void Update()
    {
        score += 1;  
        //if (GameObject.FindGameObjectWithTag("Player") != null) {  
        //    score += 1 * Time.deltaTime;  
          
            
            Debug.Log(score);
        Debug.Log(score);
        {
        }
    }

    
}
