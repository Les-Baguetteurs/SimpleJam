using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public sealed class Interactable : MonoBehaviour
{
    public Task task;
    public Sprite defaultSprite;
    public Sprite focusedSprite;
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
            timer.text = "OK";
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
        spriteRenderer.sprite = focusedSprite;
    }

    public void OnDefocused()
    {
        isFocus = false;
        spriteRenderer.sprite = defaultSprite;
    }

    public bool Activate()
    {
        if (isActivated) return false;
        isActivated = true;
        timeLeft = TaskManager.Instance.timePerTask;
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
