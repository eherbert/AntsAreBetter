using UnityEngine;
using System.Collections;

public class CameraFollowCanvas : MonoBehaviour
{
    void OnMouseOver() { if (Input.GetMouseButtonDown(0)) GameObject.Find("Main Camera").GetComponent<CameraMovement>().toFollow = null; }
}
