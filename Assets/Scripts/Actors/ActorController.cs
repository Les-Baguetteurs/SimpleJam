using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActorController : MonoBehaviour
{

    public float speed = 3;
    public float rayCastDist = 0.01f;
    public float horizontalAcceleration = 1;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2d;
    private Collider2D collider2d;
    internal Animator animator;

    public Bounds actorBounds;
    private bool isClimbing, isRunning;
    private bool _collidesUp, _collidesRight, _collidesDown, _collidesLeft;
    private float horizontalVelocity, verticalVelocity;

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        actorBounds = collider2d.bounds;
    }

    void Start()
    {

    }


    void Update()
    {
        Vector2 vect = GetIntendedVelocity();
        animator.SetBool("isRunning", vect.x != 0);
        animator.SetBool("isClimbing", vect.y != 0);
    }

    private void Move(Vector2 targetVel)
    {
        CheckCollisions();
        CalcHorizontal(targetVel.x);
        CalcHorizontal(targetVel.y);
        rigidbody2d.velocity = new Vector2(horizontalVelocity * Time.fixedDeltaTime, verticalVelocity * Time.fixedDeltaTime);
        Debug.Log(horizontalVelocity);
        Debug.Log(verticalVelocity);
        Debug.Log(rigidbody2d.velocity);
    }

    private void FixedUpdate() {
        Move(GetIntendedVelocity());
    }

    protected virtual Vector2 GetIntendedVelocity() {
        // TODO fix the method header
        return Vector2.zero;
    }

    private void CalcHorizontal(float targetVel) {
        float distToTarget = targetVel - horizontalVelocity;
        horizontalVelocity += Mathf.Clamp(distToTarget, -horizontalAcceleration, horizontalAcceleration);
        if (_collidesRight && horizontalVelocity > 0) horizontalVelocity = 0;
        else if (_collidesLeft && horizontalVelocity < 0) horizontalVelocity = 0;
    }

    private void CalcVertical(float targetVel) {
        if (isClimbing) {
            verticalVelocity = targetVel;
        }
        verticalVelocity += Physics2D.gravity.x;
        if (_collidesUp && verticalVelocity > 0) verticalVelocity = 0;
        if (_collidesDown && verticalVelocity < 0) verticalVelocity = 0;
    }

    private void CheckCollisions()
    {
        var b = new Bounds(transform.position + actorBounds.center, actorBounds.size);
        // 3 is the user defined layer for the ground
        _collidesUp = Physics2D.Raycast(transform.position, Vector2.up, rayCastDist, 1 << 3);
        _collidesRight = Physics2D.Raycast(transform.position, Vector2.right, rayCastDist, 1 << 3);
        _collidesDown = Physics2D.Raycast(transform.position, Vector2.down, rayCastDist, 1 << 3);
        _collidesLeft = Physics2D.Raycast(transform.position, Vector2.left, rayCastDist, 1 << 3);
    }
}
