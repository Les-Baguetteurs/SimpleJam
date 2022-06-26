using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathCanvasUI : MonoBehaviour
{
    public GameObject MathCanvas;  
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(MathCanvas, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
