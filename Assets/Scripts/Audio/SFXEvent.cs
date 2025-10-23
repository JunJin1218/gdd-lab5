using UnityEngine;

[CreateAssetMenu(fileName = "SFXEvent", menuName = "Audio/SFXEvent", order = 1)]
public class SFXEvent : ScriptableObject
{
    public SFXClip clip;

    public void Raise()
    {
        if (clip != null)
            SFXUtil.Play(clip);
    }
}


// SFXClip --> a SO just to store an AudioClip reference
// SFXEvent --> a SO to raise/play an SFXClip
// SFXUtil --> static class to play SFXClip

// Something happend --> raise SFXEvent --> SFXEvent calls SFXUtil to play SFXClip
