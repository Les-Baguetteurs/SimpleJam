using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    //public Button Button    
    // Start is called before the first frame update
    void Start()
    {
        //Button.onClick.AddListener(inc);  
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
