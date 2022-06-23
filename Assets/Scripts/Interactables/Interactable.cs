using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Task task;
    public Sprite defaultSprite;
    public Sprite focusedSprite;
    private SpriteRenderer spriteRenderer;
    private Collider2D collider2d;

    bool isFocus = false;

    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

    public void Interact()
    {
        task.OpenUI();
    }

    void Update()
    {
        if (!isFocus) return;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
            player.SetFocus(this);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
            player.RemoveFocus();
    }
}
