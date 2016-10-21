using UnityEngine;
using System.Collections;

public class QuitButton : MonoBehaviour {

    public GameObject settingsButton;

	void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) Application.Quit();
    }

    void OnMouseEnter()
    {
        settingsButton.GetComponent<SettingsButton>().SetAll(false);
    }
}
