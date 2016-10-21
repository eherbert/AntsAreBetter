using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrailButton : MonoBehaviour {

    public GameObject ColorsText;
    public GameObject repo;

    private bool isOn;
    private Text muteText;

    void Start()
    {
        muteText = GameObject.Find("TrailText").GetComponent<Text>();
        isOn = false;
    }

    void OnMouseEnter()
    {
        ColorsText.GetComponent<ColorButtonScript>().SetAll(false);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isOn) {
                TrailOff();
                repo.GetComponent<Observed>().Notify(gameObject, "trail", "off");
            } else {
                TrailOn();
                repo.GetComponent<Observed>().Notify(gameObject, "trail", "on");
            }
        }
    }

    void TrailOn()
    {
        muteText.text = "Trail On";
        isOn = true;
    }

    void TrailOff()
    {
        muteText.text = "Trail Off";
        isOn = false;
    }
}
