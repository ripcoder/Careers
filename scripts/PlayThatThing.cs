using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayThatThing : MonoBehaviour {

	 VideoPlayer vp;

	private void Start()
	{
		vp = GetComponentInChildren<VideoPlayer>();
	}

	// Update is called once per frame
	public void Playthatthing () {
		vp.Play();
	}
}
