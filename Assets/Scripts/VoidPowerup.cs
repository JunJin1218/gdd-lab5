using UnityEngine;
using UnityEngine.Events;

public class VoidPowerup : MonoBehaviour
{
    public UnityEvent enableVoid;
    private string playerLayerName = "Player";

    [SerializeField]
    private SFXEvent pickupSfxEvent;

    public void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.layer == LayerMask.NameToLayer(playerLayerName))
        {
            enableVoid.Invoke();
            OnEnableVoid(player.transform);
        }
    }

    public void OnEnableVoid(Transform playerTransform)
    {
        pickupSfxEvent.Raise();

        gameObject.SetActive(false);
    }
}
