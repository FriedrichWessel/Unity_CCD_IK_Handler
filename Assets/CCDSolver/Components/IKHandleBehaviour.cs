using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCDSolver.Components
{
	public class IKHandleBehaviour : MonoBehaviour
	{
		[SerializeField] private CCDSolverBehaviour _solverComponent;
		
		private Vector3 _cachedPosition;
		private ITransformNode _node;
		
		protected void Start()
		{
			_node = new TransformNode(transform);
			_solverComponent.Solver.AddIKTarget(_node);
		}

		void Update()
		{
			if (transform.position != _cachedPosition)
			{
				_cachedPosition = transform.position;
				_node.UpdatePosition(transform.position);
			}
		}
	}

}
