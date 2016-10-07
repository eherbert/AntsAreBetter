using UnityEngine;
using System.Collections;

public class BodyFollowScript : MonoBehaviour {

    public Transform player;
    public float chaseSpeed = 5f;
    public float stopDistance = 5f;
    public float currentSpeed;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, player.position) >= stopDistance) // check the distance between this game object and Player and continue if it's less than Range
        {
            currentSpeed = chaseSpeed * Time.deltaTime; // set the CurrentSpeed to ChaseSpeed and multiply by Time.deltaTime (this prevents it from moving based on FPS)
            transform.position = Vector3.MoveTowards(transform.position, player.position, currentSpeed);  // set this game objects position to the Player's position at the speed of CurrentSpeed
        }
    }
}