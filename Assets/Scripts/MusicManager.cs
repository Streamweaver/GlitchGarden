using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] audioClips;

	private AudioSource audioSource;

	void Start () {
		GameObject.DontDestroyOnLoad(gameObject);
		audioSource = GetComponent<AudioSource> ();
		OnLevelWasLoaded (0);
	}

	void OnLevelWasLoaded(int levelID) {
		try {
			AudioClip clip = audioClips [levelID];
			 
			if (clip) {
				audioSource.clip = clip;
				_play();
			}
		} catch (System.IndexOutOfRangeException e) {
			Debug.Log ("No audioclip for " + levelID + e);
		}

	}

	private void _play() {
		audioSource.Stop ();
		audioSource.loop = true;
		audioSource.Play ();
	}
}
