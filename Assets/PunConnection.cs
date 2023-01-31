using System.Globalization;

using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PunConnection : MonoBehaviourPunCallbacks
{
    public static PunConnection Instance;
    private void Awake()
    {
        Instance = this;
        print("Created Instance");
    }
    public int Version = 1;
    public byte MaxPlayers = 4;
    public int playerTTL = -1;
    public void ConnectNow()
    {
        PhotonNetwork.ConnectUsingSettings();
        UIManager.Instance.Log("connecting");
        PhotonNetwork.GameVersion = Version.ToString();
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to Server in region " + PhotonNetwork.CloudRegion);
        UIManager.Instance.Log("connected to Server");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedLobby()
    {
        UIManager.Instance.Log("Joined Lobby");
        print("Lobby Joined");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRandomFailed Creating New Room");
        UIManager.Instance.Log("Join Random Room Failed Creating new one");
        RoomOptions roomOptions = new RoomOptions() { MaxPlayers = this.MaxPlayers };
        if (playerTTL >= 0)
            roomOptions.PlayerTtl = playerTTL;

        PhotonNetwork.CreateRoom(null, roomOptions, null);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        UIManager.Instance.Log("Disconnected ("+cause+")");
        Debug.Log("OnDisconnected(" + cause + ")");
        UIManager.Instance.authPanel.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        UIManager.Instance.Log("Room Joined");
        Debug.Log("Room Join in Region " + PhotonNetwork.CloudRegion);
    }
}