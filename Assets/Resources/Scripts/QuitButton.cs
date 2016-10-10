using UnityEngine;
using System.Collections;

public class QuitButton : MonoBehaviour {

	void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) Application.Quit();
    }
}
