using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public class Questions : MonoBehaviour {

	 GameObject but1;
	GameObject but2;
	int posB1;
	int posB2;
	int counter;
	int Q1;
	int Q2;
	static int times;
	int[] choices = new int[2];
	Text TempText ;
	public int numberoQs;
	public GameObject calculateButton;
	List<int> zeroto7;
	//all the intelligences
	List<int> zeroto3;
	//round 1 winners
	List<int> zeroto1;
	//round 2 winners
	//These will filled at start & popped out as used

	 
	///  




	public void Awake()
	{

		 zeroto7 = new List<int>();
	 
		int zcount = 0;
		while (zcount <= 7) { zeroto7.Add(zcount); zcount++; }
	 

		// TempText = GameObject.Find("TempText").GetComponent<Text>();
	}

	public void Start()
	{
		
		StartCoroutine(WFI());

		times = 0;

 
	}

	public void Q(int buttonNumber)
	{

		times++;
		Debug.Log("times" + times);
		int notchoics = 1 - buttonNumber;// if 0 then 1 if 1 then 0;
										 ///buttons are zero or 1
										 ///
		int notc = choices[notchoics];
		int isc = choices[buttonNumber];
		Debug.Log("Notc=" + notc);
		if (!DatabaseRedsultsScript.winnersvLoser.ContainsKey( isc))
		{
			

			DatabaseRedsultsScript.winnersvLoser.Add(isc, new HashSet<int> { notc  }); //
		}
		else
		{
			Debug.Log("key there already!!");
			//if already theere it wil throw an exception
			try { DatabaseRedsultsScript.winnersvLoser[isc].Add(notc); } catch { Debug.Log("val there already!!"); }
			
		}
			Debug.Log("DatabaseRedsultsScriptcount" + DatabaseRedsultsScript.winnersvLoser.Count);

			//SceneManager.LoadScene("Calculate");

		



		GameObject.Find("Button1").GetComponentInChildren<Text>().text = "";
		 

			GameObject.Find("Button2").GetComponentInChildren<Text>().text ="";

		StartCoroutine(WFI());
	 

	 
	}
 


	IEnumerator WFI() {
		yield return new WaitForSeconds(0.5f);

		/////////////

		//pick UnityEngine.Random from round 1

		//addTextToTempText();

		Q1 = UnityEngine.Random.Range(0, zeroto7.Count);


		//in case we have removed all the questions from qlList[Q1] pick again
		while (DatabaseRedsultsScript.qlList[Q1].Count <=0)
		{
			Q1 = UnityEngine.Random.Range(0, zeroto7.Count);

			
		}
			int Q1_1 = UnityEngine.Random.Range(0, DatabaseRedsultsScript.qlList[Q1].Count);
		string Q1s = DatabaseRedsultsScript.qlList[Q1][Q1_1];

			DatabaseRedsultsScript.qlList[Q1].Remove(Q1s);
		
		 Q2 = UnityEngine.Random.Range(0, zeroto7.Count);


		//dont want it equal question 1 or if  qlList[Q2] is out of questions pick again
		while (Q2 == Q1 || DatabaseRedsultsScript.qlList[Q2].Count <= 0) { Q2 = UnityEngine.Random.Range(0, zeroto7.Count); }
		 
		int Q1_2 = UnityEngine.Random.Range(0, DatabaseRedsultsScript.qlList[Q2].Count);
		string Q2s = DatabaseRedsultsScript.qlList[Q2][Q1_2];

		DatabaseRedsultsScript.qlList[Q2].Remove(Q2s);

		GameObject.Find("Button1").GetComponentInChildren<Text>().text = Q1+ ":"+ Q1s;
		choices[0] = Q1;
		yield return new WaitForSeconds(0.5f);
		GameObject.Find("Button2").GetComponentInChildren<Text>().text = Q2 + ":" + Q2s;
		choices[1] = Q2;

		 if (times >= numberoQs) { calculateButton.SetActive(true); }
	}



	void addTextToTempText()
	{

		/*
		foreach (KeyValuePair<int, HashSet<int>> dic in DatabaseRedsultsScript.winnersvLoser)
		{
			TempText.text += "Winner k:" + dic.Key;
			foreach (int u in dic.Value) {

				TempText.text += "-" + u;
			}
			TempText.text += "\n";
		}
		*/
		
	}


	public void checkwhoisahead()
	{


		// DatabaseRedsultsScript.winnersvLoser.OrderBy(pair => pair.Value.Count);


		//DatabaseRedsultsScript.winnersvLoser.OrderBy(pair => pair.Key);


		DatabaseRedsultsScript.myIntelligences.RemoveRange(0, DatabaseRedsultsScript.myIntelligences.Count);


		foreach (KeyValuePair<int, HashSet<int>> pair in DatabaseRedsultsScript.winnersvLoser.OrderBy(pair => pair.Value.Count))
		{

			Debug.Log("top =" + pair.Key + "_" + pair.Value.Count );
			DatabaseRedsultsScript.myIntelligences.Add(pair.Key);



		}

		DatabaseRedsultsScript.myIntelligences.Reverse();
		foreach (int mt in DatabaseRedsultsScript.myIntelligences) { Debug.Log(mt); }

		if (DatabaseRedsultsScript.myIntelligences.Count >= 3)
		{
			SceneManager.LoadScene("Calculate");
		}


	}

	//  var orderByVal=l.OrderBy(kvp => kvp.Value);
/*
	Dictionary<int, int> Ssortarray() {
		Dictionary < int, int> sd = new Dictionary<int, int>();
		Dictionary<int, HashSet<int>> tempsd = DatabaseRedsultsScript.winnersvLoser;

		while (tempsd.Count >=2) {


	
				int mylen = kvp.Value.Count();
				int mytempkey = kvp.Key;
				List<int> tempMatches = new List<int>(); 
				tempsd.Remove(mytempkey);
				//remove this and comapre to others

				foreach (KeyValuePair<int, HashSet<int>> kvpOthers in tempsd)
				  {
					if (kvpOthers.Value.Count >= mylen) {
					 if(kvpOthers.Value.Count == mylen) { tempMatches.Add(); }
					}
					
					 

				}


			}

		}



			return sd;

	}

*/
 
}
