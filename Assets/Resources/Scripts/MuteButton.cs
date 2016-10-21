using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour {

	private AudioSource audioSource;
	private bool isMuted;
    private Text muteText;

    void Start() {
		audioSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        muteText = GameObject.Find("MuteText").GetComponent<Text>();
        isMuted = false;
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			if (audioSource.mute) Unmute();
			else Mute();
		}
	}

	void Mute() {
        muteText.text = "Unmute";
		audioSource.mute = true;
	}

	void Unmute() {
        muteText.text = "Mute";
        audioSource.mute = false;
	}
}
