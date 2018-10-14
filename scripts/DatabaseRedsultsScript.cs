using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DatabaseRedsultsScript : MonoBehaviour {


	/*
	 * IN THE DATABASE:
	 * intelligences has Title and id and holds the following data
0 - Nature Smart
1 - Music Smart
2 - Body Smart
3 - People Smart
4 - Word Smart
5 - Logic Smart
6 - Self Smart
7 - Picture Smart

	 * 
	 * 
	 * careers - id, Job_Title, Intelligence1_id ,Intelligence2_id,  Intelligence3_id
	 * 
	 * rathers - Rather_id Intelligece_id, Rather_Question
	 * videos should be named by careers id 
	 * */



	public static DatabaseRedsultsScript instance = null;

	//First initialise the list itself

	//Fill the list with elements here HashSets all values are unique so i will add losing categories until 1 has beaten all that have not lost to another
	//
	public static Dictionary<int, HashSet<int>> winnersvLoser;
	// winning intellegence categories and array of categories they have beaten

	public static List<int> orderedIntelligences;

	public static String SelectedJob;

	public static Dictionary<int, List<string>> qlList;

	public static Dictionary<int, Dictionary<string, int[]>> JobTitleList;
	/// <summary>
	/// /JobTitleList structure has = id [Dictionary[name, array of 3 int for values for the 3 intelligences]] --j0b_Intelligences
	/// </summary>

	/// <summary>
	/// qlist holds the rather question parts indexed by their intellegence category
	/// we will be removing these as questions are used  
	/// </summary>

	public Text t;

	public static string[] All8Intelligences ;

	public static List<int> myIntelligences  ;

	public void Awake()
	{

		Debug.Log("scene number" + SceneManager.GetActiveScene().buildIndex);
		////if we go back to the first sceme clean it up 
		if (SceneManager.GetActiveScene().buildIndex ==0) {



			Debug.Log("scene number" + SceneManager.GetActiveScene().buildIndex);

			winnersvLoser = new Dictionary<int, HashSet<int>>();
	// winning intellegence categories and array of categories they have beaten

	 qlList = new Dictionary<int, List<string>>();
 JobTitleList = new Dictionary<int, Dictionary<string, int[]>>();
 
  All8Intelligences = new string[8];

	  myIntelligences = new List<int>();


			instance = null;

}
			 

	 

			if (instance == null)
		{

			//if not, set instance to this
			instance = this;
			initDatabase();
		}
		//If instance already exists and it's not this:
		else if (instance != this)
		{

			//Then destroy this. This enforces our singleton pattern, meanAwing there can only ever be one instance of a GameManager.
			Destroy(gameObject);
		}

			//Sets this to not be destroyed when reloading scene
			DontDestroyOnLoad(gameObject);

	//Get a component reference to the attached BoardManager script
 

		//Call the InitGame function to initialize the first level 

}

	void initDatabase()
	{

		List< string>  ql = new List< string >();

		for (int i = 0; i < 8; i++)
		{

			try
			{
				qlList.Add(i, new List<string>());

			}
			catch (Exception e) {
				Debug.Log(e.ToString() + "   " +i);
			}

		}
		string conn = "URI=file:" + Application.dataPath + "/Resources/careers.sqlite";

		////Application.dataPath +  //Path to database.

		//Assets/Resources/mydatabase23.sqlite
		try
		{
			IDbConnection dbconn;
			dbconn = (IDbConnection)new SqliteConnection(conn);
			dbconn.Open(); //Open connection to the database.
	
		////////////////////////////rathers

		IDbCommand dbcmd = dbconn.CreateCommand();
		string sqlQuery = "SELECT * " + "FROM rathers";
		dbcmd.CommandText = sqlQuery;
		IDataReader reader = dbcmd.ExecuteReader();


	//	Text TempText = GameObject.Find("TempText").GetComponent<Text>();
	//	TempText.text = "";
		while (reader.Read())
		{


	 
			int ii =  (int)reader.GetFloat(1); ///intelligence id
			String s = reader.GetString(2);
			qlList[ii].Add(s);
			//TempText.text += ii + "" + s;


			//Debug.Log(s);

		//	showmyqlList(5);///randomer 5
		}


		////////////////////////////////Get all the intelligences
		dbcmd.Dispose();
		dbcmd = null;
		reader.Close();
		reader = null;

		string sqlQueryIntel = "SELECT Title, id  FROM intelligences";
		IDbCommand dbcmd2 = dbconn.CreateCommand();
		dbcmd2.CommandText = sqlQueryIntel;
		 reader = dbcmd2.ExecuteReader();

		while (reader.Read())
		{
			int ai = (int)reader.GetFloat(1);
			All8Intelligences[ai] =  reader.GetString(0); ///intelligence id
		 //Debug.Log("All8Intelligences###" + ai);
			
		}


		//////////////////////
		dbcmd2.Dispose();
		dbcmd2 = null;
		reader.Close();
		reader = null;


		/////////////////careers  .. id, Job_Title, Intelligence1_id ,Intelligence2_id,  Intelligence3_id

		string sqlQuerycareers = "SELECT id, Job_Title, Intelligence1_id ,Intelligence2_id,  Intelligence3_id FROM careers";
		IDbCommand dbcmd3 = dbconn.CreateCommand();
		dbcmd3.CommandText = sqlQuerycareers;
		reader = dbcmd3.ExecuteReader();

		while (reader.Read())
		{
			/// /JobTitleList structure has = id [Dictionary[name, array of 3 int for values for the 3 intelligences]] --j0b_Intelligences
		//	Debug.Log(reader.GetFloat(0) + "Whats up?");
			int career_id = (int) reader.GetFloat(0);
			string careerTitle  = reader.GetString(1);
				careerTitle = careerTitle.Trim();
			int[] j0b_Intelligences = new int[3];
			j0b_Intelligences[0]= (int)reader.GetFloat(2);

			//j0b_Intelligences[1] = (int)reader.GetFloat(3);
			//j0b_Intelligences[2] = (int)reader.GetFloat(4);///null?
			 
			Dictionary<string, int[]> dt = new Dictionary<string, int[]>();
			dt.Add(careerTitle, j0b_Intelligences);


			JobTitleList.Add(career_id,  dt);

		//	tempT.text += reader.GetFloat(1) + " - " + reader.GetString(0) + "\n";
		 
		}


		dbcmd3.Dispose();
		dbcmd3 = null;
		reader.Close();
		reader = null;

		}
		catch (Exception e) { Debug.Log("error database : " + e + "\n" + conn); }
	}



	 


	public void playRather() {



	}


	public static void fillmyIntelligences( int intel) {

		myIntelligences.Add(intel);
		Debug.Log( " ### "+   intel );

	}


	public static void showmyIntelligences(int what_num)
	{
		
	//	Debug.Log(" ### "  + myIntelligences[what_num]);

	}


	public static void showmyqlList(int what_num)
	{




 	Debug.Log(" ### " + String.Join("--" , qlList[0].ToArray()) );

	}




}
 
	
	 
