using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class PipeRotate : Task
{
public GameObject[] pipes;
int rotations = 0;

public void Start()
{
    RandomizeRotations();

}


   public void RotatePipe( GameObject button)
   {
    button.transform.Rotate(new Vector3(0,0,90));
    rotations = (rotations + 1) % 3;
    if (CheckRotations())
    {
        CloseUI();
    }
    Debug.Log("rotations " + rotations);

   }

   public void RandomizeRotations ()
   {
    for (int j = 0; j< 6; j++)
    {
        RotatePipe( pipes[j]);
    }
    
   }

   public bool CheckRotations()
   {
    foreach ( GameObject pipe in pipes)
    {
        if ( (rotations % 3) == 0 )
        {
            return true;
        }
    }
    return false;
   }


   
}
