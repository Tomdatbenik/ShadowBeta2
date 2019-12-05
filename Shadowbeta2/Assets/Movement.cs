using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(horizontal, 0.0f);

        //Character movement on x and z axis
        if (!Mathf.Approximately(movement.x, 0.0f))
        {
            transform.Translate(walkingSpeed * movement.normalized * Time.deltaTime, Space.World);
        }
    }
}
