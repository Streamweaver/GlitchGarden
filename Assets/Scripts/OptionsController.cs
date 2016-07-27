using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	private Slider volumeSlider;
	private Slider difficultySlider;
	private LevelManager levelManager;
	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		// Find components in scene
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		volumeSlider = GameObject.Find ("VolumeSlider").GetComponent<Slider> ();
		difficultySlider = GameObject.Find ("DifficultySlider").GetComponent<Slider> ();
		levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
		// Set values
		volumeSlider.value = PlayerPrefManager.GetMasterVolume ();
		difficultySlider.value = PlayerPrefManager.GetDifficulty ();
	}

	void Update() {
		if (musicManager)
			musicManager.SetVolume (volumeSlider.value);
	}

	public void SetDefaults() {
		volumeSlider.value = 0.8f;
		difficultySlider.value = 2;
	}

	public void SaveAndReturn() {
		// Save prefs and return.
		PlayerPrefManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefManager.SetDifficulty ((int)difficultySlider.value);
		levelManager.LoadLevel (Levels.MAIN);
	}

}
