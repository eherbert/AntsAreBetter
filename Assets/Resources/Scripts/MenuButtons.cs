using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

    public GameObject PauseButton;
    public GameObject PlayButton;
    public GameObject DoublePlayButton;
    public GameObject AntsText;
    public GameObject SettingsText;
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
        if (!isShowing) { SetAll(true); } else { SetAll(false); }
    }

    public void PauseButtonOnPressed() {
        Time.timeScale = 0;
        GameObject.Find("Queen").GetComponent<AntSpawning>().areSpawning = false;
        SetAll(false);
    }
    public void PlayButtonOnPressed() {
        Time.timeScale = 1;
        GameObject.Find("Queen").GetComponent<AntSpawning>().areSpawning = true;
        GameObject.Find("Queen").GetComponent<AntSpawning>().antSpawnCountdown = antSpawnCountdown;
        SetAll(false);
    }
    public void DoublePlayButtonOnPressed() {
        Time.timeScale = 3;
        GameObject.Find("Queen").GetComponent<AntSpawning>().areSpawning = true;
        GameObject.Find("Queen").GetComponent<AntSpawning>().antSpawnCountdown = antSpawnCountdown/3;
        SetAll(false);
    }

    void SetAll(bool set) {
        PauseButton.SetActive(set);
        PlayButton.SetActive(set);
        DoublePlayButton.SetActive(set);
        //AntsText.SetActive(set);
        SettingsText.SetActive(set);
        QuitText.SetActive(set);
		MuteText.SetActive (set);
        isShowing = set;
    }
}

