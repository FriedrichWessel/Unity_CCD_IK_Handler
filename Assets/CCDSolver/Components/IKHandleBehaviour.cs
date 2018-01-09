using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCDSolver.Components
{
	public class IKHandleBehaviour : IKNodeBehaviour {
		protected override void Start()
		{
			base.Start();
			RootNode.Solver.AddIKTarget(IKNode);
		}
	}

}
