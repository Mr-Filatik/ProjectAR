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
        StartCoroutine(PlayAnim(finger));
        StartCoroutine(PlayAnim(circleMin));
        StartCoroutine(PlayAnim(circleMax));
        //finger.DOColor(new Color(1, 1, 1, 1), 1f).OnComplete(() => finger.DOColor(new Color(1, 1, 1, 0), 1f));
        //circleMin.DOColor(new Color(1, 1, 1, 1), 1f).OnComplete(()=> circleMin.DOColor(new Color(1, 1, 1, 0), 1f));
        //circleMax.DOColor(new Color(1, 1, 1, 1), 1f).OnComplete(() => circleMax.DOColor(new Color(1, 1, 1, 0), 1f));

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

    IEnumerator PlayAnim(Image item)
    {
        //item.DOColor(new Color(1, 1, 1, 1), 1f).OnComplete(() => item.DOColor(new Color(1, 1, 1, 0), 1f));
        item.DOColor(new Color(1, 1, 1, 1), 1f);
        yield return new WaitForSeconds(2);
        item.DOColor(new Color(1, 1, 1, 0), 1f);

        yield return new WaitForSeconds(1.2f);

        item.DOColor(new Color(1, 1, 1, 1), 1f);
        yield return new WaitForSeconds(2);
        item.DOColor(new Color(1, 1, 1, 0), 1f);
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
