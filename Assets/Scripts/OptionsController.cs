using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;
	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
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
		levelManager.LoadLevel ("01_MainMenu");
	}

}
