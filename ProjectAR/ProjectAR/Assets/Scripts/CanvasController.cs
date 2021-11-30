using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    #region Serialize Variables

    [SerializeField] private GameObject buttonRotate = null;
    [SerializeField] private GameObject buttonRestart = null;
    [SerializeField] private Sprite imageRestart = null;
    [SerializeField] private Sprite imageWork = null;

    #endregion

    #region Public Methods

    public void ActiveRotate(bool input)
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

    public void ActiveRestart(bool input)
    {
        if (input)
        {
            buttonRestart.SetActive(true);
        }
        else
        {
            buttonRestart.SetActive(false);
        }
    }

    #endregion

    #region Private Methods

    private void Awake()
    {
        buttonRotate.SetActive(false);
        buttonRestart.SetActive(false);
    }

    #endregion
}
