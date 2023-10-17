using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : Collectable
{
    public Sprite Clues;
    public Sprite Atlas_1;
    public int whichClue;
    public GameObject GameManager;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = Atlas_1;
            GameManager.GetComponent<GameManager>().clueNum.Add(whichClue);
            Debug.Log(GameManager.GetComponent<GameManager>().clueNum[0]);
        }
    }
}
