using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class Scene : MonoBehaviour
{
    //public ScoreScript GameScene;  
    public int BHCounter;  
    

	//  int BHCounter
	public void LoadScene(string Scene) {  
SceneManager.LoadScene(1);  


}    
    // Start is called before the first frame update
    void Start()
    {
        //GameScene.Backbone.GetComponent<ScoreScript>();  
        //GameScene.Update();  
        //gameObject.Find("Backbone").GetComponent<ScoreScript>().Update();    
        //var m_ScoreScript = GameObject.FindObjectOfType(typeof(ScoreScript)) as ScoreScript;  
        //m_ScoreScript.Start();  
        //BHCounter = 1;  
    }

    // Update is called once per frame
    void Update()  
    {
        var m_ScoreScript = GameObject.FindObjectOfType(typeof(ScoreScript)) as ScoreScript;  
        m_ScoreScript.Start();
        //BHCounter =+ 1;  
        //debug.log(BHCounter);  
    }
}