using System;
using System.Collections;
using System.Collections.Generic;
using CCDSolver;
using UnityEditor.Graphs;
using UnityEngine;

namespace CCDSolver
{
	public class IKNode : TransformNode, IIKNode {

		public IKNode(Transform connectedTransform) : base(connectedTransform){}

		public float CalculateAngleToPosition(Vector3 position)
		{
			Vector3 rotatedVector = WorldRotation * new Vector3(1, 0, 0); 
			var lookAtVector = position - WorldPosition;
			float resultAngle = Vector3.Angle(lookAtVector, rotatedVector);
			var perpendicularVector = Vector3.Cross( lookAtVector, rotatedVector);
			if (perpendicularVector.z > 0)
			{
				return resultAngle;
			}
			return -resultAngle;
		}

		public void RotateTowardsPosition(Vector3 targetPosition)
		{
			var angle = CalculateAngleToPosition(targetPosition);
			UpdateRotation(WorldRotation * Quaternion.Euler(0, 0, -angle));
		}


	}

}
