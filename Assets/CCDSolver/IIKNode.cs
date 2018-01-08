using System;
using System.ComponentModel;
using UnityEngine;

namespace CCDSolver
{
	public interface IIKNode
	{
		Vector3 WorldPosition { get;  }
		Quaternion WorldRotation { get; }

		float CalculateAngleToPosition(Vector3 position);
		void RotateTowardsPosition(Vector3 targetPosition);
	}
}