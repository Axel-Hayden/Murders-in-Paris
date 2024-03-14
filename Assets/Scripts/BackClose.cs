using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BackClose : MonoBehaviour
{
    public Button but;
    public GameObject GameManager;
    public GameObject Connections;
    public GameObject Pins;

    void Start()
    {
        but.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        GameManager.GetComponent<GameManager>().isAnimation = false;
        Pins.SetActive(false);

        for (int i = 0; i < 8; i++)
        {
            Connections.transform.GetChild(i).gameObject.SetActive(false);

        }
    }
}
