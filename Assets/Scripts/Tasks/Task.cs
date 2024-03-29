using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Task : MonoBehaviour
{
    TMP_Text timer;
    
    Interactable interactable;

    public virtual void Start() {
        timer = gameObject.GetComponentInChildren<TMP_Text>();
        Debug.Log("timer: " + timer);
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

    public void FailTask() {
        interactable.FailTask();
        CloseUI();
    }

    public void OpenUI(Interactable interactable)
    {
        Instantiate<Task>(this).SetInteractable(interactable);
    }

    public virtual void CloseUI()
    {
        Destroy(gameObject);
    }
}
