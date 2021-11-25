using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VostokController : MonoBehaviour
{
    #region Serialize Variables

    [SerializeField] private CanvasController canvas = null;
    [SerializeField] private Camera camera = null;
    [SerializeField] private TapCanvasController canvas1 = null;
    [SerializeField] private TapCanvasController canvas2 = null;
    [SerializeField] private TapCanvasController canvas3 = null;

    #endregion

    #region Private Variables

    private bool isWork = false;
    private float timeWork = 0f;
    private float angle = 0f;
    private float speed = 100f;
    private ClickScript activeElenent = null;
    private int state = 0;

    #endregion

    #region Public Methods

    public void ClickElement(ClickScript clickScript)
    {
        if (activeElenent == clickScript)
        {
            clickScript.Active(false);
            clickScript.ActiveInfo(false);
            activeElenent = null;
        }
        else
        {
            if (activeElenent != null)
            {
                activeElenent.Active(false);
                activeElenent.ActiveInfo(false);
            }
            clickScript.Active(true);
            clickScript.ActiveInfo(true);
            activeElenent = clickScript;
        }
        timeWork = 0f;
        canvas1.TapWorkEnd();
        canvas2.TapWorkEnd();
        canvas3.TapWorkEnd();
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
                activeElenent.ActiveInfo(false);
                activeElenent = null;
            }
            canvas1.TapWorkEnd();
            canvas2.TapWorkEnd();
            canvas3.TapWorkEnd();
        }
    }

    public void Rotate()
    {
        if (!isWork)
        {
            isWork = true;
            canvas1.TapWorkEnd();
            canvas2.TapWorkEnd();
            canvas3.TapWorkEnd();
            //canvas1.InfoWorkEnd();
            //canvas2.InfoWorkEnd();
            //canvas3.InfoWorkEnd();
            /*if (activeElenent != null)
            {
                activeElenent.ActiveInfo(false);
            }*/
        }
    }

    #endregion

    #region Private Methods

    private void Update()
    {
        if (isWork)
        {
            if (angle >= 360)
            {
                angle = 0f;
                isWork = false;
                transform.localEulerAngles = new Vector3(-90, 0, 0);
                if (activeElenent != null)
                {
                    if (activeElenent.IsWork)
                    {
                        activeElenent.ActiveInfo(true);
                    }
                }
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
            if (timeWork > 7f)
            {
                switch (state)
                {
                    case 0: canvas1.TapWorkStart(); break;
                    case 1: canvas2.TapWorkStart(); break;
                    case 2: canvas3.TapWorkStart(); break;
                }
                state++;
                if (state == 3) state = 0;
                timeWork = 0f;
                //if (timeWork < 12f)
                //{
                //    canvas1.TapWorkStart();
                //    //camera.WorldToViewportPoint(gameObject.transform.position);
                //    //canvas.TapWork(camera.WorldToScreenPoint(new Vector3(step1.transform.position.x - 0.07f, step1.transform.position.y - 0.04f, step1.transform.position.z - 0.1f))); //hz
                //}
                //else if (timeWork < 14f)
                //{
                //    canvas2.TapWorkStart();
                //    //canvas.TapWork(camera.WorldToScreenPoint(new Vector3(step2.transform.position.x - 0.07f, step2.transform.position.y - 0.04f, step2.transform.position.z - 0.1f))); //hz
                //}
                //else if (timeWork < 16f)
                //{
                //    canvas3.TapWorkStart();
                //    //canvas.TapWork(camera.WorldToScreenPoint(new Vector3(step3.transform.position.x - 0.07f, step3.transform.position.y - 0.04f, step3.transform.position.z - 0.1f))); //hz
                //}
                //else
                //{
                //    canvas3.TapWorkEnd();
                //    //canvas.TapWorkEnd();

                //}
            }
            timeWork += Time.deltaTime;
        }
    }

    #endregion
}
