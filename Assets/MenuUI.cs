using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public GameObject CanvasMenu;  
    public GameObject Button;  
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(CanvasMenu, transform.position, Quaternion.identity);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
