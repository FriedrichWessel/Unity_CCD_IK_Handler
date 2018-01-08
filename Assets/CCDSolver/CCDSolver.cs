using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CCDSolver
{
	public class CCDSolver
	{
		public IIKNode IKTarget { get; private set; }
		public IIKNode RootNode { get; private set; }

		public List<IIKNode> ChainNodes { get; private set;}

		public CCDSolver()
		{
			ChainNodes = new List<IIKNode>();
		}

		public void AddRootNode(IIKNode rootNode)
		{
			RootNode = rootNode;
		}

		public void AddIKTarget(IIKNode ikTarget)
		{
			IKTarget = ikTarget;
		}


		public void InsertChainObject(int chainIndex, IIKNode chainObject)
		{
			ChainNodes.Insert(chainIndex, chainObject);
		}

		public float CalculateAngle(IIKNode node, IIKNode target)
		{
			Vector3 rotatedVector = node.WorldRotation * new Vector3(1, 0, 0); 
			var lookAtVector = target.WorldPosition - node.WorldPosition;
			float resultAngle = Vector3.Angle(lookAtVector, rotatedVector);
			var perpendicularVector = Vector3.Cross( rotatedVector, lookAtVector);
			if (perpendicularVector.z > 0)
			{
				return resultAngle;
			}
			return -resultAngle;
		}
	}
}