using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTarget : MonoBehaviour
{
    private Vector3 offset;
    private float zCoordinate;
    public bool objectDrag;
    //Convert world mouse position to mouse position on screen view
    private void OnMouseDown()
    {
        zCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldsPos();
    }
    //Get mouse position in game world
    private Vector3 GetMouseWorldsPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoordinate;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    //Set position to object from mouse position
    private void OnMouseDrag() => transform.position = GetMouseWorldsPos() + offset;
    private void OnMouseEnter() => objectDrag = true;
    private void OnMouseExit() => objectDrag = false;
}
