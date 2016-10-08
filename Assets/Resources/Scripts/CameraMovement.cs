using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public float ROTSpeed;
    public GameObject toFollow;
    
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        ScrollWheelZoom();
        RightClickPanning();
        if (toFollow != null) {
            transform.position = new Vector3(toFollow.transform.position.x, toFollow.transform.position.y, transform.position.z);
            //Debug.Log(toFollow.transform.position.x);
        }
    }

    void ScrollWheelZoom() {
        float input = Input.GetAxis("Mouse ScrollWheel");
        if(input>0 && gameObject.transform.position.z<-1) gameObject.transform.Translate(0, 0, input * ROTSpeed);
        else if(input<0) gameObject.transform.Translate(0, 0, input * ROTSpeed);
    }

    void RightClickPanning() {
        //float input = Input.GetMouseButtonDown(1);
    }


}