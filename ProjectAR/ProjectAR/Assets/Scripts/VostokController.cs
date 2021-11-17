using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VostokController : MonoBehaviour
{
    #region Private Variables

    private ClickScript activeElenent = null;

    #endregion

    #region Public Methods

    public void ClickElement(ClickScript clickScript)
    {
        if (activeElenent == clickScript)
        {
            clickScript.Active(false);
            activeElenent = null;
        }
        else
        {
            if (activeElenent != null)
            {
                activeElenent.Active(false);
            }
            clickScript.Active(true);
            activeElenent = clickScript;
        }
    }

    #endregion
}
