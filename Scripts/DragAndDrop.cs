using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    Vector3 currentMousePosition;

    private Vector3 UpdateCurrentMouse() {
    
        return Camera.main.WorldToScreenPoint(transform.position);

    }

    // When the mouse is clicked we want to record our current mouse position in our
    // Vector 3 variable.
    private void OnMouseDown()
    {
        currentMousePosition = Input.mousePosition - UpdateCurrentMouse();
    }

    // Transform the position of whatever object we've selected.
    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - currentMousePosition);
    }
}
