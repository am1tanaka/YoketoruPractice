using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// コインを拾う機能を提供
/// </summary>
public class Coin : MonoBehaviour, IGetCoinEmitter, IStartStop
{
    [Tooltip("得点"), SerializeField]
    int point = 100;

    bool isStarted = false;

    public UnityEvent<int> CoinGot { get; } = new();

    public void OnGameStarted()
    {
        isStarted = true;
    }

    public void OnGameStopped()
    {
        isStarted = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) { return; }
        if (!isStarted) { return; }

        CoinGot.Invoke(point);
        Destroy(gameObject);
    }
}
