using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VostokController : MonoBehaviour
{
    ClickScript activeElenent = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickElement(ClickScript clickScript)
    {
        if (activeElenent == clickScript)
        {
            clickScript.Active(false);
            activeElenent = null;
        }
        else
        {
            clickScript.Active(true);
            activeElenent = null;
        }
    }
}
