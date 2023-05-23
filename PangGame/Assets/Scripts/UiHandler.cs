using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public enum ButtonsType
{
    Right,
    Left,
    Fire
};

public class UiHandler :  MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{

    [SerializeField] private ButtonsType _buttonsType;
    [SerializeField] private GameObject Player;
    private bool _right,_left,_fire;

    private void Start()
    {
        
    }

  
    public void OnPointerClick(PointerEventData eventData)
    {
         if (_buttonsType == ButtonsType.Fire)
            Player.GetComponent<PlayerAction>().Shoot();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_buttonsType == ButtonsType.Right)
            Player.GetComponent<PlayerAction>().setDirection(Vector3.right);
        
        else if (_buttonsType == ButtonsType.Left)
            Player.GetComponent<PlayerAction>().setDirection(Vector3.left);
        
        else if (_buttonsType == ButtonsType.Fire)
            Player.GetComponent<PlayerAction>().Shoot();
        
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_buttonsType == ButtonsType.Right)
            Player.GetComponent<PlayerAction>().setDirection();
        
        else if (_buttonsType == ButtonsType.Left)
            Player.GetComponent<PlayerAction>().setDirection();
        
      
    }


   
}
