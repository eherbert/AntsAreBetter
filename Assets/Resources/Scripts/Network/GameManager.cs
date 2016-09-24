using UnityEngine;
using System.Collections;

public class GameManager : Photon.PunBehaviour
{

    public static GameManager instance;

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
}