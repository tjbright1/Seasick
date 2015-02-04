using UnityEngine;
using System.Collections;

public class PirateManager : MonoBehaviour {
	
	private double maxTotalHunger;
	private double maxTotalThirst;
	private double maxTotalMoral;
	private GameObject[] pirateObjects;

	public double totalHunger = 0;
	public double totalThirst = 0;
	public double totalMoral = 0;
	public ArrayList pirates;

	//Initialization
	void Start () {
		pirates = new ArrayList ();
		pirateObjects = GameObject.FindGameObjectsWithTag ("Pirates");
		for (int i = 0; i < pirateObjects.Length; i++)
			pirates.Add(pirateObjects[i].gameObject.GetComponent("Pirate"));
	}
	
	void Update () {
		calculateTotals ();
	}

	private void calculateTotals() {
		foreach (Pirate e in pirates) {
			totalHunger += e.hunger;
			totalThirst += e.thirst;
			totalMoral += e.moral;
		}
	}
}