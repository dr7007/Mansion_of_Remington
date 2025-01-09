using UnityEngine;

public class CtrlTest : MonoBehaviour
{

    private CharacterController charCtrl = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            charCtrl.SimpleMove(Vector3.forward * 10f);
        }
    }
}
