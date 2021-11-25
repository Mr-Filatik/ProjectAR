using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SputnikController : MonoBehaviour
{
    #region Serialize Variables

    [SerializeField] private Camera camera = null;
    [SerializeField] private TapCanvasController canvas = null;
    [SerializeField] private GameObject sputnik = null;
    [SerializeField] private GameObject tap = null;

    #endregion

    #region Private Variables

    private float timeWork = 0f;
    private bool isWork = false;
    private Vector3 startPosition = Vector3.zero;
    private float speed = 0.5f;
    private float angle = 3.145f;
    private float radius = 1f;

    #endregion

    #region Public Methods

    public void Active(bool input)
    {
        if (input)
        {
            timeWork = 0f;
            startPosition = transform.localPosition;
        }
        else
        {
            angle = Mathf.PI;
            isWork = false;
            transform.localPosition = startPosition;
            transform.localEulerAngles = new Vector3(0, 0, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            sputnik.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            canvas.TapWorkEnd();
        }
    }

    #endregion

    #region Private Methods

    private void Update()
    {
        if (isWork)
        {
            if (angle > Mathf.PI * 5f)
            {
                //angle = 3.145f;
                angle = Mathf.PI;
                isWork = false;
                transform.localPosition = startPosition;
                transform.localEulerAngles = new Vector3(0, 0, 0);
                transform.localScale = new Vector3(1f, 1f, 1f);
                sputnik.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            }
            else
            {
                angle += Time.deltaTime * (1f + (1f - Mathf.Abs(Mathf.PI * 3f - angle) / (Mathf.PI * 2f)) * 1.5f);
                transform.localPosition = new Vector3(Mathf.Cos(angle * speed) * radius + startPosition.x, startPosition.y, -Mathf.Sin(angle * speed) * radius + startPosition.z + radius);
                transform.localScale = new Vector3((0.5f + (Mathf.Sin(angle * speed) + 1) / 4 ), (0.5f + (Mathf.Sin(angle * speed) + 1) / 4), (0.5f + (Mathf.Sin(angle * speed) + 1) / 4));
                if (angle > Mathf.PI * 3f)
                {
                    sputnik.transform.localEulerAngles = new Vector3(0, ((angle - Mathf.PI * 5f) / Mathf.PI) * 90, 0);
                }
                else
                {
                    sputnik.transform.localEulerAngles = new Vector3(0, ((angle - Mathf.PI * 5f) / Mathf.PI) * 90, 0);
                }
            }
            timeWork = 0f;
        }
        else
        {
            if (timeWork > 7f)
            {
                canvas.TapWorkStart();
                timeWork = 0f;
<<<<<<< HEAD
=======
                /*if (timeWork < 12f)
                {
                    canvas.TapWorkStart();
                }
                else
                {
                    canvas.TapWorkEnd();
                    timeWork = 0f;
                }*/
>>>>>>> 26f604595711211679dfb4bed820efea26804e0f
            }
            timeWork += Time.deltaTime;
        }
    }

    private void OnMouseDown()
    {
        if (!isWork)
        {
            canvas.TapWorkEnd();
            isWork = true;
            startPosition = gameObject.transform.localPosition;
        }
    }

    #endregion
}
