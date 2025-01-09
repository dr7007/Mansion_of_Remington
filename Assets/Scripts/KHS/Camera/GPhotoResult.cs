using UnityEngine;

public class GPhotoResult : MonoBehaviour
{
    //private Material mat = null;
    private MeshRenderer meshRenderer = null;
    private BoxCollider boxCollider = null;
    private GResponse resTrigger = null;
    private Rigidbody rb = null;

    private void Awake()
    {
        //mat = GetComponent<MeshRenderer>().material;
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        resTrigger = GetComponent<GResponse>();
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        meshRenderer.enabled = false;
        boxCollider.enabled = false;
        rb.useGravity = false;
        resTrigger.OnResponseCallback = CreatePhoto;
    }
    private void CreatePhoto(bool _State)
    {
        Debug.Log(_State);
        if(_State)
        {
            //mat.EnableKeyword("_EMISSION");
            meshRenderer.enabled = true;
            boxCollider.enabled = true;
            rb.useGravity = true;
        }
    }
}
