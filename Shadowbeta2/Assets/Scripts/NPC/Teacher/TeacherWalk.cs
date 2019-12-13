using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherWalk : MonoBehaviour
{
    public float walkingSpeed;

    private Animator animator;

    private Vector2 lookDirection = new Vector2(1, 0);

    private float Walking = 0;

    public int WalkChance;

    public float MaxLeftX;
    public float MaxRightX;

    public bool IsWalking;

    // Start is called before the first frame update
    void Start()
    {
        //Get animator of this component
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(IsWalking)
        {
            float horizontal = GetRandomFloat();

            Vector2 movement = new Vector2(horizontal, 0.0f);

            if (!Mathf.Approximately(movement.x, 0.0f))
            {
                if (movement.x > 0)
                {
                    transform.Translate(walkingSpeed * new Vector2(1f, 0f) * Time.deltaTime, Space.World);
                }
                else
                {
                    transform.Translate(walkingSpeed * new Vector2(-1f, 0f) * Time.deltaTime, Space.World);
                }

                lookDirection.Set(movement.x, movement.y);
                lookDirection.Normalize();
            }
            animator.SetFloat("Horizontal", lookDirection.x);
            animator.SetFloat("Speed", movement.magnitude);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
        
    }


    private float GetRandomFloat()
    {
        if (transform.position.x < MaxLeftX)
        {
            if (Walking < 0)
            {
                Walking = 0;
            }
        }

        if (transform.position.x > MaxRightX)
        {
            if (Walking > 0)
            {
                Walking = 0;
            }
        }


        if (Walking != 0)
        {
            if (Walking < 0)
            {
                Walking++;
            }
            else
            {
                Walking--;
            }
            return Walking;
        }


        int random = Random.Range(0, 101);

        if (random > (100 - WalkChance))
        {
            Walking = Random.Range(-500, 501);
            return Walking;
        }
        else
        {
            return 0;
        }
    }
}
