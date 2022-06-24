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
    }
    public override void OpenUI()
    {
        base.OpenUI();
    }

    public void OnClick()
    {
        currentFill += fillPerClick;
    }
    void Update()
    {
        currentFill = Mathf.Clamp01(currentFill - decayPerSecond * Time.deltaTime);
        progressBar.value = currentFill;
        if (currentFill == 1)
        {
            decayPerSecond = 0;
            CloseUI();
        }
    }
}
