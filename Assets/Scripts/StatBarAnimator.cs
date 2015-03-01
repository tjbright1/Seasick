using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;

public class StatBarAnimator : MonoBehaviour {
	private int hunger;
	private int thirst;
	private int morale;
	private int maxHunger = Pirate.getMaxHunger ();
	private int maxThirst = Pirate.getMaxThirst ();
	private int maxMorale = Pirate.getMaxMorale ();
	private float happiness; // causes background color of portrait to change. Ranges from -1 to 1;
	private Image portrait; 
	private Sprite[] faces;

	// Use this for initialization
	void Start () {
		hunger = 0;
		thirst = 0;
		morale = 0;
		happiness = -1;
		portrait = GameObject.Find("PirateFace").GetComponent<Image>();
		portrait.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		updateBgColor ();

		if (!(PirateManager.isAPirateSelected ())) {
			hunger = 0;
			thirst = 0;
			morale = 0;
			portrait.enabled = false;
		} else {
			portrait.enabled = true;
			changePortrait ();
		}



		GameObject.Find ("HungerBar").GetComponent<Image>().fillAmount =  ((float) hunger) / maxHunger;
		GameObject.Find ("ThirstBar").GetComponent<Image>().fillAmount = ((float) thirst) / maxThirst;
		GameObject.Find ("MoraleBar").GetComponent<Image>().fillAmount = ((float) morale) / maxMorale;
		Debug.Log ("Happiness: " + happiness);
	}

	private void updateBgColor() {
		happiness = 2*((((float) hunger / maxHunger) + ((float) thirst / maxThirst) + ((float) morale / maxMorale)) / 3) - 1; 
		//taking average of percentages, multiplying by 2, subtracting 1. Should give a range from -1 to 1.

		if (happiness > 0) {
			GameObject.Find ("FaceBackground").GetComponent<Image> ().color = new Color (1F - happiness, 1F, 0F);
		} else if (happiness == -1) {
			GameObject.Find("FaceBackground").GetComponent<Image>().color = new Color(1F, 1F, 1F);
		} else {
			GameObject.Find("FaceBackground").GetComponent<Image>().color = new Color(1F, 1F + happiness, 0F);
		}
	}

	public void changeHunger(int amount) {

		if (amount > maxHunger) {
			hunger = maxHunger;
		} else if (amount < 0) {
			hunger = 0;
		} else {
			hunger = amount;
		}
	}

	public void changeThirst(int amount) {

		if (amount > maxThirst) {
			thirst = maxThirst;
		} else if (amount < 0) {
			thirst = 0;
		} else {
			thirst = amount;
		}
	}

	public void changeMorale(int amount) {

		if (amount > maxMorale) {
			morale = maxMorale;
		} else if (amount < 0) {
			morale = 0;
		} else {
			morale = amount;
		}
	}

	public void changeFaces(Sprite[] pirateFaces) {
		faces = pirateFaces;

	}

	public void changePortrait() {
		if (happiness > 0.6F) {
			portrait.sprite = faces [0];
		} else if (happiness <= 0.6F && happiness > 0.2F) {
			portrait.sprite = faces [1];
		} else if (happiness <= 0.2F && happiness > -0.2F) {
			portrait.sprite = faces [2];
		} else if (happiness <= -0.2F && happiness > -0.6F) {
			portrait.sprite = faces [3];
		} else {
			portrait.sprite = faces [4];
		}

	}
	
}
