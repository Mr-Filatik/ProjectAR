using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SputnikController : MonoBehaviour
{
    #region Serialize Variables

    [SerializeField] private GameObject sputnik = null;

    #endregion

    #region Private Variables

    private bool isWork = false;
    private float currentTime = 0f; //change
    private bool vector = true; //change
    private float cooldownTime = 1f; //change
    private Vector3 startPosition = Vector3.zero;
    private float speed = 0.5f;
    private float angle = 3.145f;
    private float radius = 1f;

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
