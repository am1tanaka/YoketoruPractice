using UnityEngine;

public class KeyInput : IInput
{
    Vector2 move;

    public Vector2 GetValue()
    {
        return move;
    }

    public void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        move = move.normalized;
    }
}
