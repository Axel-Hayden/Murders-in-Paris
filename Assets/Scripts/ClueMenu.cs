using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class ClueMenu : MonoBehaviour
{
    public GameObject game;
    public GameObject change;
    public GameObject change1;
    public GameObject change2;
    public GameObject change3;
    public GameObject change4;
    public GameObject change5;

    void Start()
    {
        List<Sprite> suspects = game.GetComponent<GameManager>().suspectSprite;

        change.GetComponent<Image>().sprite = suspects.ElementAt(0);
        change1.GetComponent<Image>().sprite = suspects.ElementAt(1);
        change2.GetComponent<Image>().sprite = suspects.ElementAt(2);
        change3.GetComponent<Image>().sprite = suspects.ElementAt(3);
        change4.GetComponent<Image>().sprite = suspects.ElementAt(4);
        change5.GetComponent<Image>().sprite = suspects.ElementAt(5);
    }


}