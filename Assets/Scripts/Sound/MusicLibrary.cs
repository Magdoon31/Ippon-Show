using UnityEngine;

[System.Serializable]
public struct MusicTrack
{
    public string trackName;
    public AudioClip[] clips;
}

public class MusicLibrary : MonoBehaviour
{
    public MusicTrack[] tracks;

    public AudioClip GetClipFromName(string trackName)
    {
        foreach (var track in tracks)
        {
            if (track.trackName == trackName)
            {
                return track.clips[Random.Range(0, track.clips.Length)];
            }
        }
        return null;
    }
}