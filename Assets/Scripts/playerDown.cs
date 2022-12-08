using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using Vuforia;

public class playerDown : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{

    public gameHandler gameHandler;
    
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        gameHandler.InputZ = -1;
    }
    
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        gameHandler.InputZ = 0;
    }

}
