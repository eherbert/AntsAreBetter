using UnityEngine;
using System.Collections;

public class ColorButtonScript : MonoBehaviour {

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

    void OnMouseEnter() {
        if (isShowing) SetAll(false);
        else SetAll(true);
    }

    public void SetAll(bool set) {
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
