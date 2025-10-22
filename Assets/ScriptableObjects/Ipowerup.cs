using UnityEngine;
public enum PowerupType
{
    Default = -1,
    Dash = 1,
    Void = 2,
    Damage = 99
}
public interface IPowerup
{
    void DestroyPowerup();
    void SpawnPowerup();
    void ApplyPowerup(MonoBehaviour i);

    PowerupType powerupType
    {
        get;
    }

    bool hasSpawned
    {
        get;
    }
}


public interface IPowerupApplicable
{
    public void RequestPowerupEffect(IPowerup i);
}

