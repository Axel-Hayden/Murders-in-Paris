using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Mover
{

    public GameObject GameManager;

    protected override void Start()
    {
        base.Start();

    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (GameManager.GetComponent<GameManager>().isAnimation != true)
            UpdateMotor(new Vector3(x, y, 0));


    }

}