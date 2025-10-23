using UnityEngine;

public static class SFXUtil
{
    // lazily-created AudioSource used for one-shot playback to avoid Unity's temporary "One shot audio" GameObjects
    private static AudioSource sfxSource;

    public static void Play(SFXClip clip)
    {
        if (clip == null || clip.clip == null)
        {
            return;
        }

        EnsureSourceExists();
        sfxSource.PlayOneShot(clip.clip);
    }

    private static void EnsureSourceExists()
    {
        if (sfxSource != null)
        {
            return;
        }

        // Try to attach to the main camera first
        GameObject go = null;
        if (Camera.main != null)
        {
            go = Camera.main.gameObject;
        }

        // Fallback: attach to AudioListener if present
        if (go == null)
        {
            var listener = Object.FindObjectOfType<AudioListener>();
            if (listener != null)
            {
                go = listener.gameObject;
            }
        }

        // Final fallback: create a persistent SFXPlayer root object
        if (go == null)
        {
            go = new GameObject("SFXPlayer");
            Object.DontDestroyOnLoad(go);
        }

        sfxSource = go.GetComponent<AudioSource>();
        if (sfxSource == null)
        {
            sfxSource = go.AddComponent<AudioSource>();
            sfxSource.playOnAwake = false;
            sfxSource.spatialBlend = 0f; // make sounds non-3D by default
        }
    }
}
