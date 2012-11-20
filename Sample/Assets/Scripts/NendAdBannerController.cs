using UnityEngine;
using System.Collections;

public class NendAdBannerController : MonoBehaviour {

	public int spotID = 0;
	public string apiKey = "";
	public float rotationTime = 30.0f;
	
	void Start () {
		AdBannerObserver.Initialize(spotID, apiKey, rotationTime);
	}
	
}
