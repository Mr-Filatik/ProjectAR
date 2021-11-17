using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    [SerializeField] private VostokController vostokController = null;

    [SerializeField] private Material material = null;

    private bool isWork = false;
    private float currentTime = 0f;
    private bool vector = true;
    private float cooldownTime = 1f;
    private Color defaultColor = Color.white;
    private Color currentColor = new Color((float)135 / 256, (float)126 / 256, (float)68 / 256);

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
                gameObject.GetComponent<Renderer>().material.color = Color.Lerp(defaultColor, currentColor, currentTime);
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
            //isWork = true;
            //currentTime = 0f;
            
            //gameObject.GetComponent<Renderer>().material.color = currentColor;

            //gameObject.GetComponent<Renderer>().material = material;
        }
        else
        {
            isWork = false;
            gameObject.GetComponent<Renderer>().material.color = defaultColor;
        }
    }
}
