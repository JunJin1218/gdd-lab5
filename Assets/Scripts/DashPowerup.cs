using UnityEngine;
using UnityEngine.Events;

public class DashPowerup : MonoBehaviour
{
    public UnityEvent enableDash;
    private string playerLayerName = "Player";

    [SerializeField]
    private SFXEvent pickupSfxEvent;

    public void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.layer == LayerMask.NameToLayer(playerLayerName))
        {
            enableDash.Invoke();
            OnEnableDash(player.transform);
        }
    }

    public void OnEnableDash(Transform playerTransform)
    {
        pickupSfxEvent.Raise();
        gameObject.SetActive(false);
    }
}
