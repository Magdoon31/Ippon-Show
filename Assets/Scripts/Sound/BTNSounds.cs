using UnityEngine;

public class Sounds:MonoBehaviour
{
    public void PlaySound(string SFX)
    {
        SoundManager.Instance.PlaySound2D(SFX);
    }
}
