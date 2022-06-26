using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Increase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void inc(int inc){
        var m_ScoreScript = GameObject.FindObjectOfType(typeof(ScoreScript)) as ScoreScript;  
        m_ScoreScript.Start(); 
        m_ScoreScript.scoreIncrease(41);
    }
}
