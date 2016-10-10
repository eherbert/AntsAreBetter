using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour{

    public float walkSpeed;
    public float newDesiredVector2Threshold;
    public float attractionToGoodItemsThreshold;
    public float distanceOnDesiredVector2;
    public bool playerControlled;
    public int dayBorn;

    private Rigidbody2D theRigidBody;
    private Vector2 desiredVector2;
    private ArrayList goodLocations = new ArrayList();
    private int transferDataCountdown = 10000;
    private bool transferData = false;
    private ArrayList capitalLetters;

    /*public Player(string name, int day) {
        gameObject.name = name;
        dayBorn = day;
    }*/

    // Use this for initialization
    void Start() {
        theRigidBody = GetComponent<Rigidbody2D>();
        //dayBorn = 0;
        desiredVector2 = new Vector2(Random.Range(-1.0f, 1.0f) * distanceOnDesiredVector2, Random.Range(-1.0f, 1.0f) * distanceOnDesiredVector2);
    }

    // Update is called once per frame
    void Update() {
        if (playerControlled) PlayerControlledMovement();
        else RandomMovement();
    }

    void PlayerControlledMovement() {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        theRigidBody.velocity = new Vector2(inputX * walkSpeed, inputY * walkSpeed);
    }

    void RandomMovement() {
        if(Random.Range(0.0f,1.0f) < newDesiredVector2Threshold) {
            if((goodLocations.Count>0) && (Random.Range(0.0f,1.0f)<attractionToGoodItemsThreshold)) {
                desiredVector2 = (Vector2)goodLocations[(int)Random.Range(0.0f,(float)goodLocations.Count)];
            } else {
                desiredVector2 = new Vector2(Random.Range(-1.0f, 1.0f) * distanceOnDesiredVector2, Random.Range(-1.0f, 1.0f) * distanceOnDesiredVector2);
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, desiredVector2, walkSpeed*Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "GoodItems") {
            goodLocations.Add(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y));
        } else if(other.collider.tag == "Ants" && transferData) {
            //Put information transfer data here
        }
    }
}