using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Interactable : MonoBehaviour
{
    public Task task;
    public Sprite defaultSprite;
    public Sprite focusedSprite;
    private SpriteRenderer spriteRenderer;
    private Collider2D collider2d;
    private bool isActivated;

    bool isFocus = false;

    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isActivated = false;
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

    public void Activate() {
        isActivated = true;
        Debug.Log(gameObject.name + " has been activated");
        // TODO set texture to broken
    }

    public void Interact()
    {
        if (!isActivated || !isFocus) return;
        task.OpenUI();
        isActivated = false;
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
