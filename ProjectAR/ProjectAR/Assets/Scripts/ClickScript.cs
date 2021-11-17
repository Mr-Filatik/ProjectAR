using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    [SerializeField] private VostokController vostokController = null;

    private void OnMouseDown()
    {
        vostokController.ClickElement(this); //!!! передача скрипта
    }

    public void Active(bool state)
    {
        if (state)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
}
