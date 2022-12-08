using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using Vuforia;

public class playerRight : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    public gameHandler gameHandler;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        gameHandler.InputX = 1;
    }
    
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        gameHandler.InputX = 0;
    }
    
}
