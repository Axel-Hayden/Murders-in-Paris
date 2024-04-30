using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClueOpacity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < this.transform.childCount; i++)
        {
            GameObject child1 = this.transform.GetChild(i).gameObject;
            child1.transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color(1f,1f,1f,.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < this.transform.childCount; i++)
        {   
            if(GameManager.clueNum.Contains(i))
            {
                GameObject child2 = this.transform.GetChild(i - 1).gameObject;
                if(child2.transform.childCount != 0)
                    child2.transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color(1f,1f,1f,1f);
            }
        }
    }
}
