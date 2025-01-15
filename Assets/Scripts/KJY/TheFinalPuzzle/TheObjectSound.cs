using UnityEngine;

public class TheObjectSound : MonoBehaviour
{


    [SerializeField] private AudioClip[] audioClips;


    private void Update()
    {
        
    }


    public void SkullSound()
    {
        AudioClip Skull = audioClips[0];
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(Skull, 0.8f);
    }
    public void PaletteSound()
    {
        AudioClip Palette = audioClips[1];
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(Palette, 0.8f);
    }
    public void KnifeSound()
    {
        AudioClip Knife = audioClips[2];
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(Knife, 0.8f);
    }
    public void FlyerSound()
    {
        AudioClip Flyer = audioClips[3];
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(Flyer, 0.8f);
    }


}
