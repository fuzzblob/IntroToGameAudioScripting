using UnityEngine;

public class AudioUtils
{
    private static float twelfthRootOfTwo = Mathf.Pow(2f, 1.0f / 12f);
    public static float St2pitch(float st)
    {
        return Mathf.Clamp(Mathf.Pow(twelfthRootOfTwo, st), 0f, 4f);
    }
    public static float Pitch2st(float pitch)
    {
        return Mathf.Log(pitch, twelfthRootOfTwo);
    }

    public static float DecibelToLinear(float dB)
    {
        if (dB > -80)
            return Mathf.Clamp01(Mathf.Pow(10.0f, dB / 20.0f));
        else
            return 0;
    }
    public static float LinearToDecibel(float linear)
    {
        if (linear > 0)
            return Mathf.Clamp(20.0f * Mathf.Log10(linear), -80f, 0f);
        else
            return -80.0f;
    }
}