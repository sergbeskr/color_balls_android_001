using UnityEngine;
using System;

public interface IBulletsElement: IDisposable {
	
	void Activate();
	void SetPosition(Vector3 position);
	void AddForce(Vector3 force, float speed);
	void SetPool(IBulletsPool pool);
}
