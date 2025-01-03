using UnityEngine;

public class manneManager : MonoBehaviour
{
    [SerializeField] private AudioClip sfx = null;
    //public GameObject one;

    private GameObject go;

    [SerializeField] private Mane[] manes = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "mane")
                {
                    Mane mane = hit.transform.GetComponent<Mane>();
                    //playSfx();
                    mane.Rotate90();
                    mane.TurnCallback = checkDegreeCallback;

                }
            }
        }

    }

    public void checkDegreeCallback(Mane _mane)
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
