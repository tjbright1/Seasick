using UnityEngine;
using System.Collections;

public class Pirate : MonoBehaviour {

	private static double maxHunger = 20.0;
	private static double maxThirst = 15.0;
	private static double maxMoral = 50.0;

	private NavMeshAgent agent;

	public double hunger = 20.0;
	public double thirst = 15.0;
	public double moral = 50.0;

	public Vector3 curLocation;
	public bool selected = false;

	//Initialization
	void Start () {
		agent = gameObject.GetComponent<NavMeshAgent>();
		curLocation = agent.nextPosition;
	}

	void Update () {

	}


}