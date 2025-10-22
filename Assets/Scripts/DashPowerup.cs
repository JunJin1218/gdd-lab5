using UnityEngine;
using UnityEngine.Events;

public class DashPowerup : MonoBehaviour
{
    public UnityEvent enableDash;
    private string playerLayerName = "Player";

    public void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.layer == LayerMask.NameToLayer(playerLayerName))
        {
            enableDash.Invoke();
            OnEnableDash();
        }
    }

    public void OnEnableDash()
    {
        // TODO: Add SFX
        gameObject.SetActive(false);
    }
}
