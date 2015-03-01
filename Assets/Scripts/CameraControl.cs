using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public GameObject target;
	public float maxSpeed;
	public float maxVertSpeed;
	public float maxDistance;
	float horizAxis;
	float vertAxis;
	float mWheel;
	int zoomSpeed = 4;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		horizAxis = Input.GetAxis ("Horizontal");
		vertAxis = Input.GetAxis ("Vertical");
		mWheel = Input.GetAxis ("Mouse ScrollWheel");
		Vector3 vertTranslate = new Vector3 (0, vertAxis * maxVertSpeed, 0);
		Vector3 horizTranslate = new Vector3 (horizAxis * maxSpeed, 0, 0);
		transform.Translate (horizTranslate);
		Vector3 targetPos = target.transform.position;
		transform.Translate (vertTranslate);
		transform.LookAt (targetPos);
		if (mWheel > 0) {
			camera.fieldOfView = camera.fieldOfView - zoomSpeed;
			if (camera.fieldOfView <= 40) {
				camera.fieldOfView = 40;
			}
		} else if (mWheel < 0) {
			camera.fieldOfView = camera.fieldOfView + zoomSpeed;
			if (camera.fieldOfView >= 85) {
				camera.fieldOfView = 85;
			}
//			Camera.main.fieldOfView = Mathf.Max (Camera.main.fieldOfView + 2, 85.0);
		}
	}
}

