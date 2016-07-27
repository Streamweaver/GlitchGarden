using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] audioClips;

	private AudioSource audioSource;
	private float volume;

	void Start () {
		GameObject.DontDestroyOnLoad(gameObject);
		audioSource = GetComponent<AudioSource> ();
		OnLevelWasLoaded (0);
		volume = PlayerPrefManager.GetMasterVolume ();
		SetVolume (volume);
	}

	void OnLevelWasLoaded(int levelID) {
		try {
			AudioClip clip = audioClips [levelID];
			 
			if (clip && clip != audioSource.clip) { // let music keep playing if same.
				audioSource.clip = clip;
				_play();
			}
		} catch (System.IndexOutOfRangeException e) {
			Debug.Log ("No audioclip for " + levelID + " "+ e);
		}

	}

	public void SetVolume(float newVolume) {
		volume = Mathf.Clamp01 (newVolume);
		audioSource.volume = volume;
	}

	private void _play() {
		audioSource.Stop ();
		audioSource.loop = true;
		audioSource.Play ();
	}
}
