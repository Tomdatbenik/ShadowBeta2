using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalk : MonoBehaviour
{
    public float walkingSpeed;

    private Animator animator;

    private Vector2 lookDirection = new Vector2(1, 0);

    private float Walking = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Get animator of this component
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = GetRandomFloat();

        Vector2 movement = new Vector2(horizontal, 0.0f);

        if (!Mathf.Approximately(movement.x, 0.0f))
        {
            if (movement.x > 0)
            {
                transform.Translate(walkingSpeed * new Vector2(transform.position.x + 1f, 0f )* Time.deltaTime, Space.World);
            }
            else
            {   
                transform.Translate(walkingSpeed * new Vector2(transform.position.x - 1f, 0f) * Time.deltaTime, Space.World);
            }
           
            lookDirection.Set(movement.x, movement.y);
            lookDirection.Normalize();
        }
        animator.SetFloat("Horizontal", lookDirection.x);
        animator.SetFloat("Speed", movement.magnitude);
    }


    private float GetRandomFloat()
    {
        int random = Random.Range(0, 100);

        if(Walking != 0)
        {
            if(Walking < 0)
            {
                Walking++;
            }
            else
            {
                Walking--;
            }
            return Walking;
        }

        if(random > 97)
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
