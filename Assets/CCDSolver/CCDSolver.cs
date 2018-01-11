using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CCDSolver
{
	

	public class CCDSolver : ICCDSolver
	{
		public ITransformNode IKTarget { get; private set; }
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

		public void AddIKTarget(ITransformNode ikTarget)
		{
			IKTarget = ikTarget;
			IKTarget.PositionChanged += CalculateChainNodePositions;
		}

		private void CalculateChainNodePositions(Vector3 newPosition)
		{
			for (int c = 0; c < 5; c++)
			{
				for (int i = ChainNodes.Count - 1; i >= 0; i--)
				{
					ChainNodes[i].RotateTowardsPosition(newPosition);
				}
				
			}
			
		}


		public void InsertChainObject(int chainIndex, IIKNode chainObject)
		{
			while (chainIndex+1 > ChainNodes.Count)
			{
				ChainNodes.Add(null);
			}
			ChainNodes[chainIndex] =  chainObject;
		}

		
	}
}