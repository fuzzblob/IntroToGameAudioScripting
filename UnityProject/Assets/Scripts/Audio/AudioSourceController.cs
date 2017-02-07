using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour {

    private AudioSource _source;

    public AudioClip Clip;
    [Range(0,1)]
    public float Volume = 1f;
    [Range(.25f, 3)]
    public float Pitch = 1f;
    public bool Loop = false;
    [Range(0f, 1f)]
    public float SpacialBlend = 1f;

    void Awake()
    {
        _source = GetComponent<AudioSource>();
        if(_source == null)
        {
            _source = gameObject.AddComponent<AudioSource>();
        }
    }
    
	void Start () {
        Play();
	}

    public void SetSourceProperties(AudioClip clip, float volume, float picth, bool loop, float spacialBlend)
    {
        _source.clip = clip;
        _source.volume = volume;
        _source.pitch = picth;
        _source.loop = loop;
        _source.spatialBlend = spacialBlend;
    }

    public void Play()
    {
        SetSourceProperties(Clip, Volume, Pitch, Loop, SpacialBlend);
        _source.Play();
    }
}
