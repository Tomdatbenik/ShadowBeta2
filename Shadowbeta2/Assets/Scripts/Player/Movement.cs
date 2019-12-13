using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkingSpeed;

    private Rigidbody2D rigidbody;
    private Animator animator;
    private Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(horizontal, 0.0f);
        
        if (!Mathf.Approximately(movement.x, 0.0f))
        {
            transform.Translate(walkingSpeed * movement.normalized * Time.deltaTime, Space.World);
            lookDirection.Set(movement.x, movement.y);
            lookDirection.Normalize();
        }
        animator.SetFloat("Horizontal", lookDirection.x);
        animator.SetFloat("Speed", movement.magnitude);
    }
}
