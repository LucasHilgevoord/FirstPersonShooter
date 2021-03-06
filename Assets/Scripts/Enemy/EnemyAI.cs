﻿using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]

public class EnemyAI : MonoBehaviour {
	NavMeshAgent pathfinder;
	Transform target;


	void Start () {
		pathfinder = GetComponent<NavMeshAgent> ();
		target = GameObject.FindGameObjectWithTag ("Player").transform;

	}


	void Update () {
		pathfinder.SetDestination (target.position);

	}
}
