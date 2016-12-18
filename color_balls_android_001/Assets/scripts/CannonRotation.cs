using UnityEngine;
using System.Collections;

public class CannonRotation : MonoBehaviour {

	float yRot;
	private Quaternion m_CharacterTargetRot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		yRot = Input.GetAxis ("Mouse X");
		m_CharacterTargetRot *= Quaternion.Euler (yRot, 0f, 0f);
		//gameObject.transform.localRotation
	}
}
