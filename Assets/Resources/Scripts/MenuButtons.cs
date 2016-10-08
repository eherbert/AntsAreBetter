using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

    public GameObject PauseButton;
    public GameObject PlayButton;
    public GameObject DoublePlayButton;
    public GameObject AntsText;

    private bool isShowing;

    void Start() {
        SetAll(false);
        isShowing = false;
    }

    void OnMouseEnter() {
        if (!isShowing) { SetAll(true); } else { SetAll(false); }
    }

    public void PauseButtonOnPressed() {
        Time.timeScale = 0;
        SetAll(false);
    }
    public void PlayButtonOnPressed() {
        Time.timeScale = 1;
        SetAll(false);
    }
    public void DoublePlayButtonOnPressed() {
        Time.timeScale = 3;
        SetAll(false);
    }

    void SetAll(bool set) {
        PauseButton.SetActive(set);
        PlayButton.SetActive(set);
        DoublePlayButton.SetActive(set);
        AntsText.SetActive(set);
        isShowing = set;
    }
}

