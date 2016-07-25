using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		SceneManager.LoadScene (name);
	}

	public void LoadNextLevel() {

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public IEnumerator LoadLevelDelay(string name, float delay) {
		yield return new WaitForSeconds (delay);
		SceneManager.LoadScene (name);
	}

}
