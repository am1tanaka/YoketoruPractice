using UnityEngine;

public class CharacterMover : MonoBehaviour, IMover
{
    static float MaxSpeed => 4f;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 move)
    {
        rb.velocity = MaxSpeed * move;
    }
}
