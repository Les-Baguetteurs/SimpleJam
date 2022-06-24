using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{

    float [] rotations = {0, 90, 180, 270};


    private void Start()
    {
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0 , rotations[rand]);
        Debug.Log("this function happened");
    }
     void OnMouseDown()
    {
         Debug.Log("CLCIK");
        transform.Rotate(new Vector3(0,0,90));

       
    }
    // private void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         transform.Rotate(new Vector3 ( 0, 0, 90));
    //     }
        
    // }

   
}
