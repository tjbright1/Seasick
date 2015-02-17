using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataDisplay : MonoBehaviour {

	public Text[] textValues;
	
	void Start () {

	}
	
	void Update () {

		updateText ();
	} 
	
	private void updateText ()
	{
		textValues [0].text = "Hunger: " + PirateManager.totalHunger;
		textValues [1].text = "Thirst: " + PirateManager.totalThirst;
		textValues [2].text = "Moral: " + PirateManager.totalMoral;
		textValues [3].text = "Days Left: " + (JobManager.defaultDays - DayNightController.daysPast);
	}	
}