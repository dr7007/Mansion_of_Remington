using UnityEngine;

public class manneManager : MonoBehaviour
{
    [SerializeField] private AudioClip sfx = null;
    //public GameObject one;

    private GameObject go;

    [SerializeField] private Mane[] manes = null;

    private void Start()
    {
        manes[0].turnCallback += checkDegreeCallback;
        manes[1].turnCallback += checkDegreeCallback;
        manes[2].turnCallback += checkDegreeCallback;
        manes[3].turnCallback += checkDegreeCallback;
    }


    public void checkDegreeCallback()
    {
        bool isSuccess = true;
        foreach (Mane mane in manes)
        {
            if (!mane.IsSuccess())
            {
                isSuccess = false;
                break;
            }
        }

        Debug.Log(isSuccess);
    }

    private void playSfx()
    {
        go = new GameObject("SFX");
        AudioSource audio = go.AddComponent<AudioSource>();
        audio.PlayOneShot(sfx);
        Invoke("Destroy", 1f);
    }

    private void Destroy()
    {
        Destroy(go);
    }
}
