using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitlePlayer : MonoBehaviour
{

    public float walkSpeed;
    public float newDesiredVector2Threshold;
    public float distanceOnDesiredVector2;
    public float titleWaitCountdown;

    private Rigidbody2D theRigidBody;
    private Vector2 desiredVector2;
    private float titleWaitCountdownInner;
    private float counter;
    
    // Use this for initialization
    void Start()
    {
        theRigidBody = GetComponent<Rigidbody2D>();
        titleWaitCountdownInner = titleWaitCountdown;
        counter = Random.Range(1.0f, 1000.0f);
        desiredVector2 = new Vector2(Random.Range(-1.0f, 1.0f) * distanceOnDesiredVector2, Random.Range(-1.0f, 1.0f) * distanceOnDesiredVector2);
    }

    // Update is called once per frame
    void Update()
    {
        if (titleWaitCountdownInner <= 0) { RandomMovement(); }
        else { titleWaitCountdownInner-=counter; }
    }
    
    void RandomMovement()
    {
        if (Random.Range(0.0f, 1.0f) < newDesiredVector2Threshold)
        {
            desiredVector2 = new Vector2(Random.Range(-1.0f, 1.0f) * distanceOnDesiredVector2, Random.Range(-1.0f, 1.0f) * distanceOnDesiredVector2);
        }
        transform.position = Vector3.MoveTowards(transform.position, desiredVector2, walkSpeed * Time.deltaTime);
    }
}