using UnityEngine;

public class AudioOnStart : MonoBehaviour
{
    public AudioData Sound;
    
    void Start()
    {
        if (Sound != null)
        {
            Sound.Play(transform);
        }
    }
}
