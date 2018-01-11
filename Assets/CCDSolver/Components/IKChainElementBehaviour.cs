using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCDSolver.Components
{
	public class IKChainElementBehaviour : IKNodeBehaviour {
		protected override void Start()
		{
			base.Start();
			RootNode.Solver.InsertChainObject(ChainIndex, IKNode);
		}

	}
}
