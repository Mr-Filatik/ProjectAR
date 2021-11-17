using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SputnikController : MonoBehaviour
{
    #region Private Variables

    private bool isWork = false;
    private float currentTime = 0f; //change
    private bool vector = true; //change
    private float cooldownTime = 1f; //change
    private Vector3 startPosition = Vector3.zero;
    private float speed = 0.5f;
    private float angle = 3.3f;
    private float radius = 1f;

    #endregion

    #region Private Methods

    private void Update()
    {
        if (isWork)
        {
            if (angle > 10f) //change
            {
                angle = 3.3f;
                isWork = false;
                transform.localPosition = startPosition;
                transform.localEulerAngles = new Vector3(-90, 0, 0);
                transform.localScale = new Vector3(0.33333f, 0.33333f, 0.33333f); //mb change
            }
            else
            {
                Debug.Log(angle);
                angle += Time.deltaTime;
                transform.localPosition = new Vector3(Mathf.Cos(angle * speed) * radius + startPosition.x, startPosition.y, -Mathf.Sin(angle * speed) * radius + startPosition.z + radius);
                transform.localScale = new Vector3((Mathf.Sin(angle * speed) + 1) / 6, (Mathf.Sin(angle * speed) + 1) / 6, (Mathf.Sin(angle * speed) + 1) / 6);        
                //transform.localEulerAngles = //change
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
