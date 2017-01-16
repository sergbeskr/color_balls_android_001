using UnityEngine;
using System.Collections;

public interface IBulletsPool {
	void PutItem(IBulletsElement element);
	IBulletsElement GetElement();
}
