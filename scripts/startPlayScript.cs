using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using  System.IO;
using UnityEngine.UI;


public class startPlayScript : MonoBehaviour {


	public List<string> pth = new List<string>();
	string pathString;
	//public string pathtoVideos;
	VideoPlayer vidP;
	// Use this for initialization
	void Start () {
		vidP = GetComponent<VideoPlayer>();

		string jtfile = DatabaseRedsultsScript.SelectedJob;
		 
		jtfile=jtfile.ToLower().Replace(' ', '_');
		jtfile =jtfile +  ".mp4";
		pathString = Application.dataPath +"/Resources/Videos/"  + jtfile; //"account_manager.mp4"; // "account_manager.mp4";
		vidP.url = pathString;


	Text t=	GameObject.Find("SelectedJobText").GetComponent<Text>()  ;
		t.text = jtfile;// DatabaseRedsultsScript.SelectedJob;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)  ){
			Debug.Log("butdown");

			//Application.runInBackground = true;
			 
			 StartCoroutine(Playitagiansam());


	//	 10 - 1 -- 11
		//else { vidP.Stop(); } 
		}
	}


	IEnumerator Playitagiansam() {
	
vidP.Play();
		//
		 yield return new WaitForSeconds(3f);

		//yield return null;
	}


 
}
