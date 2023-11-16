using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public sealed class Interactable : MonoBehaviour
{
    public Task task;
    private SpriteRenderer spriteRenderer;
    private Collider2D collider2d;
    private TMP_Text timer;
    private float timeLeft;
    private bool isActivated;

    bool isFocus = false;

    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = GetComponentInChildren<TMP_Text>();
        isActivated = false;
    }
    void Start()
    {
        timeLeft = TaskManager.Instance.timePerTask;
    }

    void Update()
    {
        if (!isActivated)
        {
            timer.text = "";
            return;
        }
        timeLeft -= Time.deltaTime;
        timer.text = timeLeft.ToString("00.00");
        if (timeLeft < 0)
        {
            FailTask();
        }
    }

    public float GetTimeLeft() {
        return timeLeft;
    }

    public void OnFocused()
    {
        isFocus = true;
        spriteRenderer.color = new Color( 1,0,0, 1);
    }

    public void OnDefocused()
    {
        isFocus = false;
        spriteRenderer.color = new Color (50,50,50,1);
    }

    public bool Activate()
    {
        if (isActivated) return false;
        isActivated = true;
        timeLeft = TaskManager.Instance.timePerTask;

        Collider2D[] overlaps = new Collider2D[1];
        collider2d.OverlapCollider(new ContactFilter2D().NoFilter(), overlaps);
        if (overlaps[0] != null)
        {
            PlayerController player = overlaps[0].GetComponent<PlayerController>();
            if (player != null)
                player.SetFocus(this);
        }
        // TODO set texture to broken
        return true;
    }

    public void CompleteTask()
    {
        isActivated = false;
        TaskManager.Instance.CompleteTask(1);
    }

    public void FailTask() {
        isActivated = false;
        TaskManager.Instance.FailTask();
    }

    public void Interact()
    {
        if (!isActivated || !isFocus) return;
        task.OpenUI(this);
        OnDefocused();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActivated) return;
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
            player.SetFocus(this);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!isActivated) return;
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
            player.RemoveFocus();
    }
}
