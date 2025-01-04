using UnityEngine;
using UnityEngine.Video;

public class TapePlayer : MonoBehaviour
{
    public Tape tape = null;
    public VideoClip[] clips;
    public VideoPlayer videoPlayer;

    private void OnTapesVideoCallback(Tape tape)
    {
        Debug.Log(tape.TapeNum);

        videoPlayer.clip = clips[tape.TapeNum];
        videoPlayer.Play();
       videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnTriggerEnter(Collider _collider)
    {
        tape = _collider.GetComponent<Tape>();
        if (tape != null)
        {
            tape.OnVideoClickCallback = OnTapesVideoCallback;
        }
    }

    private void OnVideoEnd(VideoPlayer vd)
    {
        Destroy(tape.gameObject);
    }

    
}
