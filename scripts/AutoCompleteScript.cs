using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



public class AutoCompleteScript : MonoBehaviour {

	public InputField inputField;
	public RectTransform resultsParent;
	public RectTransform prefab;
	public Dropdown dd;
	TextInfo textInfo;


	private void Awake()
	{
		inputField.onValueChanged.AddListener(OnInputValueChanged);
		 textInfo = new CultureInfo("en-US", false).TextInfo;
	}


	private void OnInputValueChanged(string newText)
	{
		dd.gameObject.SetActive(true);
		 
		ClearResults();
		 
		newText = textInfo.ToLower(newText);
	 FillResults(GetResults(newText));
	}

	private void ClearResults()
	{

		dd.ClearOptions();
	 
		 
	}

	public void ClearMyText()
	{
 


	}

	private void FillResults(List<string> results)
	{
		Debug.Log("here" + results.Count.ToString());
		 
		for (int resultIndex = 0; resultIndex < results.Count; resultIndex++)
		{


			///make all data lowercase to search and Title case to display
			string s = textInfo.ToTitleCase(results[resultIndex]).TrimEnd();
			Debug.Log(s);
			results[resultIndex] = s;
	
		}
		results.Insert(0, "");
 dd.AddOptions(results);
		dd.Show();
	}


	private List<string> GetResults(string input)
	{

		///make all data lowercase to search and Title case to display
		///

		List<string> mockData = new List<string>();


		foreach (KeyValuePair<int, Dictionary<string, int[]>> kp in DatabaseRedsultsScript.JobTitleList)
		{
			foreach (KeyValuePair<string, int[]> si in kp.Value) {
				mockData.Add( si.Key.ToLower() );
			}
		}
		return mockData.FindAll((str) => str.IndexOf(input) >= 0);
	}


	public void Update()
	{
		// dd.gameObject.SetActive(IsUIElementActive());
	}
	public static bool IsUIElementActive()
	{
		if (EventSystem.current.currentSelectedGameObject != null)
		{
			 InputField IF = EventSystem.current.currentSelectedGameObject.GetComponent<InputField>();
			Dropdown cdd = EventSystem.current.currentSelectedGameObject.GetComponent<Dropdown>();
			if (IF != null || cdd != null)
			{
				return true;
			}
		}
		return false;
	}

	public void Showme(GameObject calledObj) {

		Debug.Log(calledObj.ToString());
		gameObject.SetActive(true);
		calledObj.SetActive(false);
	}

	public void clearsearch() {


	}

	public void godirectlytolearn() {
		int sj = dd.value;
		 

		DatabaseRedsultsScript.SelectedJob = dd.options[sj].text;
	 

		SceneManager.LoadScene("learnmore");

	}



	// Update is called once per frame
	public void nextScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}


}
