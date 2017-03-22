using UnityEngine;
using System.Collections;

public class translate : MonoBehaviour {

	// Use this for initialization
	public GameObject player;

	void Start () {
		transform.position = player.transform.position;
		transform.rotation = player.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position;
		transform.rotation = player.transform.rotation;
	}
}
