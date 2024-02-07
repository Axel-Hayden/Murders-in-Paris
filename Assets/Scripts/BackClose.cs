using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BackClose : MonoBehaviour
{
    public Button but;
    public GameObject GameManager;

    void Start()
    {
        but.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        GameManager.GetComponent<GameManager>().isAnimation = false;
    }
}
