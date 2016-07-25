using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Image))]
public class FadeController : MonoBehaviour {
	public float fadeTime = 3.0f;

	private Color curColor = Color.black;
	private Image img;

	// Use this for initialization
	void Start () {
		img = GetComponent<Image> ();
		img.color = curColor;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < fadeTime) {
			float alphaAdjust = Time.deltaTime / fadeTime;
			curColor.a -= alphaAdjust;
			img.color = curColor;
		} else {
			Debug.Log ("Still running");
			gameObject.SetActive (false);
		}
	}
}
