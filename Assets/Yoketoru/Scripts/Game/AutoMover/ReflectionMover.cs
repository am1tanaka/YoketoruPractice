using UnityEngine;

/// <summary>
/// 反射移動を制御するクラス。
/// </summary>
public class ReflectionMover : MonoBehaviour, IStartStop
{
    [Tooltip("移動方向"), SerializeField]
    Vector3 firstDirection = Vector3.right;
    [Tooltip("移動速度"), SerializeField]
    float speed = 2;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        float currentSpeed = rb.velocity.magnitude;
        if (Mathf.Approximately(currentSpeed, 0))
        {
            return;
        }

        rb.velocity = speed * rb.velocity.normalized;
    }

    public void OnGameStarted()
    {
        rb.velocity = speed * firstDirection.normalized;
    }

    public void OnGameStopped()
    {
        rb.velocity = Vector3.zero;
    }
}
