using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{
    private AudioSource _source;
    private Transform _transform;
    private Transform _parentObject;
    private bool _claimed;

    void Awake()
    {
        _transform = this.transform;
        _source = GetComponent<AudioSource>();
        if(_source == null)
        {
            _source = gameObject.AddComponent<AudioSource>();
        }
    }
    
    void LateUpdate()
    {
        if (_claimed && _source.isPlaying == false)
        {
            Stop();
            return;
        }
        if (_parentObject != null)
        {
            _transform.position = _parentObject.position;
        }
    }

    public void SetSourceProperties(AudioClip clip, float volume, float picth, bool loop, float spacialBlend)
    {
        _source.clip = clip;
        _source.volume = volume;
        _source.pitch = picth;
        _source.loop = loop;
        _source.spatialBlend = spacialBlend;
    }

    public void SetParent(Transform parent)
    {
        _parentObject = parent;
    }
    public void SetPosition(Vector3 position)
    {
        _transform.position = position;
    }
    
    public void Play()
    {
        _claimed = true;
        _source.Play();
    }
    public void Stop()
    {
        _source.Stop();
        Reset();
        AudioPoolManager.Instance.PutController(this);
    }

    private void Reset()
    {
        _parentObject = null;
        _claimed = false;
    }
}
