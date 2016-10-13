using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitlePlayer : MonoBehaviour
{

    public float walkSpeed;
    public float newDesiredVector2Threshold;
    public float distanceOnDesiredVector2;

    private Rigidbody2D theRigidBody;
    private Vector2 desiredVector2;
    private float titleWaitCountdown;
    private float counter;
    
    // Use this for initialization
    void Start()
    {
        theRigidBody = GetComponent<Rigidbody2D>();
        counter = Random.Range(1.0f, 1000.0f);
        //desiredVector2 = new Vector2(Random.Range(-1.0f, 1.0f) * distanceOnDesiredVector2, Random.Range(-1.0f, 1.0f) * distanceOnDesiredVector2);
        //titleWaitCountdownInner = titleWaitCountdown - 3*counter;
        titleWaitCountdown = Random.Range(0.0f, 4000.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //if (titleWaitCountdownInner <= 0) { RandomMovement(); }
        //else { titleWaitCountdownInner-=counter; }
        if (titleWaitCountdown <= 0) { RandomMovement(); }
        else { titleWaitCountdown-=Random.Range(0.0f,2.0f); }
    }

    void RandomMovement()
    {
        if (Random.Range(0.0f, 1.0f) < newDesiredVector2Threshold)
        {
            //desiredVector2 = new Vector2(Random.Range(-1.0f, 1.0f) * distanceOnDesiredVector2, Random.Range(-1.0f, 1.0f) * distanceOnDesiredVector2);
            desiredVector2 = new Vector2(UnityEngine.Random.Range(-1.0f, 1.0f) * distanceOnDesiredVector2 + gameObject.transform.position.x, UnityEngine.Random.Range(-1.0f, 1.0f) * distanceOnDesiredVector2 + gameObject.transform.position.y);
        }
        transform.position = Vector3.MoveTowards(transform.position, desiredVector2, walkSpeed * Time.deltaTime);
    }
}