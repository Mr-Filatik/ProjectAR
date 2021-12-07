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

    public void SetSpriteOn()
    {
        btnRestart.image.sprite = imageWork;
        (btnRestart.transform as RectTransform).sizeDelta = new Vector2(256f * 0.7f, 200f * 0.7f);
    }

    public void SetSpriteOff()
    {
        btnRestart.image.sprite = imageNoWork;
        (btnRestart.transform as RectTransform).sizeDelta = new Vector2(256f * 0.7f, 200f * 0.7f);
    }

    public void SetSpriteRestart()
    {
        btnRestart.image.sprite = imageRestart;
        (btnRestart.transform as RectTransform).sizeDelta = new Vector2(256f * 0.7f, 256f * 0.7f);
    }

    #endregion

    #region Private Methods

    private void Awake()
    {
        btnRotate.gameObject.SetActive(false);
        btnRestart.gameObject.SetActive(false);
        imageLogoInpit.rectTransform.position = new Vector3(3f * Screen.width / 4f, Screen.height - 110f, 0f);
        imageLogoSGET.rectTransform.position = new Vector3(1f * Screen.width / 4f, Screen.height - 110f, 0f);
        (btnRotate.transform as RectTransform).position = new Vector3(Screen.width / 4f, 110f, 0f);
        (btnRestart.transform as RectTransform).position = new Vector3(Screen.width / 4f, 110f, 0f);
    }

    #endregion
}
