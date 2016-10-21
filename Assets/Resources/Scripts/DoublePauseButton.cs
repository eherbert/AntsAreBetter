using UnityEngine;
using System.Collections;

public class DoublePauseButton : MonoBehaviour {

    public GameObject settingsButton;

    void OnMouseEnter()
    {
        settingsButton.GetComponent<SettingsButton>().SetAll(false);
    }
}
