using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject buttonRotate = null;
    [SerializeField] private GameObject tap = null;

    private bool isWork = false;

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

    public void TapWork(Vector3 coordinates)
    {
        if (!isWork)
        {
            isWork = true;
            tap.transform.localPosition = new Vector3(coordinates.x - gameObject.GetComponent<Canvas>().pixelRect.width / 2, coordinates.y - gameObject.GetComponent<Canvas>().pixelRect.height / 2, coordinates.z);
            tap.SetActive(true);
        }
        else
        {
            tap.transform.localPosition = coordinates;
        }
        Debug.Log(coordinates.x + " " + coordinates.y);
    }

    private void Awake()
    {
        buttonRotate.SetActive(false);
        tap.SetActive(false);
    }
}
