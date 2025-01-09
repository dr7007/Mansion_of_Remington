using System.Collections;
using UnityEngine;

public class PlayerSpwan : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    void Start()
    {
        StartCoroutine(SpwanPlayer());
    }

    private IEnumerator SpwanPlayer()
    {
        Instantiate(Player1, new Vector3(0, 1, 0), Quaternion.identity);

        yield return new WaitForSeconds(3f);

        Instantiate(Player2, new Vector3(3, 1, 3), Quaternion.identity);
    }
}
