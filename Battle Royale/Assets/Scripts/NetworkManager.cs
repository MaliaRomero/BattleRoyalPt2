using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public int maxPlayers = 10;

    //instance
    public static NetworkManager instance;

    private void Awake()
    {
        instance = this;
        //this line makes the pickups weird and the game not re-playable
        //DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //connect to master server
        PhotonNetwork.ConnectUsingSettings();
    }


    public override void OnConnectedToMaster ()
    {

        // seems this is now required in order to receive OnRoomListUpdate callbacks:
        PhotonNetwork.JoinLobby();

    }

    //attempts to create room
    public void CreateRoom (string roomName)
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = (byte)maxPlayers;

        PhotonNetwork.CreateRoom(roomName, options);
    }

    //attempts to join a room
    public void JoinRoom (string roomName) 
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    [PunRPC]
    public void ChangeScene (string sceneName) 
    {
        PhotonNetwork.LoadLevel(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
