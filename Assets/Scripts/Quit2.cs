using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
}
