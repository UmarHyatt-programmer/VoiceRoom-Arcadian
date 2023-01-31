using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.AuthenticationModels;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabAuthentication : MonoBehaviour
{
    private void Start()
    {
        PlayFab.PlayFabSettings.TitleId = "B19B9";
    }
    public void OnError(PlayFabError error)
    {
        Debug.LogError(error.Error);
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
           // CreateAccount();
        }
    }
    public void CreateAccount()
    {
        var req = new RegisterPlayFabUserRequest { Email = "Guest@guest.com", Password = "123456", Username = "GuestUserName",RequireBothUsernameAndEmail=false };
        PlayFabClientAPI.RegisterPlayFabUser(req, OnRegisterUser, OnError);
    }
    public void OnRegisterUser(RegisterPlayFabUserResult result)
    {
        print(result.Username + " registered");
    }
    public void Login(string email)
    {
        var request = new LoginWithEmailAddressRequest { Email = email, Password = "123456" };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLogin, OnError);
    }
    public void OnLogin(LoginResult result)
    {
        print("login");
        PunConnection.Instance.ConnectNow();
    }
}
