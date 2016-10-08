using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public float ROTSpeed;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        ScrollWheelZoom();
    }

    void ScrollWheelZoom() {
        float input = Input.GetAxis("Mouse ScrollWheel");
        if(input>0 && gameObject.transform.position.z<-1) gameObject.transform.Translate(0, 0, input * ROTSpeed);
        else if(input<0) gameObject.transform.Translate(0, 0, input * ROTSpeed);
    }
}