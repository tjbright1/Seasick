using UnityEngine;
using System.Collections;

public class JobManager : MonoBehaviour {

	private GameObject[] jobObjects;

	public static double totalFood = 200;
	public static double totalWater = 200;
	public static double totalWood = 0;
	public static ArrayList jobs;

	void Awake () {
		jobs = new ArrayList ();
		jobObjects = GameObject.FindGameObjectsWithTag ("Jobs");
		for (int i = 0; i < jobObjects.Length; i++)
			jobs.Add(jobObjects[i].gameObject.GetComponent("Job"));

	}

	void Update () {

	}

	public static void calculateEffects() {
		//TODO: Call this function at the beginning of each day.
		if (totalFood < 150)
			PirateManager.setMoral (-20);
		if (totalWater < 150)
			PirateManager.setMoral (-50);
	}

	public static void setFood(double effect) {
		totalFood += effect;
		Debug.Log (totalFood);
	}
	
	public static void setWater(double effect) {
		totalWater += effect;
		Debug.Log (totalWater);
	}
	
	public static void setWood(double effect) {
		totalWood += effect;
		Debug.Log (totalWood);
	}

	public static void checkForJob(RaycastHit hitInfo) {
		Debug.Log("Job Hit " + hitInfo.transform.gameObject.name);
		if (hitInfo.transform.gameObject.tag.Equals ("Jobs")) {
			hitInfo.transform.gameObject.GetComponent<Job> ().doAffect ();
		}
	}
}
