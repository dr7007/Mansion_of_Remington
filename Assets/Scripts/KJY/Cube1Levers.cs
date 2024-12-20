using UnityEngine;

public class Cube1Levers : MonoBehaviour
{
    public Cube1LeversController leverControl;

    [SerializeField] private float Speed = 0f;

    private void Update()
    {
        Vector2 input = leverControl.GetLeverInput();
        Vector3 move = new Vector3(input.x, 0, input.y);

        transform.Translate(move * Speed * Time.deltaTime, Space.World);

    }
}
