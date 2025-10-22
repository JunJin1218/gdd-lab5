using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public LayerMask enemyMask;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & enemyMask) != 0)
        {
            DamageEcho();
        }
    }

    public void DamageEcho()
    {
        // GameOverAnimationStart(); // last time Echo dies right away

        // pass this to StateController to see if Echo should start game over
        // since both state StateController and EchoStateController are on the same gameobject, it's ok to cross-refer between scripts
        GetComponent<EchoStateController>().SetPowerup(PowerupType.Damage);

    }
}
