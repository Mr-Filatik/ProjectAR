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
    [SerializeField] private Text infoText = null;
    [SerializeField] private Text infoImage = null;
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
        infoText.color = new Color(1, 1, 1, 0);
        infoText.DOColor(new Color(1, 1, 1, 1), 1f);
        info.SetActive(true);
    }

    public void InfoWorkEnd()
    {
<<<<<<< HEAD
        infoText.DOColor(new Color(1, 1, 1, 0), 1f);
        //infoText.color = new Color(1, 1, 1, 0);
        //info.SetActive(false);
    }

    #endregion
=======
        finger.color = new Color(1, 1, 1, 0);
        circleMin.color = new Color(1, 1, 1, 0);
        circleMax.color = new Color(1, 1, 1, 0);
        StartCoroutine(PlayAnim(finger));
        StartCoroutine(PlayAnim(circleMin));
        StartCoroutine(PlayAnim(circleMax));
        //finger.DOColor(new Color(1, 1, 1, 1), 1f).OnComplete(() => finger.DOColor(new Color(1, 1, 1, 0), 1f));
        //circleMin.DOColor(new Color(1, 1, 1, 1), 1f).OnComplete(()=> circleMin.DOColor(new Color(1, 1, 1, 0), 1f));
        //circleMax.DOColor(new Color(1, 1, 1, 1), 1f).OnComplete(() => circleMax.DOColor(new Color(1, 1, 1, 0), 1f));
>>>>>>> 26f604595711211679dfb4bed820efea26804e0f

    #region Private Methods

    private void Awake()
    {
        tap.SetActive(false);
        info.SetActive(false);
    }

    private void Update()
    {
        if (infoText.color.a == 0)
        {
            transform.localEulerAngles = camera.transform.localEulerAngles;
        }
        else
        {
            transform.localEulerAngles = new Vector3(camera.transform.localEulerAngles.x, -vostok.transform.localEulerAngles.y + camera.transform.localEulerAngles.y, camera.transform.localEulerAngles.z);
        }
    }

<<<<<<< HEAD
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
=======
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
>>>>>>> 26f604595711211679dfb4bed820efea26804e0f
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
