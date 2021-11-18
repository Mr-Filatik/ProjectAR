using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VostokController : MonoBehaviour
{
    #region Private Variables

    private bool isWork = false;
    private float timeWork = 0f;
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
        timeWork = 0f;
    }

    public void Active(bool input)
    {
        if (input)
        {
            timeWork = 0f;
        }
        else
        {
            if (activeElenent != null)
            {
                activeElenent.Active(false);
                activeElenent = null;
            }
        }
    }

    public void Rotate()
    {
        if (!isWork)
        {
            isWork = true;
        }
    }

    #endregion

    #region Private Methods

    private void Update()
    {
        if (timeWork > 10f)
        {
            Debug.Log("Метод вызова тача");
            timeWork = 0f;
        }
        timeWork += Time.deltaTime;

        if (isWork)
        {
            
        }
    }

    #endregion
}
