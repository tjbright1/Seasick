using UnityEngine;
using System.Collections;

public class ClockAnimator : MonoBehaviour
{
		public Transform hours, minutes;
		
		private DayNightController controller;
		private const float
				hoursToDegrees = 360f / 12f,
				minutesToDegrees = 360f / 60f,
				secondsToDegrees = 360f / 60f;

		void Start ()
		{
				controller = gameObject.GetComponent<DayNightController> ();
		}

		// Update is called once per frame
		void Update ()
		{

		}
}