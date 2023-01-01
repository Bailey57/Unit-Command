using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDrag : MonoBehaviour
{
    Camera cam;

    [SerializeField] RectTransform boxVisual;

    Rect selectionBox;
    Vector2 startPosition;
    Vector2 endPosition;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;
        DrawVisual();
        
    }

    // Update is called once per frame
    void Update()
    {

        //when clicked
        if (Input.GetMouseButtonDown(0)) 
        {
            startPosition = Input.mousePosition;
        }

        //when dragging
        if (Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;
            DrawVisual();
        }

        //when release click
        if (Input.GetMouseButtonUp(0))
        {
            startPosition = Vector2.zero;
            endPosition = Vector2.zero;
            DrawVisual();
        }
    }

    void DrawVisual() 
    {
        Vector2 boxStart = startPosition;
        Vector2 boxEnd = endPosition;

        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        boxVisual.position = boxCenter;

        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));
    
    }
}
