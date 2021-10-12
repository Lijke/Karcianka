using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionHandler : MonoBehaviour
{
    private SelectionManager selectionManager;
    private void Start()
    {
        selectionManager = GameObject.FindGameObjectWithTag("SelectionManager").GetComponent<SelectionManager>();
    }
    private void OnMouseEnter()
    {
        selectionManager.CurrentCardSelected = null;
    }
}
