using UnityEngine;
using System.Collections;

public class PlayerPrefManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_PREFIX = "level_";

	public static void SetMasterVolume(float volume) {
		volume = Mathf.Clamp01 (volume);
		PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
	}

	public static float GetMasterVolume() {
		if (!PlayerPrefs.HasKey (MASTER_VOLUME_KEY))
			SetMasterVolume (1f);
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	public static void SetDifficulty(int difficulty) {
		difficulty = Mathf.Clamp (difficulty, 1, 3);
		PlayerPrefs.SetInt (DIFFICULTY_KEY, difficulty);
	}

	public static int GetDifficulty() {
		if (!PlayerPrefs.HasKey (DIFFICULTY_KEY))
			SetDifficulty (2);
		return PlayerPrefs.GetInt (DIFFICULTY_KEY);
	}

	private static string _levelString(int level) {
		string lvlString = level.ToString ();
		if (lvlString.Length < 2)
			lvlString = "0" + lvlString;
		return LEVEL_PREFIX + lvlString;
	}

	// Level Unlocks
	public static void UnlockLevel(int level) {
		// TODO set this so can't be unlocked if previous level locked
		PlayerPrefs.SetInt (_levelString (level), 1);
	}

	public static bool IsLevelUnlocked(int level) {
		return (PlayerPrefs.GetInt (_levelString (level)) == 1);
	}
}
