using Photon.Pun;
using UnityEngine;

public class PlayerInstantiate : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private Vector3 instantiatePos;

    private void SpawnPlayer()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, instantiatePos, Quaternion.identity, 0);
    }

    public override void OnJoinedRoom()
    {
        SpawnPlayer();
    }
}
