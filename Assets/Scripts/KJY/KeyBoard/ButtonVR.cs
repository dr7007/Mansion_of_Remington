using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class ButtonVR : MonoBehaviour
{

    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    private GameObject presser;
    private AudioSource sound;
    private bool isPressed;

    ////input 관련 변수들
    //[SerializeField] private string TheKey = "A";
    //[SerializeField] private TMP_Text InputTheKey;

    private string[] InputAnswers;


    private void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!isPressed)
        {
            button.transform.localPosition = new Vector3(3.196f, 0.4f, 3.486f);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(3.196f, 0.449f, 3.486f);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void TheKeyAnswer()
    {
        //GameObject Sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //Sphere.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
        //Sphere.transform.localPosition = new Vector3(0, 1, 2);
        //Sphere.AddComponent<Rigidbody>();

        //InputTheKey.text += TheKey;


    }

}
