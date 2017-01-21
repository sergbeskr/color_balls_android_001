using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UiStart : MonoBehaviour {

	void Start()
	{
		AudioManager.Instance.PlayMusicInternal ("Startsong");
	}

	public void OnClickStart()
	{
		SceneManager.LoadScene ("scene_001");
	}
}
