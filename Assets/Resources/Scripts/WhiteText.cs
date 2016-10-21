using UnityEngine;
using System.Collections;

public class WhiteText : MonoBehaviour {

    public GameObject repo;
    public string color;

	void OnMouseOver() {
        if(Input.GetMouseButtonDown(0)) {
            repo.GetComponent<Observed>().Notify(gameObject, "color", color);
        }
    }
}
