using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapCanvasController : MonoBehaviour
{
    [SerializeField] private Camera camera = null;
    [SerializeField] private GameObject tap = null;

    private bool isWork = false;

    private void Awake()
    {
        tap.SetActive(false);
    }

    private void Update()
    {
        transform.localEulerAngles = camera.transform.localEulerAngles;
    }

    public void TapWorkStart()
    {
        tap.SetActive(true);
        isWork = true;
        /*if (!isWork)
        {
            isWork = true;
            tap.transform.localPosition = new Vector3(coordinates.x - gameObject.GetComponent<Canvas>().pixelRect.width / 2, coordinates.y - gameObject.GetComponent<Canvas>().pixelRect.height / 2, coordinates.z);
            tap.SetActive(true);
        }
        else
        {
            tap.transform.localPosition = coordinates;
        }*/
    }

    public void TapWorkEnd()
    {
        tap.SetActive(false);
        isWork = false;
    }

    private void OnEnable()
    {
        
    }
}
