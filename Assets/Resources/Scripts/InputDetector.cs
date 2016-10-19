using UnityEngine;
using System.Collections;

public class InputDetector : MonoBehaviour {

    public GameObject canvas;
    public GameObject waterPrefab;
    public GameObject repo;
    public GameObject mainCamera;

    private GameObject tmp;

	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if(Input.GetKey("w")) {
                Vector3 posVec = Input.mousePosition;
                posVec.z = (0-Camera.main.transform.position.z)+1;
                tmp = Instantiate(waterPrefab, Camera.main.ScreenToWorldPoint(posVec), Quaternion.identity) as GameObject;
            }
        } else if(Input.GetMouseButtonDown(1)) {
            Vector3 posVec = Input.mousePosition;
            posVec.z = transform.position.z - Camera.main.transform.position.z;

        }
    }
}
