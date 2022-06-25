using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Task : MonoBehaviour
{
    TMP_Text timer;
    
    Interactable interactable;

    void Start() {
        timer = gameObject.GetComponentInChildren<TMP_Text>();
    }
    public virtual void Update()
    {
        float time = interactable.GetTimeLeft();
        timer.text = time.ToString("00.00");
        if (time < 0) {
            CloseUI();
        }
    }

    void SetInteractable(Interactable interactable) {
        this.interactable = interactable;
    }

    public void CompleteTask() {
        interactable.CompleteTask();
        CloseUI();
    }

    public void OpenUI(Interactable interactable)
    {
        Instantiate<Task>(this).SetInteractable(interactable);
    }

    public void CloseUI()
    {
        Destroy(gameObject);
    }
}
