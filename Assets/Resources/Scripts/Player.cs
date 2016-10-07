using UnityEngine;

using System.Collections;

using UnityEngine.UI;



public class Player : MonoBehaviour{

    public float walkSpeed;
    public float newDesiredVector2Threshold;
    public bool playerControlled;

    private Rigidbody2D theRigidBody;
    private Vector2 desiredVector2;

    // Use this for initialization
    void Start()
    {
        theRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControlled) PlayerControlledMovement();
        else RandomMovement();
    }

    void PlayerControlledMovement()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        theRigidBody.velocity = new Vector2(inputX * walkSpeed, inputY * walkSpeed);
    }

    void RandomMovement()
    {
        if(Random.Range(0.0f,1.0f)< newDesiredVector2Threshold)
        {
            desiredVector2 = new Vector2(Random.Range(-1.0f,1.0f)*1000,Random.Range(-1.0f,1.0f)*1000);
        }
        transform.position = Vector3.MoveTowards(transform.position, desiredVector2, walkSpeed*Time.deltaTime);
    }
}