using System;
using UnityEngine;

namespace CCDSolver
{
	public interface ITransformNode
	{
		event Action<Vector3> PositionChanged;
		Vector3 WorldPosition { get; }
		Quaternion WorldRotation { get; }
		void UpdatePosition(Vector3 newPosition);
		void UpdateRotation(Quaternion newRotation);
	}
}
