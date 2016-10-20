using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {

    public int waterCountdown;

    private int waterCountdownInner;
    private Animator animationController;
    private GameObject repo;
    private ArrayList currentColorTexts;

	// Use this for initialization
	void Start () {
        waterCountdownInner = waterCountdown;
        animationController = gameObject.GetComponent<Animator>();
        repo = GameObject.Find("Repo").gameObject;
        currentColorTexts = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
        if (waterCountdownInner < 0) {
            foreach(string color in currentColorTexts) {
                repo.GetComponent<Observed>().Deregister(gameObject,"goodItems",color);
            }
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Ants") {
            animationController.SetBool("isActive", true);
            if (!currentColorTexts.Contains(other.transform.GetComponent<Player>().ReadCurrentColorText())) currentColorTexts.Add(other.transform.GetComponent<Player>().ReadCurrentColorText());
            repo.GetComponent<Observed>().Register(gameObject, "goodItems", other.transform.GetComponent<Player>().ReadCurrentColorText());
        }
    }

    void OnCollisionStay2D(Collision2D other) {
        if (other.collider.tag == "Ants") { waterCountdownInner--; }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.collider.tag == "Ants") {
        }
    }
}
