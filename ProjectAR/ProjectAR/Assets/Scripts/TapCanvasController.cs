using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TapCanvasController : MonoBehaviour
{
    [SerializeField] private Camera camera = null;
    [SerializeField] private GameObject tap = null;
    [SerializeField] private Image finger = null;
    [SerializeField] private Image circleMin = null;
    [SerializeField] private Image circleMax = null;

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
        finger.color = new Color(1, 1, 1, 0);
        circleMin.color = new Color(1, 1, 1, 0);
        circleMax.color = new Color(1, 1, 1, 0);

        finger.DOColor(new Color(1, 1, 1, 1), 1f);
        circleMin.DOColor(new Color(1, 1, 1, 1), 1f);
        circleMax.DOColor(new Color(1, 1, 1, 1), 1f);

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
        finger.color = new Color(1, 1, 1, 0);
        circleMin.color = new Color(1, 1, 1, 0);
        circleMax.color = new Color(1, 1, 1, 0);
        tap.SetActive(false);
        isWork = false;
    }

    private void OnEnable()
    {
        
    }
}
