using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {

    public int waterCountdown;

    private int waterCountdownInner;
    private Animator animationController;

	// Use this for initialization
	void Start () {
        waterCountdownInner = waterCountdown;
        animationController = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (waterCountdownInner < 0) Destroy(gameObject);
	}

    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Ants") {
            animationController.SetBool("isActive", true);
            Debug.Log("hi");
        }
    }

    void OnCollisionStay2D(Collision2D other) {
        if (other.collider.tag == "Ants") { waterCountdownInner--; }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.collider.tag == "Ants") {
            animationController.SetBool("isActive", false);
            Debug.Log("bye");
        }
    }
}
