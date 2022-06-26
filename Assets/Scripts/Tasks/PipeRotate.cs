using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class PipeRotate : Task
{
    public GameObject[] pipes;
    int[] rotations;

    public override void Start()
    {
        base.Start();
        rotations = new int[pipes.Length];
        RandomizeRotations();
    }


    public void RotatePipe(int j)
    {
        pipes[j].transform.Rotate(new Vector3(0, 0, 90));
        rotations[j]++;
        if (CheckRotations())
        {
            CompleteTask();
        }

    }

    public void RandomizeRotations()
    {
        for (int j = 0; j < 6; j++)
        {
            int num = Random.Range(0, 4);
            for (int i = 0; i < num; i++)
                RotatePipe(j);
        }

    }

    public bool CheckRotations()
    {
        foreach (int rotationCount in rotations)
        {
            if (rotationCount % 4 != 0)
            {
                return false;
            }
        }
        return true;
    }
}
