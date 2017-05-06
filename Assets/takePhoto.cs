using UnityEngine;
using UnityEngine.UI;
  
public class takePhoto : MonoBehaviour {  
    public RawImage rawimage;
    void Start () 
    {
        WebCamTexture webcamTexture = new WebCamTexture();
        rawimage.texture = webcamTexture;
        rawimage.material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }
}