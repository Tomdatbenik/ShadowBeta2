using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirtFollowTeacherAnimator : MonoBehaviour
{
    public Animator teacher;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //Get animator of this component
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetFloat("Horizontal", teacher.GetFloat("Horizontal"));
        animator.SetFloat("Speed", teacher.GetFloat("Speed"));
    }

}
