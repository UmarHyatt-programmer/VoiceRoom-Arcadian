using System.Net.Http.Headers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using StarterAssets;
public class CharacterSpawner : MonoBehaviourPunCallbacks
{
    public GameObject adminPlayerPrefab,guestPlayerPrefab,mobileUI,player;
    public Transform adminPos,guestPos;
    public UICanvasControllerInput mobileCanvus;
    public override void OnJoinedRoom()
    {
        SpawnPlayer();
    }
    public void SpawnPlayer()
    {
        var spawnPos=guestPos;
        if(UIManager.Instance.playfabAuthentication.UserName.Contains("Admin"))
        {
            spawnPos=adminPos;
            print("Admin Joined");
            player= PhotonNetwork.Instantiate(adminPlayerPrefab.name,spawnPos.position,spawnPos.rotation);
        }
        else
        {
            print("Guest Joined");
            player= PhotonNetwork.Instantiate(guestPlayerPrefab.name,spawnPos.position,spawnPos.rotation);
            mobileUI.SetActive(true);
            mobileCanvus.starterAssetsInputs=player.GetComponent<StarterAssetsInputs>();
        }
    }
}
