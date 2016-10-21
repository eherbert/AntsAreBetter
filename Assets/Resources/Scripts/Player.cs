using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Player : Observer {

    public float walkSpeed;
    public float newDesiredVector2Threshold;
    public float attractionToGoodItemsThreshold;
    public bool playerControlled;
    public GameObject repo;

    private float distanceOnDesiredVector2;
    private Rigidbody2D theRigidBody;
    private Vector2 desiredVector2;
    private ArrayList goodLocations;
    private ArrayList badLocations;
    private int transferDataCountdown = 10000;
    private bool transferData = false;
    private int dayBorn;
    private string currentColorText;

    // Use this for initialization
    void Start() {
        theRigidBody = GetComponent<Rigidbody2D>();
        goodLocations = new ArrayList();
        badLocations = new ArrayList();
        repo = GameObject.Find("Repo");
        //dayBorn = 0;
        distanceOnDesiredVector2 = UnityEngine.Random.Range(100f, 500f);
        desiredVector2 = new Vector2(UnityEngine.Random.Range(-1.0f, 1.0f) * distanceOnDesiredVector2, UnityEngine.Random.Range(-1.0f, 1.0f) * distanceOnDesiredVector2);
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
        if(UnityEngine.Random.Range(0.0f,1.0f) < newDesiredVector2Threshold) {
            if((goodLocations.Count>0) && (UnityEngine.Random.Range(0.0f,1.0f)<attractionToGoodItemsThreshold)) {
                desiredVector2 = (Vector3)goodLocations[UnityEngine.Random.Range(0,goodLocations.Count)];
            } else {
                desiredVector2 = new Vector2(UnityEngine.Random.Range(-1.0f, 1.0f) * distanceOnDesiredVector2 + gameObject.transform.position.x, UnityEngine.Random.Range(-1.0f, 1.0f) * distanceOnDesiredVector2 + gameObject.transform.position.y);
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, desiredVector2, walkSpeed*Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other) {
        //if (other.collider.tag == "GoodItems") { repo.GetComponent<Observed>().Register(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), "goodItems", "tmp"); }
        //else if(other.collider.tag == "BadItems") { repo.GetComponent<Observed>().Register(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), "goodItems", "tmp"); }
    }

    public void SetDayBorn(int i) { dayBorn = i; }
    public void SetCurrentColorText(string s) { currentColorText = s; }
    public string ReadCurrentColorText() { return currentColorText; }

    public override void OnNotify(GameObject observed, string message, string info)
    {
        if(info==currentColorText) {
            switch(message) {
                case "goodItems":
                    if(!goodLocations.Contains(observed.transform.position)) goodLocations.Add(observed.transform.position);
                    break;
                case "badItems":
                    if (!badLocations.Contains(observed.transform.position)) badLocations.Add(observed.transform.position);
                    break;
            }
        }
    }
    public void OnNotifyDeregister(GameObject observed, string message, string info)
    {
        if (info == currentColorText) {
            switch (message)
            {
                case "goodItems":
                    goodLocations.Remove(observed.transform.position);
                    break;
                case "badItems":
                    badLocations.Remove(observed.transform.position);
                    break;
            }
        }
    }
}