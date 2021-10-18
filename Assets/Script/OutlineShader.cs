using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OutlineShader : MonoBehaviour
{
    [SerializeField] Material outLineMaterial;
    [SerializeField] Material standardMaterial;
    [SerializeField] Image cardImage;
    [SerializeField] bool isMouseOver;
    public Color shaderColor;

    private void OnMouseOver()
    {
        isMouseOver = true;
        if (isMouseOver)
        {
            cardImage.material = outLineMaterial;
        }
    }
    private void OnMouseExit()
    {
        isMouseOver = false;
        cardImage.material = standardMaterial;
    }
}
