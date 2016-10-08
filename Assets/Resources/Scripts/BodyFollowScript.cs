using UnityEngine;
using System.Collections;

public class BodyFollowScript : MonoBehaviour {

    public Transform player;
    public float currentSpeed;

    private float stopDistance;
    private float chaseSpeed;

    // Use this for initialization
    void Start () {
        stopDistance = (float)((transform.parent.localScale.x)/5);
        chaseSpeed = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, player.position) >= stopDistance) {
            currentSpeed = chaseSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.position, currentSpeed);
        }
    }
}