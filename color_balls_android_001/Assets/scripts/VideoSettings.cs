using UnityEngine;
using System.Collections;

public class VideoSettings : MonoBehaviour {

	[SerializeField]
	private Camera camera1, camera2;

	public void OnChangeCamera()
	{
		if (camera1.isActiveAndEnabled) {
			camera1.gameObject.SetActive (false);
			camera2.gameObject.SetActive (true);
			PlayerPrefs.SetInt ("Camera", 2);
			PlayerPrefs.Save ();
		} else {
			camera2.gameObject.SetActive (false);
			camera1.gameObject.SetActive (true);
			PlayerPrefs.SetInt ("Camera", 1);
			PlayerPrefs.Save ();
		}
	}
}
