using UnityEngine;
using System.Collections;

public class Webcam : MonoBehaviour {
 
    // Use this for initialization
    private WebCamTexture cam;
    void Start () {
        WebCamTexture cam = new WebCamTexture();
        Renderer renderer = GetComponent<Renderer>();
 
        renderer.material.mainTexture = cam;
        cam.Play();
    }
 
    // Update is called once per frame
    void Update () {
		
    }
}