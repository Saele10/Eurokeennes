using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicPlaylist : MonoBehaviour
{
    public List<AudioClip> backgroundTracks; // Ta liste de musiques
    public AudioSource audioSource;          // L'AudioSource attachée à ton GameObject

    private int currentTrackIndex = 0;

    void Start()
    {
        if (backgroundTracks.Count > 0 && audioSource != null)
        {
            ShufflePlaylist(); // Mélanger la playlist
            StartCoroutine(PlayPlaylist());
        }
        else
        {
            Debug.LogWarning("Pas de musiques ou pas d'AudioSource assignée !");
        }
    }

    // Mélange la liste de musiques
    void ShufflePlaylist()
    {
        for (int i = 0; i < backgroundTracks.Count; i++)
        {
            int randomIndex = Random.Range(i, backgroundTracks.Count);
            AudioClip temp = backgroundTracks[i];
            backgroundTracks[i] = backgroundTracks[randomIndex];
            backgroundTracks[randomIndex] = temp;
        }
    }

    IEnumerator PlayPlaylist()
    {
        while (true)
        {
            audioSource.clip = backgroundTracks[currentTrackIndex];
            audioSource.Play();

            // Attendre que la musique se termine
            yield return new WaitForSeconds(audioSource.clip.length);

            // Passer à la musique suivante
            currentTrackIndex = (currentTrackIndex + 1) % backgroundTracks.Count;
        }
    }
}
