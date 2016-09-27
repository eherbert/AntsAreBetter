using UnityEngine;
using System.Collections;

public class Player : Photon.PunBehaviour {

    Camera playerCam;

	// Use this for initialization
	void Start () {
	
	}

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        playerCam = GetComponentInChildren<Camera>();
        if(!photonView.isMine)
        {
            playerCam.gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
