using UnityEngine;

[CreateAssetMenu(menuName = "PluggableSM/Actions/ClearSound")]
public class ClearSoundAction : Action
{
    public override void Act(StateController controller)
    {
        var audio = controller.GetComponent<AudioSource>();
        if (audio && audio.isPlaying)
            audio.Stop();
    }
}