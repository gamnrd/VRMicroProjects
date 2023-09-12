using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Track : MonoBehaviour
{
    public SongData song;
    public AudioSource src;

    private void Start()
    {
        src = GetComponent<AudioSource>();

        transform.position = Vector3.forward * (song.speed * GameManager.instance.startTime);
        Invoke("StartSong", GameManager.instance.startTime - song.startTime);
        Invoke("SongIsOver", song.song.length + 3.0f);
    }

    private void Update()
    {
        transform.position += Vector3.back * song.speed * Time.deltaTime;
    }

    private void StartSong()
    {
        src.PlayOneShot(song.song);
    }

    private void SongIsOver()
    {
        GameManager.instance.WinGame();
    }

    void OnDrawGizmos()
    {
        for (int i = 0; i < 100; i++)
        {
            float beatLength = 60.0f / (float)song.bpm;
            float beatDist = beatLength * song.speed;
            Gizmos.DrawLine(transform.position + new Vector3(-2, 0, i * beatDist), transform.position + new Vector3(2, 0, i * beatDist));
            //Handles.Label(transform.position + new Vector3(-2, 0, i * beatDist), i.ToString());
        }
    }
}
