using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pirate : MonoBehaviour {

	private static int maxHunger = 20;
	private static int maxThirst = 15;
	private static int maxMorale = 50;

	private NavMeshAgent agent;

	public int hunger = 5;
	public int thirst = 5;
	public int morale = 5;

	public Vector3 curLocation;
	public bool selected = false;
	public bool doneJob = false;

	public AudioClip[] pirateSpeechClips;
	
	//Initialization
	void Start () {

	}

	void Update () {
		if (selected) {
			updateUI ();
		}
	}

	public void say(int audioIndex) {
		if (!audio.isPlaying) {
			audio.clip = pirateSpeechClips [audioIndex];
			audio.pitch = Random.Range (1.20F, 1.35F);
			audio.Play ();
		}
	}

	public static int getMaxHunger() {
		return maxHunger;
	}

	public static int getMaxThirst() {
		return maxThirst;
	}

	public static int getMaxMorale() {
		return maxMorale;
	}

	public void updateUI() {
		GameObject.Find ("StatBars").GetComponent<StatBarAnimator>().changeHunger(hunger);
		GameObject.Find ("StatBars").GetComponent<StatBarAnimator>().changeThirst(thirst);
		GameObject.Find ("StatBars").GetComponent<StatBarAnimator>().changeMorale(morale);
		Sprite [] pirateFaces = GameObject.Find ("PirateManager").GetComponent<PirateManager> ().pirateFaces;
		GameObject.Find ("StatBars").GetComponent<StatBarAnimator>().changeFaces(pirateFaces);
	}
}