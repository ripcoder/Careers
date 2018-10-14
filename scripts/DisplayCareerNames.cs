using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class DisplayCareerNames : MonoBehaviour {

	/*
	 This class fakes calculating to add suspense then displays a random selection from  CareersNamesthatmatch_0.. and or CareersNamesthatmatch_1, & CareersNamesthatmatch_02
		 
		 
		 */

	List<string> allCareersNames;

	/// <summary>
	/// used to hold all that match intelligences
	/// </summary>
	List<string> CareersNamesthatmatch_0;
	List<string>  CareersNamesthatmatch_1;
	List<string>  CareersNamesthatmatch_2;
 
 

	/// <summary>
	/// used to hold all that match intelligences in pos 0 , 1 , 2
	/// </summary>

	public Text tempT;
	public Text tm;
	 int counter;
	public GameObject calText;
	public GameObject moreBut;
	public GameObject calBut;
	public GameObject StartAgainBut;

	private void Awake()
	{ 
	
	}

	// Use this for initialization
	void Start () {

		//what is myIntelligences length. if 1 myNumber1int =   myIntelligences[0];

		Debug.Log("myIntelligenceslength" + DatabaseRedsultsScript.myIntelligences.Count);
		///to remove
		///

		DatabaseRedsultsScript.myIntelligences.Add(5);
		DatabaseRedsultsScript.myIntelligences.Add(4);
		DatabaseRedsultsScript.myIntelligences.Add(6);

		///end to remove

		int myNumber1int = DatabaseRedsultsScript.myIntelligences[0];
		int myNumber2int = DatabaseRedsultsScript.myIntelligences[1];
		int myNumber3int = DatabaseRedsultsScript.myIntelligences[2];
		counter = 0;
		allCareersNames = new List<string>() ;


		CareersNamesthatmatch_0 = new List<string>();
		CareersNamesthatmatch_1 = new List<string>();
		CareersNamesthatmatch_2 = new List<string>();
	 

		foreach (Dictionary<string, int[]> element in DatabaseRedsultsScript.JobTitleList.Values)
		{
			foreach (string ss in element.Keys)
			{
				//Debug.Log(counter + "  -- " + ss);
				allCareersNames.Add(ss);


				//my strongest intelligence matches top intelligent 
				if (myNumber1int == element[ss][0]   )
				{

					CareersNamesthatmatch_0.Add(ss);
					Debug.Log("In 0");
				}

				//my strongest intelligence matches 2nd or 2nd matches top
				else if (myNumber1int == element[ss][1] || myNumber2int == element[ss][0])
				{

					CareersNamesthatmatch_1.Add(ss);
					Debug.Log("In 1");
				}

				//my strongest intelligence matches 3rd or 3rd matches top
				else if (myNumber1int == element[ss][2] || myNumber3int == element[ss][0])
				{

					CareersNamesthatmatch_2.Add(ss);
					Debug.Log("In 2");
				}
			  
 
				 
			}


			counter += 1;
		}




		///scroll though all the careers to appear to be processing
		//StartCoroutine(waitforit());


		fkecalc();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	IEnumerator waitforit()
	{
		

		Debug.Log(CareersNamesthatmatch_0.Count + "_" + CareersNamesthatmatch_1.Count + "_" + CareersNamesthatmatch_2.Count);

		counter = 0;

		while (counter<30) {
			int myMod = counter % allCareersNames.Count;
yield return new WaitForSeconds(0.1f);
			
			 
			 tm.text = allCareersNames[myMod] + "\n" + tm.text;
			counter++;
}


			if (calText.activeSelf) { calText.SetActive(false); } else { calText.SetActive(true); }

			counter++;
		

		calText.SetActive(false);
		//// 

	
		 
		tm.text = DatabaseRedsultsScript.SelectedJob; ;
		int matchesleft = CareersNamesthatmatch_0.Count + CareersNamesthatmatch_1.Count + CareersNamesthatmatch_2.Count;

		if (matchesleft >= 1)
		{
			calBut.SetActive(true);
			calBut.GetComponentInChildren<Text>().text = "Try Again?" + matchesleft;

		}
		else { calBut.SetActive(false);
			StartAgainBut.SetActive(true);

		}

		moreBut.SetActive(true); 
	}



	public void fkecalc() {
 
		counter = 1;
		 moreBut.SetActive(false);
		//string Q1 = DatabaseRedsultsScript.qlList[0][0];
		//DatabaseRedsultsScript.qlList[0].Remove("");
		///???
		pickstring();
		StartCoroutine(waitforit());
		 
	}

	void pickstring() {
	 

		if (CareersNamesthatmatch_0.Count >= 1)
		{

			Debug.Log("CareersNamesthatmatch_0.Count" + CareersNamesthatmatch_0.Count);
			int bbb = (int)Random.Range(0, CareersNamesthatmatch_0.Count);
 DatabaseRedsultsScript.SelectedJob = CareersNamesthatmatch_0[bbb];
			CareersNamesthatmatch_0.RemoveAt(bbb);


		}
		else if (CareersNamesthatmatch_1.Count >= 1)
		{
Debug.Log("CareersNamesthatmatch_1.Count" + CareersNamesthatmatch_1.Count);
			int bbb = (int)Random.Range(0, CareersNamesthatmatch_1.Count);
			DatabaseRedsultsScript.SelectedJob = CareersNamesthatmatch_1[bbb];
			CareersNamesthatmatch_1.RemoveAt(bbb);
			
		}

		else if (CareersNamesthatmatch_2.Count >= 1)
		{
			Debug.Log("CareersNamesthatmatch_2.Count" + CareersNamesthatmatch_2.Count);

			int bbb = (int)Random.Range(0, CareersNamesthatmatch_2.Count);
			DatabaseRedsultsScript.SelectedJob = CareersNamesthatmatch_2[bbb];
			CareersNamesthatmatch_2.RemoveAt(bbb);


		}


	}

	public void LearnMore() {
		DatabaseRedsultsScript.showmyIntelligences(0);
			//showmyIntelligences
		 SceneManager.LoadScene("learnmore");

	}
	public void startAgain()
	{
		DatabaseRedsultsScript.showmyIntelligences(0);
		//showmyIntelligences
		SceneManager.LoadScene("YouCanBeAnyThingOpeningScreen");

	}

	
}
