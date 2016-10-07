using UnityEngine;

using System.Collections;

using UnityEngine.UI;



public class Player : MonoBehaviour{

    public float walkSpeed;

    private Rigidbody2D theRigidBody;

    // Use this for initialization
    void Start()
    {
        theRigidBody = transform.GetChild(0).gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        theRigidBody.velocity = new Vector2(inputX * walkSpeed, inputY * walkSpeed);
    }
}