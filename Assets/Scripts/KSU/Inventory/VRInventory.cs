using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.UI;
public class VRInventory : MonoBehaviour
{
    public Transform playerTr;

    private bool alreadyIn = false;
    private bool isHovering = false;
    private XRGrabInteractable grabInteractable;

    private string ItemName;
    private Transform beforeGrapTransform;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        beforeGrapTransform = transform;
    }

    // 이미지를 넣음
    private void OnTriggerStay(Collider other)
    {
        // 이미 슬롯안에 있다면 return
        if (alreadyIn) return;

        // 상호작용 안되는 아이템이면 못넣음. 
        if (other.gameObject.tag != "Interaction") return;

        // 플레이어가 잡고 있는 상태라면 안들어감.
        if (other.gameObject.GetComponent<XRGrabInteractable>().isSelected == true) return;

        // 이미지 바꾸고
        gameObject.GetComponent<Image>().sprite = other.GetComponent<ItemInfo>().ItemImage;
        ItemName = other.GetComponent<ItemInfo>().ItemName;

        // 못들어가는 상태로 만듦.
        alreadyIn = true;

        // 해당 아이템을 destroy
        Destroy(other.gameObject);
    }

    // 아이템 꺼내는 함수
    public void OutInventorySlot()
    {
        if (!alreadyIn) return;

        alreadyIn = false;
        gameObject.GetComponent<Image>().sprite = null;

        // 게임 오브젝트를 만들어 내고
        GameObject prefab = Resources.Load<GameObject>(ItemName);
        GameObject prefabGo = Instantiate(prefab, playerTr.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
    }
}

