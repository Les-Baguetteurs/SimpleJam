using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSpamButton : Task
{
    public override void OpenUI()
    {
        base.OpenUI();
        Debug.Log("Task has been opened AGAIN");
    }
}
