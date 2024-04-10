using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleport : Collidable
{
    public static float x,y;
    public string sceneName;
    public Animator anim;
    public GameObject player;
    private string lastRoom;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            //Teleport
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            if(x != 0 && y != 0)
                player.transform.position = new Vector3(x,y,0);
            if(anim.GetFloat("Speed") != 0)
            {
                float hor = anim.GetFloat("Horizontal");
                float ver = anim.GetFloat("Vertical");
                //Debug.Log(hor);
                //Debug.Log(ver);
                if(hor == 0 && ver == -1)
                {
                    x = (float) player.transform.position.x;
                    y = (float) player.transform.position.y + 2;
                    Debug.Log(x);
                    Debug.Log(y);
                }
            }

            
        }
        if (coll.name == "Player")
        {
            lastRoom = LevelCheck.PreviousLevel;
            Debug.Log(lastRoom);
        }
    }
}
