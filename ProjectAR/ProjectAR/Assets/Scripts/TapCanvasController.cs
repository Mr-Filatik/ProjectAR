using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TapCanvasController : MonoBehaviour
{
    #region Serialize Variables

    [SerializeField] private Camera camera = null;
    [SerializeField] private GameObject tap = null;
    [SerializeField] private Image finger = null;
    [SerializeField] private Image circleMin = null;
    [SerializeField] private Image circleMax = null;
    [SerializeField] private GameObject info = null;
    [SerializeField] private Text[] infoText = null;
    [SerializeField] private Image[] infoImage = null;
    [SerializeField] private GameObject vostok = null;

    #endregion

    #region Private Variables

    private bool isWork = false;

    #endregion

    #region Public Methods

    public void TapWorkStart()
    {
        finger.color = new Color(1, 1, 1, 0);
        circleMin.color = new Color(1, 1, 1, 0);
        circleMax.color = new Color(1, 1, 1, 0);
        StartCoroutine(PlayAnimScaleFinger(finger, true));
        StartCoroutine(PlayAnimScaleCircleMin(circleMin, true));
        StartCoroutine(PlayAnimScaleCircleMax(circleMax, true));
        //finger.DOColor(new Color(1, 1, 1, 1), 1f).OnComplete(() => finger.DOColor(new Color(1, 1, 1, 0), 1f));
        //circleMin.DOColor(new Color(1, 1, 1, 1), 1f).OnComplete(()=> circleMin.DOColor(new Color(1, 1, 1, 0), 1f));
        //circleMax.DOColor(new Color(1, 1, 1, 1), 1f).OnComplete(() => circleMax.DOColor(new Color(1, 1, 1, 0), 1f));
        tap.SetActive(true);
        isWork = true;
    }

    public void TapWorkEnd()
    {
        tap.SetActive(false);
        isWork = false;
    }

    public void InfoWorkStart()
    {
        foreach (Text item in infoText)
        {
            item.color = new Color(1, 1, 1, 0);
        }
        //infoText.color = new Color(1, 1, 1, 0);
        foreach (Image item in infoImage)
        {
            item.color = new Color(1, 1, 1, 0);
        }
        foreach (Text item in infoText)
        {
            item.DOColor(new Color(1, 1, 1, 1), 1f);
        }
        //infoText.DOColor(new Color(1, 1, 1, 1), 1f);
        foreach (Image item in infoImage)
        {
            item.DOColor(new Color(1, 1, 1, 1), 1f);
        }
        info.SetActive(true);
    }

    public void InfoWorkEnd()
    {
        foreach (Text item in infoText)
        {
            item.DOColor(new Color(1, 1, 1, 0), 1f);
        }
        //infoText.DOColor(new Color(1, 1, 1, 0), 1f);
        foreach (Image item in infoImage)
        {
            item.DOColor(new Color(1, 1, 1, 0), 1f);
        }
        //infoText.color = new Color(1, 1, 1, 0);
        //info.SetActive(false);
    }

    #endregion

    #region Private Methods

    private void Awake()
    {
        tap.SetActive(false);
        if (info != null) info.SetActive(false);
    }

    private void Update()
    {
        if (infoText != null)
        {
            if (vostok != null)
            {
                if (infoText[0].color.a == 0)
                {
                    transform.localEulerAngles = camera.transform.localEulerAngles;
                }
            }
            else
            {
                transform.localEulerAngles = camera.transform.localEulerAngles;
            }
        }
        else
        {
            if (vostok != null)
            {
                transform.localEulerAngles = new Vector3(camera.transform.localEulerAngles.x, -vostok.transform.localEulerAngles.y + camera.transform.localEulerAngles.y, camera.transform.localEulerAngles.z);
            }
            else
            {
                transform.localEulerAngles = camera.transform.localEulerAngles;
            }
        }
    }

    private IEnumerator PlayAnimScaleFinger(Image item, bool repeat)
    {
        item.DOColor(new Color(1, 1, 1, 1), 1f);
        yield return new WaitForSeconds(1.2f);
        item.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        item.transform.DOScale(new Vector3(1f, 1f, 1f), 0.4f);
        yield return new WaitForSeconds(0.6f);
        item.DOColor(new Color(1, 1, 1, 0), 1f);
        if (repeat)
        {
            yield return new WaitForSeconds(1.2f);
            StartCoroutine(PlayAnimScaleFinger(item, false));
        }
    }

    private IEnumerator PlayAnimScaleCircleMin(Image item, bool repeat)
    {
        item.transform.localScale = new Vector3(1f, 1f, 1f);
        //item.DOColor(new Color(1, 1, 1, 1), 1f);
        //yield return new WaitForSeconds(1.4f);
        yield return new WaitForSeconds(1.2f);
        item.DOColor(new Color(1, 1, 1, 1), 0.2f);
        yield return new WaitForSeconds(0.2f);
        item.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.6f);
        item.DOColor(new Color(1, 1, 1, 0), 0.6f);
        yield return new WaitForSeconds(0.6f);
        if (repeat)
        {
            yield return new WaitForSeconds(1.2f);
            StartCoroutine(PlayAnimScaleCircleMin(item, false));
        }
    }

    private IEnumerator PlayAnimScaleCircleMax(Image item, bool repeat)
    {
        item.transform.localScale = new Vector3(1f, 1f, 1f);
        //item.DOColor(new Color(1, 1, 1, 1), 1f);
        //yield return new WaitForSeconds(1.4f);
        yield return new WaitForSeconds(1.2f);
        item.DOColor(new Color(1, 1, 1, 1), 0.2f);
        yield return new WaitForSeconds(0.2f);
        item.transform.DOScale(new Vector3(1.6f, 1.6f, 1.6f), 0.6f);
        item.DOColor(new Color(1, 1, 1, 0), 0.6f);
        yield return new WaitForSeconds(0.6f);
        if (repeat)
        {
            yield return new WaitForSeconds(1.2f);
            StartCoroutine(PlayAnimScaleCircleMax(item, false));
        }
    }

    #endregion
}
