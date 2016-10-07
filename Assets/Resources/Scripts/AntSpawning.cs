using UnityEngine;
using System.Collections;

public class AntSpawning : MonoBehaviour {

    public GameObject antPrefab;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 100; i++) Instantiate(antPrefab, new Vector3(0, 0, 0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
