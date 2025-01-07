using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;

public class RoleAdd : MonoBehaviour
{
    public NetworkManager gm;

    void Start()
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            Hashtable playerProperties = new Hashtable();
            playerProperties.Add("Role", "Boy");
            PhotonNetwork.LocalPlayer.SetCustomProperties(playerProperties);
        }
        else
        {
            Hashtable playerProperties = new Hashtable();
            playerProperties.Add("Role", "Woman");
            PhotonNetwork.LocalPlayer.SetCustomProperties(playerProperties);
        }

        // gm.InstantiatePlayer();
    }
}
