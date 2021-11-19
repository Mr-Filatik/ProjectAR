using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject buttonRotate = null;
    //[SerializeField] private GameObject tap = null;

    //private bool isWork = false;

    public void Active(bool input)
    {
        if (input)
        {
            buttonRotate.SetActive(true);
        }
        else
        {
            buttonRotate.SetActive(false);
        }
    }

    private void Awake()
    {
        buttonRotate.SetActive(false);
        //tap.SetActive(false);
    }
}
