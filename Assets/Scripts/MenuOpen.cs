using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    //Animator animator = Container.GetComponent<Animator>();
    //bool isActive = Container.activeSelf;
    //Container.SetActive(!isActive);

    //if (!isActive == true)
    //{
    // bool isOpen = animator.GetBool("open");
    //animator.SetBool("open", !isOpen);
    //}
    //bool isActive = Container.activeSelf;
    //Container.SetActive(!isActive);
    //Animator animator = Container.GetComponent<Animator>();
    //if (animator != null)
    //{

    //bool isOpen = animator.GetBool("open");
    //animator.SetBool("open", !isOpen);
    //}

    public class MenuOpen : MonoBehaviour
    {
        public GameObject Container;

        public void OpenContainer()
        {
            if (Container != null)
            {
                Animator animator = Container.GetComponent<Animator>();
                if (animator != null)
                {
                    bool isActive = Container.activeSelf;
                    Container.SetActive(!isActive);
                    bool isOpen = animator.GetBool("open");
                   
                    animator.SetBool("open", !isOpen);
                    

                }






            }
        }
    }


