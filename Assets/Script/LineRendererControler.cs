using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererControler : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lineRenderer.SetPosition(lineRenderer.positionCount-1, mousePos) ;
    }
}
