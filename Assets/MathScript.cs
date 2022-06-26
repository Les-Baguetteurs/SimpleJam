using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  


public class MathScript : MonoBehaviour
{
    //Random random = new Random();
    //int randomNumber = random.Next(0, 11);  
    public TextMeshProUGUI txt;  
    public GameObject Canvas;  
    public string input;  
    
    // Start is called before the first frame update
    void Start()
    {
        //txt.text = "hi";  
        //Instantiate(Canvas, new Vector3(0, 0, 0), Quaternion.identity);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MathProblem(){
        int randomNumber1 = Random.Range(0, 11);
        int randomNumber2 = Random.Range(0, 11);  
        int MathAns = randomNumber1 + randomNumber2; 
        txt.text = randomNumber1.ToString() + " + " + randomNumber2.ToString();  
        Debug.Log("clicked!");
        
        
    }
    public void Input(string inputAnswer){
        input = inputAnswer;  
        Debug.Log(input);  
    }

}
