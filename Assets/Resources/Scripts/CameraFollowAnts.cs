using UnityEngine;
using System.Collections;

public class CameraFollowAnts : MonoBehaviour {

    private GameObject mainCamera;
    private GameObject selectedAntText;

    void Start() {
        mainCamera = GameObject.Find("Main Camera");
        selectedAntText = gameObject.transform.FindChild("Canvas").transform.FindChild("SelectedAntText").gameObject;
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            mainCamera.GetComponent<CameraMovement>().toFollow = gameObject;
            selectedAntText.GetComponent<DisplaySelectedAntName>().SetSelectedAnt(gameObject.transform.parent.gameObject);
        }
    }
}
