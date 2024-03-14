using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuKeyPress : MonoBehaviour
{
    public GameObject GameManager, Menu, Pins, Connections, ClueInsp;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Menu.activeInHierarchy)
        {
            Menu.SetActive(false);
            GameManager.GetComponent<GameManager>().isAnimation = false;
            Pins.SetActive(false);
            for (int i = 0; i < 8; i++)
            {
                Connections.transform.GetChild(i).gameObject.SetActive(false);
            }
            ClueInsp.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Menu.activeInHierarchy == false)
        {
            Menu.SetActive(true);
            GameManager.GetComponent<GameManager>().isAnimation = true;
        }

    }
}
