using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableSM/Actions/SetupInvincibility")]
public class InvincibleAction : Action
{
    public AudioClip invincibilityStart;
    public override void Act(StateController controller)
    {
        EchoStateController e = (EchoStateController)controller;
        e.gameObject.GetComponent<AudioSource>().PlayOneShot(invincibilityStart);
        e.SetRendererToFlicker();
    }
}
