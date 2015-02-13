using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PirateManager : MonoBehaviour
{

		private GameObject[] pirateObjects;
		private GameObject[] textObjects;

		public static double totalHunger = 0;
		public static double totalThirst = 0;
		public static double totalMoral = 0;
		public Text[] textValues;
		public static ArrayList pirates;
		public static Pirate lastSelected; 

		//Initialization
		void Awake ()
		{
				textObjects = GameObject.FindGameObjectsWithTag ("Text");

				pirates = new ArrayList ();
				pirateObjects = GameObject.FindGameObjectsWithTag ("Pirates");
				for (int i = 0; i < pirateObjects.Length; i++)
						pirates.Add (pirateObjects [i].gameObject.GetComponent ("Pirate"));

				calculateTotals ();
		}
	
		void Update ()
		{
				updateText ();
				checkForPirate ();
		}

		public static void calculateTotals ()
		{
				totalHunger = 0;
				totalThirst = 0;
				totalMoral = 0;
				foreach (Pirate e in pirates) {
						totalHunger += e.hunger;
						totalThirst += e.thirst;
						totalMoral += e.moral;
				}
		}

		public static Pirate getSelectedPirate ()
		{
				foreach (Pirate e in pirates) {
						if (e.selected)
								return e; 
				}
				return null;
		}

		public static bool isAPirateSelected ()
		{
				foreach (Pirate e in pirates) {
						if (e.selected)
								return true;
				}
				return false;
		}
	
		public void updateText ()
		{
				textValues [0].text = "Hunger: " + totalHunger;
				textValues [1].text = "Thirst: " + totalThirst;
				textValues [2].text = "Moral: " + totalMoral;
		}

		public void checkForPirate ()
		{
				if (Input.GetMouseButtonDown (0) && !isAPirateSelected ()) {
						RaycastHit hitInfo = new RaycastHit ();
						bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo);
						if (hit) {
								Debug.Log ("Hit " + hitInfo.transform.gameObject.name);
								if (hitInfo.transform.gameObject.tag == "Pirates") {
										hitInfo.transform.gameObject.GetComponent<Pirate> ().selected = true;
										lastSelected = hitInfo.transform.gameObject.GetComponent<Pirate> ();
								}

								JobManager.checkForJob (hitInfo);
						}
				} 
		}

		public static void setHunger (double effect)
		{
				totalHunger += effect;
				JobManager.calculateEffects ();
				Debug.Log ("Total Hunger: " + totalHunger);
		}
	
		public static void setThirst (double effect)
		{
				totalThirst += effect;
				JobManager.calculateEffects ();
				Debug.Log ("Total Thirst: " + totalThirst);
		}
	
		public static void setMoral (double effect)
		{
				totalMoral += effect;
				JobManager.calculateEffects ();
				Debug.Log ("Total Moral: " + totalMoral);
		}
}