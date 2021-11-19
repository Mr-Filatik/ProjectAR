using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VostokController : MonoBehaviour
{
    [SerializeField] private CanvasController canvas = null;
    [SerializeField] private Camera camera = null;
    [SerializeField] private GameObject step1 = null;
    [SerializeField] private GameObject step2 = null;
    [SerializeField] private GameObject step3 = null; 

    #region Private Variables

    private bool isWork = false;
    private float timeWork = 0f;
    private float angle = 0f;
    private float speed = 50f;
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
        if (isWork)
        {
            if (angle >= 360) //change
            {
                angle = 0f;
                isWork = false;
                transform.localEulerAngles = new Vector3(-90, 0, 0);
            }
            else
            {
                angle += Time.deltaTime * speed;
                transform.localEulerAngles = new Vector3(-90, angle, 0);
            }
            timeWork = 0f;
        }
        else
        {
            if (timeWork > 10f)
            {
                if (timeWork < 12f)
                {
                    //camera.WorldToViewportPoint(gameObject.transform.position);
                    //canvas.TapWork(camera.WorldToScreenPoint(new Vector3(step1.transform.position.x - 0.07f, step1.transform.position.y - 0.04f, step1.transform.position.z - 0.1f))); //hz
                }
                else if (timeWork < 14f)
                {
                    //canvas.TapWork(camera.WorldToScreenPoint(new Vector3(step2.transform.position.x - 0.07f, step2.transform.position.y - 0.04f, step2.transform.position.z - 0.1f))); //hz
                }
                else if (timeWork < 16f)
                {
                    //canvas.TapWork(camera.WorldToScreenPoint(new Vector3(step3.transform.position.x - 0.07f, step3.transform.position.y - 0.04f, step3.transform.position.z - 0.1f))); //hz
                }
                else
                {
                    //canvas.TapWorkEnd();
                    timeWork = 0f;
                }
            }
            timeWork += Time.deltaTime;
        }
    }

    #endregion
}
