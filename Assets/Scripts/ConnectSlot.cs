using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

public class ConnectSlot : MonoBehaviour, IDropHandler
{

    public virtual void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Good Spot");
        if (eventData.pointerDrag != null)
        {
            //eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            eventData.pointerDrag.transform.parent = this.transform;
        }
    }

    private void Update()
    {

    }
}
