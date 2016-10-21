using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public float ROTSpeed;
    public GameObject toFollow;
    public float cameraSnapSpeed;
    
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        ScrollWheelZoom();
        RightClickPanning();
        if (toFollow != null) {
            //Vector2 tmp = Vector2.MoveTowards(transform.position, toFollow.transform.position, cameraSnapSpeed);
            //gameObject.transform.Translate(tmp.x, tmp.y, 0);
            transform.position = new Vector3(toFollow.transform.position.x, toFollow.transform.position.y, transform.position.z);
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