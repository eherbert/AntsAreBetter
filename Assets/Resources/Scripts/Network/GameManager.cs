using UnityEngine;
using System.Collections;

public class GameManager : Photon.PunBehaviour {

    public static GameManager instance;
    public static GameObject player;

    // Use this for initialization
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("Fractals");
    }

    void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
        PhotonNetwork.automaticallySyncScene = true;
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void JoinGame()
    {
        RoomOptions ro = new RoomOptions();
        ro.maxPlayers = 6;
        PhotonNetwork.JoinOrCreateRoom("Default Room", ro, null);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        if(PhotonNetwork.isMasterClient)
        {
            PhotonNetwork.LoadLevel("Game Scene");
        }
    }

    void OnLevelWasLoaded(int levelNumber)
    {
        if (!PhotonNetwork.inRoom) return;
        player = PhotonNetwork.Instantiate(
            "Player",
            new Vector3(0.0f, 0.5f, 0.0f),
            Quaternion.identity, 0);
    }
}