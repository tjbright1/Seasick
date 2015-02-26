using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NightlyEvent : MonoBehaviour {
	
	public int effect;
	public int baseEffect;
	public int maxVariation;

	public Text description;
	
	public bool affectsFood = false;
	public bool affectsWater = false;
	public bool affectsWood = false;
	public bool affectsMorale = false;
	public bool variation = false;
	
	void Start () {
		description.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (variation)
			variate ();
	}

	public void doAffect() {
		if (affectsFood) {
			JobManager.setFood(effect);
			PirateManager.setHunger(effect);
		}
		if (affectsWater) {
			JobManager.setWater(effect);
			PirateManager.setThirst(effect);
		}
		if (affectsWood) {
			JobManager.setWood (effect);
			PirateManager.calculateTotals ();
		}
	}

	private void variate() {
		effect += Random.Range (-maxVariation, maxVariation);
		description.text = description.text.Replace ("" + baseEffect, "" + effect);
	}
}