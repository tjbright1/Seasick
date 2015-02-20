using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NightlyEvent : MonoBehaviour {
	
	public int effect;
	public Text description;
	
	public bool affectsFood = false;
	public bool affectsWater = false;
	public bool affectsWood = false;
	public bool affectsMorale = false;
	
	void Start () {
		description.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void doAffect() {
		if (affectsFood) {
			JobManager.setFood(effect);
			PirateManager.setHunger(effect);
		}
		else if (affectsWater) {
			JobManager.setWater(effect);
			PirateManager.setThirst(effect);
		}
		else if (affectsWood) 
			JobManager.setWood(effect);
		PirateManager.calculateTotals ();
	}
}