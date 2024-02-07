using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class MenuClues : MonoBehaviour
{
    public Sprite Clues;
    public int whichClue;
    public GameObject GameManager;
    public string content;
    public Button but;
    public GameObject leftPage;
    public GameObject rightPage;

    void Start()
    {
        but.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (GameManager.GetComponent<GameManager>().clueNum.Contains(whichClue))
        {
            leftPage.GetComponent<TMPro.TextMeshProUGUI>().text = content;
        }
        else
        {
            leftPage.GetComponent<TMPro.TextMeshProUGUI>().text = "Look harder";
        }
    }

}
