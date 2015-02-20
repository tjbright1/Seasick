using UnityEngine;
using System.Collections;

public class ClockAnimator : MonoBehaviour
{
	public Transform hours, minutes, sun;
	
	private DayNightController controller;
	private const float
		hoursToDegrees = 360f / 12f,
		minutesToDegrees = 360f / 60f;
	
	void Start ()
	{
		controller = gameObject.GetComponent<DayNightController> ();
	}

	// Update is called once per frame
	void Update ()
	{
		hours.localRotation = Quaternion.Euler(0f, 0f, controller.worldTimeHour * -hoursToDegrees + 180);
		minutes.localRotation = Quaternion.Euler(0f, 0f, controller.minutes * -minutesToDegrees + 180);
	}
}