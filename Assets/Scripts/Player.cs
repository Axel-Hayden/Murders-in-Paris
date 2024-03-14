using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Mover
{

    public GameObject GameManager;
    public Animator animator;
    Vector2 movement;

    protected override void Start()
    {
        base.Start();
    }

    private void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);


        if (GameManager.GetComponent<GameManager>().isAnimation != true)
            UpdateMotor(new Vector3(movement.x, movement.y, 0));
    }

}