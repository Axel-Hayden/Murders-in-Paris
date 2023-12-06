using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class NPC : Collectable
{

    protected override void OnCollide(Collider2D coll)
    {
        Debug.Log("Clue found");

    }
}

