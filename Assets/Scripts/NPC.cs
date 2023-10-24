using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Collectable
{

    protected override void OnCollide(Collider2D coll)
    {
        Debug.Log("Clue found");

    }

}
