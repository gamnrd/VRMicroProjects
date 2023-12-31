using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Song Object", menuName = "New Song")]
public class SongData : ScriptableObject
{
    public AudioClip song;
    public int bpm;
    public float startTime;
    public float speed;
}
