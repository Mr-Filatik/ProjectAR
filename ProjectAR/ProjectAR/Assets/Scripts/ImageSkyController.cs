using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSkyController : MonoBehaviour
{
    [SerializeField] private Camera camera = null;

    private void Update()
    {
        transform.localEulerAngles = camera.transform.localEulerAngles;
        //transform.localPosition = new Vector3(-camera.transform.position.x, -camera.transform.position.y, -camera.transform.position.z);
    }
}
