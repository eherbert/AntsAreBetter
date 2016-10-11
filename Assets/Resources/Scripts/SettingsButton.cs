using UnityEngine;
using System.Collections;

public class SettingsButton : MonoBehaviour {

    public GameObject ColorButton;
    public GameObject white;
    public GameObject red;
    public GameObject orange;
    public GameObject yellow;
    public GameObject green;
    public GameObject blue;
    public GameObject violet;
    public GameObject black;

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
        if (!isShowing) SetSome(true);
        else SetAll(false);
    }

    public void SetSome(bool set) {
        ColorButton.SetActive(set);
        isShowing = set;
    }

    public void SetAll(bool set) {
        ColorButton.SetActive(set);
        white.SetActive(set);
        red.SetActive(set);
        orange.SetActive(set);
        yellow.SetActive(set);
        green.SetActive(set);
        blue.SetActive(set);
        violet.SetActive(set);
        black.SetActive(set);
        isShowing = set;
    }
}
