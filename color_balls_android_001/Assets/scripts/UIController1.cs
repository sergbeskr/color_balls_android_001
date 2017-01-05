using UnityEngine;
using System.Collections;

public class UIController1 : MonoBehaviour {

	private static UIController1 _instance;

	public static UIController1 getInstance()
	{
		if (_instance == null)
			_instance = new UIController1();
		return _instance;
	}
}
