
using UnityEngine;
using System;
[CreateAssetMenu(menuName = "PluggableSM/Decisions/Transform")]
public class TransformDecision : Decision
{
    public StateTransformMap[] map;

    public override bool Decide(StateController controller)
    {
        EchoStateController m = (EchoStateController)controller;
        // we assume that the state is named (string matched) after one of possible values in EchoState
        // convert between current state name into EchoState enum value using custom class EnumExtension
        // you are free to modify this to your own use
        EchoState toCompareState = EnumExtension.ParseEnum<EchoState>(m.currentState.name);

        // loop through state transform and see if it matches the current transformation we are looking for
        for (int i = 0; i < map.Length; i++)
        {
            if (toCompareState == map[i].fromState && m.currentPowerupType == map[i].powerupCollected)
            {
                return true;
            }
        }

        return false;

    }
}

[System.Serializable]
public struct StateTransformMap
{
    public EchoState fromState;
    public PowerupType powerupCollected;
}
