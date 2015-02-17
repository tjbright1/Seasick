using UnityEngine;
using System.Collections;

public class JobManager : MonoBehaviour {

	private GameObject[] jobObjects;

	public static int totalFood = 200;
	public static int totalWater = 200;
	public static int totalWood = 0;
	public static int defaultDays = 30;
	public static ArrayList jobs;

	void Awake () {
		jobs = new ArrayList ();
		jobObjects = GameObject.FindGameObjectsWithTag ("Jobs");
		for (int i = 0; i < jobObjects.Length; i++)
			jobs.Add(jobObjects[i].gameObject.GetComponent("Job"));
	}

	void Update () {

	}

	public static void calculateMoralEffects() {
		//TODO: Call this function at the beginning of each day. Causes stack overflow, apparenly

	}

	public static void setFood(int effect) {
		totalFood += effect;
		Debug.Log (totalFood);
	}
	
	public static void setWater(int effect) {
		totalWater += effect;
		Debug.Log (totalWater);
	}
	
	public static void setWood(int effect) {
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
