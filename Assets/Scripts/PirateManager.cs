using UnityEngine;
using System.Collections;

public class PirateManager : MonoBehaviour
{
		private GameObject[] pirateObjects;

		public static int totalHunger = 0;
		public static int totalThirst = 0;
		public static int totalMoral = 0;
		public static ArrayList pirates;
		public static Pirate lastSelected;

		//Initialization
		void Awake ()
		{
				selector = GameObject.Find ("Selector");
				pirates = new ArrayList ();
				pirateObjects = GameObject.FindGameObjectsWithTag ("Pirates");
				for (int i = 0; i < pirateObjects.Length; i++)
						pirates.Add (pirateObjects [i].gameObject.GetComponent ("Pirate"));

				calculateTotals ();
		}

		void Update ()
		{
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

		public void checkForPirate ()
		{
				if (Input.GetMouseButtonDown (0)) {
						foreach (Pirate e in pirates)
							e.selected = false;

						selector.renderer.enabled = false;
						Debug.Log("Hit nothing");
						RaycastHit hitInfo = new RaycastHit ();
						bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo);
						if (hit) {
								Debug.Log ("Hit " + hitInfo.transform.gameObject.name);
								if (hitInfo.transform.gameObject.tag == "Pirates") {
										selector.transform.parent = null;
										selector.renderer.enabled = true;
										Pirate currentPirate = hitInfo.transform.gameObject.GetComponent<Pirate>();
										currentPirate.selected = true;
										currentPirate.say (0);
										selector.transform.position = currentPirate.transform.position + new Vector3(0, 5, 0);
										selector.transform.SetParent(currentPirate.transform, true);

										lastSelected = hitInfo.transform.gameObject.GetComponent<Pirate>();
								}

								JobManager.checkForJob (hitInfo);
						}
				}
		}

		public static void setHunger (int effect)
		{
				totalHunger += effect;
				Debug.Log ("Total Hunger: " + totalHunger);
		}

		public static void setThirst (int effect)
		{
				totalThirst += effect;
				Debug.Log ("Total Thirst: " + totalThirst);
		}

		public static void setMoral (int effect)
		{
				totalMoral += effect;
				Debug.Log ("Total Moral: " + totalMoral);
		}
}
