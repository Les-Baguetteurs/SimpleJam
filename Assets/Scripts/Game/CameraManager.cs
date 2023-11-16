using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{

    public GameObject player;
    public GameObject background;
    public float maxLookDist;
    public float steepness;
    public float parallaxFactor;
    private PlayerInputActions playerControls;
    private InputAction look;

    void Awake() {
        playerControls = new PlayerInputActions();
    }

    void OnEnable() {
        look = playerControls.Player.Look;
        look.Enable();
    }
    
    void LateUpdate() {
        float deltaX = look.ReadValue<Vector2>().x - Screen.width / 2f;
        float deltaY = look.ReadValue<Vector2>().y - Screen.height / 2f;
                
        gameObject.transform.position = new Vector3(player.transform.position.x + exponentialDecay(deltaX), player.transform.position.y + exponentialDecay(deltaY), -10);

        background.transform.position = new Vector3(
            transform.position.x + player.transform.position.x* parallaxFactor,
            transform.position.y + player.transform.position.y * parallaxFactor,
            10);
    }

    float exponentialDecay(float num) {
        // 1/x graph
        float y = -maxLookDist / (steepness * Mathf.Abs(num) + maxLookDist) + 1;
        if (num >= 0) return y;
        return -y;
    }
}
