using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SuspectButton : MonoBehaviour
{
    public Button but;
    public GameObject Connections;
    public int num;
    public GameObject Pins;

    void Start()
    {
        but.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Pins.SetActive(true);
        for (int i = 0; i < 8; i++)
        {
            if (i != num)
            {
                Connections.transform.GetChild(i).gameObject.SetActive(false);
            }
            else
                Connections.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
