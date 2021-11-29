using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableController : MonoBehaviour
{
    #region Serialize Variables

    [SerializeField] private VostokController vostok = null;
    [SerializeField] private SputnikController sputnik = null;
    [SerializeField] private LetterController letter = null;
    [SerializeField] private CanvasController canvasForRotate = null;
    [SerializeField] private CanvasController canvasForRestart = null;

    #endregion

    #region Private Methods

    private void Awake()
    {
        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        if (vostok != null)
        {
            vostok.Active(true);
        }
        if (sputnik != null)
        {
            sputnik.Active(true);
        }
        if (letter != null)
        {
            letter.Active(true);
        }
        if (canvasForRotate != null)
        {
            canvasForRotate.ActiveRotate(true);
        }
        if (canvasForRestart != null)
        {
            canvasForRestart.ActiveRestart(true);
        }
    }

    private void OnDisable()
    {
        if (vostok != null)
        {
            vostok.Active(false);
        }
        if (sputnik != null)
        {
            sputnik.Active(false);
        }
        if (letter != null)
        {
            letter.Active(false);
        }
        if (canvasForRotate != null)
        {
            canvasForRotate.ActiveRotate(false);
        }
        if (canvasForRestart != null)
        {
            canvasForRestart.ActiveRestart(false);
        }
    }

    #endregion
}
