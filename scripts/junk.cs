using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class junk : MonoBehaviour
{

	public Dictionary<int, HashSet<int>> winnersvLoser;
	// winning intellegence categories and array of categories they have beaten

	public List<int> orderedIntelligencesS;

	public string SelectedJobS;

	public Dictionary<int, List<string>> qlListS;

	public Dictionary<int, Dictionary<string, int[]>> JobTitleListS;



	public string[] All8IntelligencesS;

	public List<int> myIntelligencesS;

	private void Update()
	{
			 winnersvLoser = new Dictionary<int, HashSet<int>>();
	// winning intellegence categories and array of categories they have beaten

 orderedIntelligencesS = DatabaseRedsultsScript.orderedIntelligences;

 SelectedJobS = DatabaseRedsultsScript.SelectedJob;

	qlListS = DatabaseRedsultsScript.qlList;

	 JobTitleListS = DatabaseRedsultsScript.JobTitleList;



  All8IntelligencesS = DatabaseRedsultsScript.All8Intelligences;

 myIntelligencesS = DatabaseRedsultsScript.myIntelligences;
	}



	private void Awake()
	{
		DontDestroyOnLoad(gameObject);

	}


}
 

