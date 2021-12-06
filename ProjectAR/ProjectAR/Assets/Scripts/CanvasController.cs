using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    #region Serialize Variables

    [SerializeField] private Button btnRotate = null;
    [SerializeField] private Button btnRestart = null;
    [SerializeField] private Sprite imageRestart = null;
    [SerializeField] private Sprite imageWork = null;
    [SerializeField] private Sprite imageNoWork = null;
    [SerializeField] private Image imageLogoInpit = null;
    [SerializeField] private Image imageLogoSGET = null;

    #endregion

    #region Public Methods

    public void ActiveRotate(bool input)
    {
        if (input)
        {
            btnRotate.gameObject.SetActive(true);
        }
        else
        {
            btnRotate.gameObject.SetActive(false);
        }
    }

    public void ActiveRestart(bool input)
    {
        if (input)
        {
            btnRestart.gameObject.SetActive(true);
        }
        else
        {
            btnRestart.gameObject.SetActive(false);
        }
    }

    #endregion

    #region Private Methods

    private void Awake()
    {
        btnRotate.gameObject.SetActive(false);
        btnRestart.gameObject.SetActive(false);
        imageLogoInpit.rectTransform.position = new Vector3(3f * Screen.width / 4f, Screen.height - 110f, 0f);
        imageLogoSGET.rectTransform.position = new Vector3(1f * Screen.width / 4f, Screen.height - 110f, 0f);
        (btnRotate.transform as RectTransform).position = new Vector3(250f, 150f, 0f);
        (btnRestart.transform as RectTransform).position = new Vector3(250f, 150f, 0f);
    }

    #endregion
}
