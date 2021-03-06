﻿using UnityEngine;
using System;

public interface IBulletsElement: IDisposable {

	void Activate();
	void SetPosition(Vector3 position);
	void AddForce(Vector3 force, float speed, float m_height);
	void SetPool(IBulletsPool pool);
	void SetColor (Color m_color);
}
