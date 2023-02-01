
using UnityEngine;
using UnityEngine.UI;
using Photon.Voice.PUN;
using Photon.Pun;
using UnityEngine.iOS;
public class VoiceDetector : MonoBehaviour
{
    public PhotonVoiceView photonVoiceView;
    public Photon.Pun.PhotonView photonView;
    public GameObject playerCam;

    [SerializeField]
    private GameObject recorderSprite;

    [SerializeField]
    private GameObject speakerSprite;
    private void Start() 
    {
        if(!photonView.IsMine)
        {
            playerCam.SetActive(false);
        }
    }
    private void Update()
    {
        if(photonView.IsMine||true)
        {
       // photonView.RPC("DetectVoice", RpcTarget.OthersBuffered,photonVoiceView.IsRecording,photonVoiceView.IsSpeaking);
        this.recorderSprite.SetActive(this.photonVoiceView.IsRecording);
        this.speakerSprite.SetActive(this.photonVoiceView.IsSpeaking);
        }
    }
    [PunRPC]
    public void DetectVoice(bool speak,bool record)
    {
        this.recorderSprite.SetActive(record);
        this.speakerSprite.SetActive(speak);
    }
}
