
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PunConnection : MonoBehaviourPunCallbacks
{
    public static PunConnection Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public int Version = 1;
    public byte MaxPlayers = 4;
    public int playerTTL = -1;
    public void ConnectNow()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = Version.ToString();
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to Server in region " + PhotonNetwork.CloudRegion);
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedLobby()
    {
        print("Lobby Joined");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRandomFailed Creating New Room");

        RoomOptions roomOptions = new RoomOptions() { MaxPlayers = this.MaxPlayers };
        if (playerTTL >= 0)
            roomOptions.PlayerTtl = playerTTL;

        PhotonNetwork.CreateRoom(null, roomOptions, null);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("OnDisconnected(" + cause + ")");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Room Join in Region " + PhotonNetwork.CloudRegion);
    }
}