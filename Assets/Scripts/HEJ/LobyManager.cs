using UnityEngine;

public class LobyManager : MonoBehaviour
{
    [SerializeField] private GameObject CreatePopup;
    [SerializeField] private GameObject FindPopup;
    private void Start()
    {
        
    }
    public void OpenCreatePopUP()
    {
        CreatePopup.SetActive(true);
        FindPopup.SetActive(false);

    }

    public void FindPopUP()
    {
        CreatePopup.SetActive(false);
        FindPopup.SetActive(true);
    }
}
