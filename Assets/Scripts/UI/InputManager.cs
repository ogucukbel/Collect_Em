using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IDragHandler, IBeginDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public enum Direction 
    { 
        Left,
        Right,
        None 
    }
    public bool onPointerDown = false;
    public Direction direction;
    private Vector3 startPosition, endPosition;
    public float swipeThreshold;
    private bool draggingStarted;
    public bool touched;

    private void Awake()
    {
        draggingStarted = false;
        direction = Direction.None;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        draggingStarted = true;
        startPosition = eventData.pressPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggingStarted)
        {
            endPosition = eventData.position;
            Vector2 difference = endPosition - startPosition;
            if (difference.magnitude > swipeThreshold)
            {
                direction = difference.x > 0 ? Direction.Right : Direction.Left; 
            }
            else
            {
                direction = Direction.None;
            }
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        direction = Direction.None;
        startPosition = Vector3.zero;
        endPosition = Vector3.zero;
        draggingStarted = false;
        onPointerDown = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        onPointerDown = true;
        touched = true;
    }
}
