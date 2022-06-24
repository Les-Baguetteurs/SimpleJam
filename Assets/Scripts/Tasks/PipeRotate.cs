using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class PipeRotate : Task
{
    
   public void RotatePipe( GameObject button)
   {
    button.transform.Rotate(new Vector3(0,0,90));


   }
   
}
