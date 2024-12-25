using Photon.Pun;
using UnityEngine;

public class PlayerInstantiate : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject playerPrefab;

    private void SpawnPlayer()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity, 0);
    }

    public override void OnJoinedRoom()
    {
        SpawnPlayer();
    }
}
