using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskSpamButton : Task
{
    public float fillPerClick = 0.05f;
    public float decayPerSecond = 0.1f;
    float currentFill;
    Slider progressBar;
    float intialLength;
    void Awake()
    {
        progressBar = GetComponentInChildren<Slider>();
        Debug.Log(progressBar);
    }

    public void OnClick()
    {
        currentFill += fillPerClick;
    }
    override public void Update()
    {
        base.Update();
        currentFill = Mathf.Clamp01(currentFill - decayPerSecond * Time.deltaTime);
        progressBar.value = currentFill;
        if (currentFill == 1)
        {
            decayPerSecond = 0;
            CompleteTask();
        }
    }
}
