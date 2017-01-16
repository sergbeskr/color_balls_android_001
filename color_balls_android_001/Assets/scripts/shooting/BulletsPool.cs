using UnityEngine;
using System.Collections.Generic;

public class BulletsPool : MonoBehaviour, IBulletsPool {

	[SerializeField]
	private GameObject prefab;
	private Stack<IBulletsElement> _pool;

	public void Awake()
	{
		_pool = new Stack<IBulletsElement>();

		//IBulletsElement element;
	}

	public IBulletsElement GetElement()
	{
		IBulletsElement item;
		if (_pool.Count > 0)
		{
			item = _pool.Pop();
		}
		else
		{
			item = CreateItem();
		}
		return item;
	}

	private IBulletsElement CreateItem()
	{
		IBulletsElement item;
		GameObject go = Instantiate(prefab) as GameObject;
		item = go.GetComponent<IBulletsElement>();
		item.SetPool(this);
		return item;
	}

	public void PutItem(IBulletsElement element)
	{
		_pool.Push(element);            
	}
}
