using UnityEngine;
using System.Collections;

public class Pirate : MonoBehaviour {

	private static int maxHunger = 20;
	private static int maxThirst = 15;
	private static int maxMoral = 50;

	private NavMeshAgent agent;

	public int hunger = 20;
	public int thirst = 15;
	public int moral = 50;

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