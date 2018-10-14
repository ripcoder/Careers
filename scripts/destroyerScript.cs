using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyerScript : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		try
		{
			//Destroy(GameObject.FindObjectOfType<DatabaseRedsultsScript>());
			Destroy(GameObject.Find("JunkObject"));
			Destroy(GameObject.Find("DatabaseScriptholder"));


		}
		catch  {
			Debug.Log("OH?");

		}
	}
	
 
}
