using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

    const string Version = "v0.0.1";

    public string RoomName = "VVR";
    public string PlayerPrefabName = "Player";
    public Transform SpawnPoint;

	void Start () {
        //PhotonNetwork.ConnectUsingSettings(Version);
	}

    /*void OnJoinedLobby()
    {
        RoomOptions RoomOptions = new RoomOptions() { isVisible = false, maxPlayers = 4 };
        PhotonNetwork.JoinOrCreateRoom(RoomName, roomOptions, TypedLobby.Default);
    }

    void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(PlayerPrefabName, SpawnPoint.position, SpawnPoint.rotation, 0);
    }*/
	
}
