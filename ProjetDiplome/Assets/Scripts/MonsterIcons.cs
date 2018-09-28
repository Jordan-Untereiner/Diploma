using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MonsterIcons : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler {

    private Vector3 startPosition;
    private Monster monster;
    private Image icon;

    private void Start()
    {
        icon = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = true;
        transform.position = startPosition;
    }


    public void OnDrop(PointerEventData eventData)
    {
        
    }

    public void GetNewMonster(Monster m)
    {
        monster = m;
        icon.sprite = m.icon;
    }

    public Monster GetCurrentMonster()
    {
        return monster;
    }



}
