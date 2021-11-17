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
    private Color defaultColor = Color.black;
    private Color currentColor = new Color32(135, 126, 68, 255);

    private void Update()
    {
        if (isWork)
        {
            if (currentTime > cooldownTime || currentTime < 0)
            {
                if (vector)
                {
                    vector = false;
                    currentTime = 1f;
                }
                else
                {
                    vector = true;
                    currentTime = 0f;
                }
            }
            else
            {
                if (vector)
                {
                    currentTime += Time.deltaTime;
                    //gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.white, Color.green, currentTime);
                }
                else
                {
                    currentTime -= Time.deltaTime;
                    
                }
                gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(defaultColor, currentColor, currentTime));
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
            currentTime = 0f;

            //gameObject.GetComponent<Renderer>().material.color = currentColor;
            gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", currentColor);

            //gameObject.GetComponent<Renderer>().material = material;
        }
        else
        {
            isWork = false;
            gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", defaultColor);
        }
    }
}
