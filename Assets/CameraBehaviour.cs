using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraBehaviour : MonoBehaviour {
    public RawImage rawImage;

    void Start () {
        WebCamTexture webcamTexture = new WebCamTexture();
        rawImage.texture = webcamTexture;
        rawImage.material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }
}
