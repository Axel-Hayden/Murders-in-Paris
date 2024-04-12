using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class Teleport : Collidable
{
    public string sceneName;
    private string lastRoom;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            //Teleport
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }

        if (coll.name == "Player")
        {
            lastRoom = LevelCheck.PreviousLevel;
            Debug.Log(lastRoom);
        }
    }
}
    
