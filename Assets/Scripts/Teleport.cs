using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleport : Collidable
{

    public string sceneName;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            //Teleport
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
