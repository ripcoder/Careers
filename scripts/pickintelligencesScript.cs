using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public  class pickintelligencesScript :MonoBehaviour  {


	/*
	 * 
	 * This script just adds selected intelligences to DatabaseRedsultsScript.All8Intelligences and aftetr three are selected goes to the  
	 * Calculate scene
	 * on canvas has array of buttons to be turned off
	 * addSmarts(int buttonNumber) called from each button
	 *  NotSure() loads Questiosn scene
	 * */


	private static bool created = false;
 

	/// <summary>
	/// Buttons top turn off
	/// </summary>
	public  Button[] BUTS = new Button[8];
 
	public static int counter =0;

//after  3 goes to next scene
	public  int b_counter = 0;
 	///  adds intelligence to text smText
	public Text smText;
	//activitates  iam text that say i am...
	public  GameObject iam;




	// Use this for initialization
	public  void  addSmarts(int buttonNumber) {

		//Debug.Log("buttonNumber" + buttonNumber);

		///	Debug.Log(DatabaseRedsultsScript.All8Intelligences[1] + "\n");
		 

		DatabaseRedsultsScript.fillmyIntelligences(buttonNumber);
		iam.SetActive(true);
		if (b_counter <= 2)
		{
	 
			b_counter++;
			Button myButton = BUTS[buttonNumber].GetComponent<Button>();
			myButton.interactable = false;
			smText.text += DatabaseRedsultsScript.All8Intelligences[buttonNumber  ] + "\n";
			if (b_counter == 3) {
				SceneManager.LoadScene("Calculate");
			}
		}
	}


	public void NotSure() {

		SceneManager.LoadScene("Questions");
	} 
}


