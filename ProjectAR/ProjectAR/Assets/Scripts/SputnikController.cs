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
        }
        else
        {
            angle = 3.145f;
            isWork = false;
            transform.localPosition = startPosition;
            transform.localEulerAngles = new Vector3(0, 0, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            sputnik.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
        }
    }

    #endregion

    #region Private Methods

    private void Update()
    {
        if (isWork)
        {
            if (angle > 15.725f) //change
            {
                angle = 3.145f;
                isWork = false;
                transform.localPosition = startPosition;
                transform.localEulerAngles = new Vector3(0, 0, 0);
                transform.localScale = new Vector3(1f, 1f, 1f); //mb change
                sputnik.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
            }
            else
            {
                angle += Time.deltaTime;
                transform.localPosition = new Vector3(Mathf.Cos(angle * speed) * radius + startPosition.x, startPosition.y, -Mathf.Sin(angle * speed) * radius + startPosition.z + radius);
                transform.localScale = new Vector3((0.5f + (Mathf.Sin(angle * speed) + 1) / 4 ), (0.5f + (Mathf.Sin(angle * speed) + 1) / 4), (0.5f + (Mathf.Sin(angle * speed) + 1) / 4));
                if (angle > 9.435f)
                {
                    sputnik.transform.localEulerAngles = new Vector3(0, ((angle - 15.725f) / 3.145f) * 90, 0);
                }
                else
                {
                    sputnik.transform.localEulerAngles = new Vector3(0, ((angle - 15.725f) / 3.145f) * 90, 0);
                }
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
                    canvas.TapWorkStart();
                    //canvas.TapWork(camera.WorldToScreenPoint(new Vector3(gameObject.transform.position.x - 0.07f, gameObject.transform.position.y - 0.04f, gameObject.transform.position.z - 0.1f))); //hz
                }
                else
                {
                    canvas.TapWorkEnd();
                    timeWork = 0f;
                }
            }
            timeWork += Time.deltaTime;
        }
    }

    private void OnMouseDown()
    {
        if (!isWork)
        {
            isWork = true;
            startPosition = gameObject.transform.localPosition;
        }
    }

    #endregion
}
