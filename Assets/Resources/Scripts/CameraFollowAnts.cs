using UnityEngine;
using System.Collections;

public class CameraFollowAnts : MonoBehaviour {

    //private Transform head;

    /*void Start() {
        head = gameObject.transform.Find("Head");
    }

    void Update() {
        gameObject.transform.position = head.position;
    }*/

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) GameObject.Find("Main Camera").GetComponent<CameraMovement>().toFollow = gameObject;
        Debug.Log("hi");
    }

}
