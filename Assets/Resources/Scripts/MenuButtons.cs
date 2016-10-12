using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

    public GameObject PauseButton;
    public GameObject PlayButton;
    public GameObject DoublePlayButton;
    public GameObject AntsText;
    public GameObject SettingsText;
    public GameObject ColorText;
    public GameObject WhiteText;
    public GameObject RedText;
    public GameObject OrangeText;
    public GameObject YellowText;
    public GameObject GreenText;
    public GameObject BlueText;
    public GameObject VioletText;
    public GameObject BlackText;
    public GameObject QuitText;
	public GameObject MuteText;

    private bool isShowing;
    private int antSpawnCountdown;

    void Start() {
        SetAll(false);
        isShowing = false;
		antSpawnCountdown = GameObject.Find("Queen").GetComponent<AntSpawning>().antSpawnCountdown;
    }

    void OnMouseEnter() {
        if (!isShowing) { SetSome(true); } else { SetAll(false); }
    }

    public void PauseButtonOnPressed() {
        Time.timeScale = 0;
        GameObject.Find("Queen").GetComponent<AntSpawning>().areSpawning = false;
        //SetAll(false);
    }
    public void PlayButtonOnPressed() {
        Time.timeScale = 1;
        GameObject.Find("Queen").GetComponent<AntSpawning>().areSpawning = true;
        GameObject.Find("Queen").GetComponent<AntSpawning>().antSpawnCountdown = antSpawnCountdown;
        //SetAll(false);
    }
    public void DoublePlayButtonOnPressed() {
        Time.timeScale = 3;
        GameObject.Find("Queen").GetComponent<AntSpawning>().areSpawning = true;
        GameObject.Find("Queen").GetComponent<AntSpawning>().antSpawnCountdown = antSpawnCountdown/3;
        //SetAll(false);
    }

    void SetSome(bool set) {
        PauseButton.SetActive(set);
        PlayButton.SetActive(set);
        DoublePlayButton.SetActive(set);
        //AntsText.SetActive(set);
        SettingsText.SetActive(set);
        QuitText.SetActive(set);
        MuteText.SetActive(set);
        isShowing = set;
    }

    void SetAll(bool set) {
        PauseButton.SetActive(set);
        PlayButton.SetActive(set);
        DoublePlayButton.SetActive(set);
        //AntsText.SetActive(set);
        SettingsText.SetActive(set);
        ColorText.SetActive(set);
        WhiteText.SetActive(set);
        RedText.SetActive(set);
        OrangeText.SetActive(set);
        YellowText.SetActive(set);
        GreenText.SetActive(set);
        BlueText.SetActive(set);
        VioletText.SetActive(set);
        BlackText.SetActive(set);
        QuitText.SetActive(set);
		MuteText.SetActive (set);
        isShowing = set;
    }
}

