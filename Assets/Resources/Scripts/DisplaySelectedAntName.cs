using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplaySelectedAntName : MonoBehaviour {

    private GameObject SelectedAnt;
    private Vector2 ZoomedOutSize;
    private Vector2 ZoomSizeRate;

    void Start() {
        //ZoomedOutSize = new Vector2(GetComponent<RectTransform>().rect.width, GetComponent<RectTransform>().rect.height);
    }

    void Update() {
        //ZoomSizeRate = new Vector2(gameObject.GetComponentInParent<ZoomDialog>().MaxSize.x
        DisplayAntName();
    }

    void DisplayAntName() {
        if (SelectedAnt.transform.name == "Queen") gameObject.GetComponent<Text>().text = "";
        else
        {
            gameObject.GetComponent<Text>().text = SelectedAnt.name;
            //gameObject.transform.GetComponent<RectTransform>().anchoredPosition = SelectedAnt.transform.position + new Vector3(0, 10, 0);
        }
    }

    public void SetSelectedAnt(GameObject ant) {
        SelectedAnt = ant;
        gameObject.GetComponent<Text>().text = SelectedAnt.name;
    }

}
