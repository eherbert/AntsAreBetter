using UnityEngine;
using System.Collections;

public class textManagerScript : MonoBehaviour {

    public void ToggleTime() {
        if (Time.timeScale == 1) Time.timeScale = 0;
        else Time.timeScale = 1;
    }
}
