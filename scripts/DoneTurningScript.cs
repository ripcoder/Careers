using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoneTurningScript : MonoBehaviour
{


	public GameObject b1;

	public GameObject b2;


	public GameObject wyr;

	private void Start()
	{
		DT();
	}


	// Use this for initialization
	public void DT()
	{
		StartCoroutine(Waitforit());


		Debug.Log("DDDDDTTTTT");
	}



	IEnumerator Waitforit()
	{
		wyr.SetActive(true);
	
		yield return new WaitForSeconds(1f);
		b1.SetActive(true);
		yield return new WaitForSeconds(0.5f);
			b2.SetActive(true);
	}


}