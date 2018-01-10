using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCDSolver.Components
{
	public class IKHandleBehaviour : IKNodeBehaviour
	{
		private Vector3 _cachedPosition; 
		protected override void Start()
		{
			base.Start();
			RootNode.Solver.AddIKTarget(IKNode);
		}

		void Update()
		{
			if (transform.position != _cachedPosition)
			{
				_cachedPosition = transform.position;
				IKNode.UpdatePosition(transform.position);
			}
		}
	}

}
