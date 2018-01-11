using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCDSolver
{
	public class TransformNode : ITransformNode
	{
		private Transform _connectedTransform;
		public event Action<Vector3> PositionChanged = (newPosition) => { };
		
		public Vector3 WorldPosition {
			get { return _connectedTransform.position; } 
			private set { _connectedTransform.position = value; }
		}
		public Quaternion WorldRotation {
			get { return _connectedTransform.rotation; }
			private set { _connectedTransform.rotation = value; }
		}


		public TransformNode(Transform connectedTransform)
		{
			_connectedTransform = connectedTransform;
		}
		
		public void UpdatePosition(Vector3 newPosition)
		{
			WorldPosition = newPosition;
			PositionChanged(WorldPosition);
		}

		public void UpdateRotation(Quaternion newRotation)
		{
			WorldRotation = newRotation;
		}
	}
}
