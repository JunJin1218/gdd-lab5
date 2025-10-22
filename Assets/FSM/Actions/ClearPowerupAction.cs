using UnityEngine;

[CreateAssetMenu(menuName = "PluggableSM/Actions/ClearPowerup")]
public class ClearPowerupAction : Action
{
    public override void Act(StateController controller)
    {
        EchoStateController e = (EchoStateController)controller;
        e.currentPowerupType = PowerupType.Default;
    }
}