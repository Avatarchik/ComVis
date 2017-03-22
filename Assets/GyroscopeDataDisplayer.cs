using UnityEngine;
using System.Collections;

public class GyroscopeDataDisplayer : MonoBehaviour {

	void Start () {	
		Input.gyro.enabled = true;
	}

	void Update () {
		Input.gyro.enabled = true;
		transform.Rotate (-Input.gyro.rotationRateUnbiased.x, -Input.gyro.rotationRateUnbiased.y, Input.gyro.rotationRateUnbiased.z);
	}
}