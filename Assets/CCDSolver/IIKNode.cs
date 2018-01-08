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
	}
}