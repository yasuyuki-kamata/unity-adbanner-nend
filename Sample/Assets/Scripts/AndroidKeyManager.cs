using UnityEngine;
using System.Collections;

public class AndroidKeyManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (RuntimePlatform.Android == Application.platform && Input.GetKey(KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
