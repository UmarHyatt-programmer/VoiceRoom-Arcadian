
using UnityEngine;
using UnityEngine.UI;
using Photon.Voice.PUN;

public class VoiceDetector : MonoBehaviour
{
    //public Canvas canvas;

    public PhotonVoiceView photonVoiceView;

    [SerializeField]
    private GameObject recorderSprite;

    [SerializeField]
    private GameObject speakerSprite;

    [SerializeField]
   // private Text bufferLagText;

    public bool showSpeakerLag;

    // private void OnEnable()
    // {
    //     ChangePOV.CameraChanged += this.ChangePOV_CameraChanged;
    //     VoiceDemoUI.DebugToggled += this.VoiceDemoUI_DebugToggled;
    // }

    // private void OnDisable()
    // {
    //     ChangePOV.CameraChanged -= this.ChangePOV_CameraChanged;
    //     VoiceDemoUI.DebugToggled -= this.VoiceDemoUI_DebugToggled;
    // }

    // private void VoiceDemoUI_DebugToggled(bool debugMode)
    // {
    //     this.showSpeakerLag = debugMode;
    // }

    // private void ChangePOV_CameraChanged(Camera camera)
    // {
    //     this.canvas.worldCamera = camera;
    // }

    // private void Awake()
    // {
    //     this.canvas = this.GetComponent<Canvas>();
    //     if (this.canvas != null && this.canvas.worldCamera == null) { this.canvas.worldCamera = Camera.main; }
    //     this.photonVoiceView = this.GetComponentInParent<PhotonVoiceView>();
    // }


    // // Update is called once per frame
    private void Update()
    {
        this.recorderSprite.SetActive(this.photonVoiceView.IsRecording);
        this.speakerSprite.SetActive(this.photonVoiceView.IsSpeaking);
        // this.bufferLagText.enabled = this.showSpeakerLag && this.photonVoiceView.IsSpeaking;
        // if (this.bufferLagText.enabled)
        // {
        //     this.bufferLagText.text = string.Format("{0}", this.photonVoiceView.SpeakerInUse.Lag);
        // }
    }

    // private void LateUpdate()
    // {
    //     if (this.canvas == null || this.canvas.worldCamera == null) { return; } // should not happen, throw error
    //     this.transform.rotation = Quaternion.Euler(0f, this.canvas.worldCamera.transform.eulerAngles.y, 0f); //canvas.worldCamera.transform.rotation;
    // }
}
