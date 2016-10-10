using UnityEngine;
using System.Collections;

public class SettingsButton : MonoBehaviour {

    public GameObject ColorButton;

    private bool isShowing;

    void Start() {
        SetAll(false);
    }

    /*void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            if (!isShowing) SetAll(true);
            else SetAll(false);
        }
    }*/

    void OnMouseEnter()
    {
        if (!isShowing) SetAll(true);
        else SetAll(false);
    }

    public void SetAll(bool set) {
        ColorButton.SetActive(set);
        isShowing = set;
    }
}
