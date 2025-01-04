//using Photon.Voice.Unity;
using UnityEngine;
using Photon.Pun;

public class StopVoice : MonoBehaviourPunCallbacks
{
   // private Recorder recorder;
    private bool recorderOn = true;

    private void Start()
    {
        //recorder = FindFirstObjectByType<Recorder>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            ChangeVoiceState();
        }
    }

    // 格家府 on/off 炼沥
    private void ChangeVoiceState()
    {
        if (recorderOn)
        {
           // recorder.RecordingEnabled = false;
            recorderOn = false;

            Debug.Log("格家府 On");
        }
        else
        {
            //recorder.RecordingEnabled = true;
            recorderOn = true;

            Debug.Log("格家府 Off");
        }

        photonView.RPC("ChangeVoiceStateRPC", RpcTarget.Others);
    }

    [PunRPC]
    private void ChangeVoiceStateRPC()
    {
        if (recorderOn)
        {
           // recorder.RecordingEnabled = false;
            recorderOn = false;

            Debug.Log("格家府 Off");
        }
        else
        {
            //recorder.RecordingEnabled = true;
            recorderOn = true;

            Debug.Log("格家府 On");
        }
    }
}
