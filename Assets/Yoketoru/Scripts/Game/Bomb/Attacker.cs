using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 接触相手がプレイヤーなら、ゲームオーバーを要求して、自分を爆破する。
/// </summary>
public class Attacker : MonoBehaviour, IGameOverEmitter, IStartStop
{
    [SerializeField]
    Explosion explosionPrefab = default(Explosion);

    public UnityEvent GameOverRequest { get; } = new();

    bool isStarted = false;

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
        if (isStarted == false) { return; }

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        GameOverRequest.Invoke();
        Destroy(gameObject);
    }
}
