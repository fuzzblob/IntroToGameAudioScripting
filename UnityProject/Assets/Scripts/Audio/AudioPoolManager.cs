using System.Collections.Generic;
using UnityEngine;

public class AudioPoolManager
{
    private static AudioPoolManager _instance;
    public static AudioPoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new AudioPoolManager();
            }
            return _instance;
        }
    }

    private List<AudioSourceController> _pool = new List<AudioSourceController>();

    public AudioSourceController GetController()
    {
        AudioSourceController output = null;
        if (_pool.Count > 0)
        {
            output = _pool[0];
            _pool.Remove(output);
            return output;
        }
        else
        {
            GameObject go = new GameObject("AudioController");
            output = go.AddComponent<AudioSourceController>();
            return output;
        }
    }

    public void PutController(AudioSourceController controller)
    {
        if (_pool.Contains(controller) == false)
            _pool.Add(controller);
    }
}
