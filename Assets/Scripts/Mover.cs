using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    protected float ySpeed = 3.5f;
    protected float xSpeed = 4.0f;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }


    protected virtual void UpdateMotor(Vector3 input)
    {
        {
            //reset movedelta
            moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

            //swap spirit direction
            if (moveDelta.x > 0)
                transform.localScale = Vector3.one;
            else if (moveDelta.x < 0)
                transform.localScale = new Vector3(-1, 1, 1);


            //Blocking Movement Check
            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Blocking", "Collidable"));
            if (hit.collider == null)
            {
                //movement
                transform.Translate(0, moveDelta.y * Time.deltaTime, 0);


            }

            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Blocking", "Collidable"));
            if (hit.collider == null)
            {
                //movement
                transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);


            }
        }
    }

}
