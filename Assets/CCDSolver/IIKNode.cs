using System;
using System.ComponentModel;
using UnityEngine;

namespace CCDSolver
{
	public interface IIKNode
	{
		event Action<Vector3> PositionChanged;
		Vector3 WorldPosition { get;  }
		Quaternion WorldRotation { get; }

		float CalculateAngleToPosition(Vector3 position);
		void RotateTowardsPosition(Vector3 targetPosition);
		void UpdatePosition(Vector3 newPosition);
		void UpdateRotation(Quaternion newRotation);
	}
}