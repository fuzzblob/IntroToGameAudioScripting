using UnityEngine;

public class AudioRetrigger : MonoBehaviour
{
    public AudioData Sound;

    public float Threshhold = 0.1f;
    public float RandomTiming = 0.0f;

    private float counter = 0;
    private void Update()
    {
        counter += Time.deltaTime;
        if (counter >= Random.Range(Threshhold, Threshhold + RandomTiming))
        {
            counter = 0;
            if (Sound != null)
            {
                Sound.Play(transform);
            }
        }
    }
}
