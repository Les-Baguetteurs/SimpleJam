using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float walkSpeed = 3;
    public float rayCastDist = 0.01f;
    public float climbSpeed = 2;
    public float horizontalAcceleration = 1;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2d;
    private Collider2D collider2d;
    internal Animator animator;

    private Bounds actorBounds;
    private bool isClimbing, isRunning;
    private bool _collidesUp, _collidesRight, _collidesDown, _collidesLeft;
    private float horizontalVelocity, verticalVelocity;
    private PlayerInputActions playerControls;
    private InputAction move;
    private InputAction interact;
    private ContactFilter2D ladderFilter, interactableFilter;
    private Interactable focus;
    Collider2D[] interactableResults;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        actorBounds = collider2d.bounds;
        playerControls = new PlayerInputActions();
        ladderFilter = new ContactFilter2D();
        // 6 is the user defined Climbable layer
        ladderFilter.SetLayerMask(1 << 6);
        // 7 is the user defined Interactable layer
        interactableFilter.SetLayerMask(1 << 7);
        interactableResults = new Collider2D[1];
    }

    void Update()
    {
        // SelectNearestInteractable();

        Vector2 vect = move.ReadValue<Vector2>();
        animator.SetBool("isRunning", vect.x != 0);
        animator.SetBool("isClimbing", vect.y != 0 && IsNearClimbable());
    }

    protected void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
        interact = playerControls.Player.Interact;
        interact.Enable();
        interact.performed += Interact;
    }

    protected void OnDisable()
    {
        move.Disable();
        interact.Disable();
    }

    private void FixedUpdate()
    {
        Move(move.ReadValue<Vector2>());
    }

    private void Move(Vector2 targetVel)
    {
        CheckCollisions();
        CalcHorizontal(targetVel.x);
        CalcVertical(targetVel.y);
        rigidbody2d.velocity = new Vector2(horizontalVelocity, verticalVelocity);
    }

    private void CalcHorizontal(float targetVel)
    {
        // float distToTarget = targetVel - horizontalVelocity;
        // horizontalVelocity += Mathf.Clamp(distToTarget * horizontalAcceleration, -horizontalAcceleration, horizontalAcceleration) * Time.fixedDeltaTime;
        horizontalVelocity = targetVel * walkSpeed;
        if (_collidesRight && horizontalVelocity > 0) horizontalVelocity = 0;
        else if (_collidesLeft && horizontalVelocity < 0) horizontalVelocity = 0;
    }

    private void CalcVertical(float targetVel)
    {
        if (IsNearClimbable())
        {
            verticalVelocity = targetVel * climbSpeed;
            return;
        }
        verticalVelocity += Physics2D.gravity.y * Time.fixedDeltaTime;
        if (_collidesUp && verticalVelocity > 0) verticalVelocity = 0;
        if (_collidesDown && verticalVelocity < 0) verticalVelocity = 0;
    }

    private void CheckCollisions()
    {
        var b = new Bounds(transform.position + actorBounds.center, actorBounds.size);
        // 3 is the user defined layer for the ground

        _collidesUp = Physics2D.BoxCast(transform.position, actorBounds.size, 0, Vector2.up, rayCastDist, 1 << 3);
        _collidesRight = Physics2D.BoxCast(transform.position + Vector3.up, actorBounds.size, 0, Vector2.right, rayCastDist, 1 << 3);
        _collidesDown = Physics2D.BoxCast(transform.position, actorBounds.size, 0, Vector2.down, rayCastDist, 1 << 3);
        _collidesLeft = Physics2D.BoxCast(transform.position + Vector3.up, actorBounds.size, 0, Vector2.left, rayCastDist, 1 << 3);
    }

    private bool IsNearClimbable()
    {
        Collider2D[] results = new Collider2D[1];
        rigidbody2d.OverlapCollider(ladderFilter, results);
        return results[0];
    }
    // private void SelectNearestInteractable()
    // {
    //     interactableResults[0] = null;
    //     rigidbody2d.OverlapCollider(interactableFilter, interactableResults);
    //     if (interactableResults[0] == null)
    //     {
    //         RemoveFocus();
    //         return;
    //     }
    //     SetFocus(interactableResults[0].gameObject.GetComponent<Interactable>());
    // }

    public void SetFocus(Interactable target)
    {
        RemoveFocus();
        focus = target;
        target.OnFocused();
    }

    public void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if (focus != null)
        {
            focus.Interact();
        }
    }
}