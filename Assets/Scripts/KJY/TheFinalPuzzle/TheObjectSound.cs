using UnityEngine;

public class TheObjectSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;

    public void PlaySound(int _audioClipNum)
    {
        AudioClip soundClip = audioClips[_audioClipNum];
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(soundClip, 0.8f);
    }

}
