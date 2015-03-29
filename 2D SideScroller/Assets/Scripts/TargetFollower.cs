using UnityEngine;
using System.Collections;

public class TargetFollower : MonoBehaviour 
{
	public Transform target;

	private Vector3 offset;

	void Start()
	{
		offset = target.position - transform.position;
	}

	void Update()
	{
		this.transform.position = target.position - offset;
	}
}
