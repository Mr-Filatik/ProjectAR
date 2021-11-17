using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    [SerializeField] private VostokController vostokController = null;

    private bool isWork = false;
    private float currentTime = 0f;
    private bool vector = true;
    private float cooldownTime = 1f;
    private Color color = new Color(135 / 256, 126 / 256, 68 / 256, 1);

    private void Update()
    {
        if (isWork)
        {
            if (currentTime >= cooldownTime)
            {
                currentTime = 0f;
                if (vector)
                {
                    vector = false;
                }
                else
                {
                    vector = true;
                }
            }
            else
            {
                if (vector)
                {
                    currentTime += Time.deltaTime;
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.black, color, currentTime);
                }
                else
                {
                    currentTime -= Time.deltaTime;
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(color, Color.black, currentTime);
                }
            }
        }
    }

    private void OnMouseDown()
    {
        vostokController.ClickElement(this); //!!! передача скрипта
    }

    public void Active(bool state)
    {
        if (state)
        {
            isWork = true;
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            isWork = false;
            gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
        }
    }
}
