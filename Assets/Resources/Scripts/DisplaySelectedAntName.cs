using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplaySelectedAntName : MonoBehaviour {

    private GameObject SelectedAnt;

    void Update() {
        DisplayAntName();
    }

    void DisplayAntName() {
        if (SelectedAnt.transform.name == "Queen") gameObject.GetComponent<Text>().text = "";
        else {
            gameObject.GetComponent<Text>().text = SelectedAnt.name;
        }
    }

    public void SetSelectedAnt(GameObject ant) {
        SelectedAnt = ant;
        gameObject.GetComponent<Text>().text = SelectedAnt.name;
        gameObject.GetComponent<Text>().color = SelectedAnt.transform.Find("Head").GetComponent<SpriteRenderer>().color;
    }

}
