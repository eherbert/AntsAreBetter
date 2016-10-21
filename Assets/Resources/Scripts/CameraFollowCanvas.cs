using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraFollowCanvas : MonoBehaviour
{
    private Text currentSelectedAntText;
    private Transform currentSelectedAnt;

    void OnMouseOver() { if (Input.GetMouseButtonDown(0)) GameObject.Find("Main Camera").GetComponent<CameraMovement>().toFollow = null; }


}
