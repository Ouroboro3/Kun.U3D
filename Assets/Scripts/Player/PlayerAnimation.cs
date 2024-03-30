using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;
    public PlayerController controller;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Velo.Y",rb.velocity.y);
        animator.SetFloat("Velo.X",rb.velocity.x);
        animator.SetBool("isAir", controller.isAir);
    }
}
