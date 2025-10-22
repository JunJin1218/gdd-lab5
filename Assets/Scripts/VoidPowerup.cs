using UnityEngine;
using UnityEngine.Events;

public class VoidPowerup : MonoBehaviour
{
    public UnityEvent enableVoid;
    private string playerLayerName = "Player";

    public void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.layer == LayerMask.NameToLayer(playerLayerName))
        {
            enableVoid.Invoke();
            OnEnableVoid();
        }
    }

    public void OnEnableVoid()
    {
        // TODO: Add SFX
        gameObject.SetActive(false);
    }
}
