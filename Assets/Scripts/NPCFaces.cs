using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFaces : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite downSprite, upSprite, leftSprite, rightSprite, defaultSprite;


    /*protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player"){
            Debug.Log("happened");
            //right movement
            if(GameManager.movex == -1)
                spriteRenderer.sprite = rightSprite;
            //left movement
            else if (GameManager.movex == 1)
                spriteRenderer.sprite = leftSprite;
            //up movement
            else if (GameManager.movey == -1)
                spriteRenderer.sprite = upSprite;
            //down movement
            else if (GameManager.movey == 1)
                spriteRenderer.sprite = downSprite;
        }
    }*/
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.name == "Player")
        {
            //up movement
            if (GameManager.movey == -1)
                spriteRenderer.sprite = upSprite;
            //down movement
            else if(GameManager.movey == 1)
                spriteRenderer.sprite = downSprite;
            //right movement
            else if(GameManager.movex == -1)
                spriteRenderer.sprite = rightSprite;
            //left movement
            else if(GameManager.movex == 1)
                spriteRenderer.sprite = leftSprite;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        spriteRenderer.sprite = defaultSprite;
    }
}
