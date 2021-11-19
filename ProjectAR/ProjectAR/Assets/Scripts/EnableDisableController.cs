using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableController : MonoBehaviour
{
    #region Serialize Variables

    [SerializeField] private VostokController vostok = null;
    [SerializeField] private SputnikController sputnik = null;
    [SerializeField] private LetterController letter = null;
    [SerializeField] private CanvasController canvas = null;

    #endregion

    #region Private Methods

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
        if (canvas != null)
        {
            canvas.Active(true);
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
        if (canvas != null)
        {
            canvas.Active(false);
        }
    }

    #endregion
}
