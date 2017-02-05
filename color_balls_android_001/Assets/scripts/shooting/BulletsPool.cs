using UnityEngine;
using System.Collections.Generic;

public class BulletsPool : MonoBehaviour, IBulletsPool {

	[SerializeField]
	private GameObject prefab;
	private Stack<IBulletsElement> _pool;
	private Color currColor;


	public void Awake()
	{
		_pool = new Stack<IBulletsElement>();
		UIController.OnChangeColor += ChangeColor;

		currColor = GameController.colors ["red"];
	}

	public IBulletsElement GetElement()
	{
		IBulletsElement item;
		if (_pool.Count > 0)
		{
			item = _pool.Pop();
			item.SetColor (currColor);
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
		item.SetColor(currColor);
		return item;
	}

	public void PutItem(IBulletsElement element)
	{
		_pool.Push(element);            
	}

	void ChangeColor(string btnColor)
	{
		currColor = GameController.colors[btnColor];
	}
}
