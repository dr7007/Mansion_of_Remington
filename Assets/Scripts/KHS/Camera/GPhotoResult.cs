using UnityEngine;

public class GPhotoResult : MonoBehaviour
{
    private Material mat = null;
    private GResponse resTrigger = null;

    private void Awake()
    {
        mat = GetComponent<MeshRenderer>().material;
        resTrigger = GetComponent<GResponse>();
    }
    private void Start()
    {
        resTrigger.OnResponseCallback = CreatePhoto;
    }
    private void CreatePhoto(bool _State)
    {
        if(_State)
        {
            mat.EnableKeyword("_EMISSION");
        }
        else
        {
            mat.DisableKeyword("_EMISSION");
        }
    }
}
