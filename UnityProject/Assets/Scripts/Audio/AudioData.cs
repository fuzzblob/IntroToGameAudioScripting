using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu()]
public class AudioData : ScriptableObject
{
    public List<AudioClip> Sounds = new List<AudioClip>();

    [Range(-80, 0)]
    public float Volume = 0f;
    [Range(-20, 0)]
    public float RandomVolume = 0f;
    [Range(-24, 24)]
    public float Pitch = 0f;
    [Range(0, 12)]
    public float RandomPitch = 0f;
    public bool Loop = false;
    [Range(0f, 1f)]
    public float SpacialBlend = 1f;
    
    public AudioSourceController Play(Transform parent)
    {
        AudioSourceController controller = Play(parent.position);
        controller.SetParent(parent);
        return controller;
    }
    public AudioSourceController Play(Vector3 position)
    {
        AudioSourceController controller = AudioPoolManager.Instance.GetController();
        float volGen = AudioUtils.DecibelToLinear(Volume + Random.Range(RandomVolume, 0) );
        float pitchVar = (RandomPitch / 2);
        float pitchGen = AudioUtils.St2pitch( Random.Range(Pitch - pitchVar, Pitch + pitchVar) );
        controller.SetSourceProperties(GetClip(), volGen, pitchGen, Loop, SpacialBlend);
        controller.SetPosition(position);
        controller.Play();
        return controller;
    }

    private AudioClip GetClip()
    {
        if (Sounds.Count == 0)
        {
            Debug.LogWarning("AudioData does not contain any AudioClips.");
            return null;
        }
        int index = 0;
        if (Sounds.Count > 1)
        {
            index = Random.Range(0, Sounds.Count - 1);
        }
        return Sounds[index];
    }
}