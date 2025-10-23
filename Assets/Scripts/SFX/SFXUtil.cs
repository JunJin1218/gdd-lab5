using UnityEngine;

public static class SFXUtil
{
    public static void Play(SFXClip clip)
    {
        var go = new GameObject("SFX:" + clip.clip.name);
        var src = go.AddComponent<AudioSource>();
        src.clip = clip.clip;
        src.Play();
    }
}
