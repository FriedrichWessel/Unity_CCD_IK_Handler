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

		
	}
}