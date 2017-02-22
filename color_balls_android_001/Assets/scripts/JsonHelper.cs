using UnityEngine;
using System.Collections;
using System;

public class JsonHelper {
	
	public static T[] FromJson<T>(string json)
	{
		Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
		return wrapper.levels;
	}

	[Serializable]
	private class Wrapper<T>
	{
		public T[] levels;
	}

}
