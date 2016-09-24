using UnityEngine;
using System.Collections;

public class Fractal2D : MonoBehaviour {

    public Sprite sprite;
    public Material material;
    public int maxDepth;
    public float childScale;
    public float spawnProbability;
    public bool isRandomSpawn;
    public float rotationSpeed;
    public float maxRotationSpeed;
    public bool isRotating;

    private int depth;

    private static Vector3[] childDirections = {
        Vector3.up,
        Vector3.right,
        Vector3.down,
        Vector3.left
    };

    private static Quaternion[] childOrientations = {
        Quaternion.identity,
        Quaternion.Euler(0f,0f,-90f),
        Quaternion.Euler(0f,0f,180f),
        Quaternion.Euler(0f,0f,90f)
    };
    
	void Start () {
        gameObject.AddComponent<SpriteRenderer>().sprite = sprite;
        //GetComponent<SpriteRenderer>().material.color = Color.Lerp(Color.white, Color.magenta, (float)depth / maxDepth);
        GetComponent<SpriteRenderer>().material.color = new Color((Random.Range(0.0f, 1.0f)), (Random.Range(0.0f, 1.0f)), (Random.Range(0.0f, 1.0f)));
        //rotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);
        if (depth < maxDepth) { StartCoroutine(CreateChildren()); }
	}
	private IEnumerator CreateChildren () {
        for(int i=0; i<childDirections.Length; i++) {
            if (isRandomSpawn) {
                if (Random.value < spawnProbability) {
                    yield return new WaitForSeconds(0.0f);
                    new GameObject("Fractal Child").AddComponent<Fractal2D>().Initialize(this, i);
                }
            } else {
                yield return new WaitForSeconds(0.0f);
                new GameObject("Fractal Child").AddComponent<Fractal2D>().Initialize(this, i);
            }
        }
    }

    private void Initialize(Fractal2D parent, int childIndex) {
        sprite = parent.sprite;
        maxDepth = parent.maxDepth;
        childScale = parent.childScale;
        spawnProbability = parent.spawnProbability;
        isRandomSpawn = parent.isRandomSpawn;
        rotationSpeed = parent.rotationSpeed;
        maxRotationSpeed = parent.maxRotationSpeed;
        isRotating = parent.isRotating;
        depth = parent.depth + 1;
        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = (childDirections[childIndex] * (0.5f + 0.5f * childScale)) - new Vector3(0f, 0f, 0.1f);
        transform.localRotation = childOrientations[childIndex];
    }
    
    void Update () {
        //if(isRotating) transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        //if(isRotating) transform.Rotate(rotationSpeed * Time.deltaTime, 0f, 0f);
        if(isRotating) transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    /*void OnMouseEnter() {
        GetComponent<SpriteRenderer>().material.color = new Color((Random.Range(0.0f, 1.0f)), (Random.Range(0.0f, 1.0f)), (Random.Range(0.0f, 1.0f)));
    }*/
}
