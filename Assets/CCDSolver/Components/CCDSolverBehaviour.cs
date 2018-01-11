using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCDSolver.Components
{
	public class CCDSolverBehaviour : IKNodeBehaviour
	{

		public ICCDSolver Solver { get; private set; }

		// Use this for initialization
		void Awake ()
		{
			Solver = new CCDSolver();
		}
		protected override void Start()
		{
			base.Start();
			Solver.AddRootNode(IKNode);
			Solver.InsertChainObject(ChainIndex, IKNode);
		}

		// Update is called once per frame
		#if DEBUG_CCDSOLVER
		void Update ()
		{
			var solver = Solver as CCDSolver; 
			foreach (var node in solver.ChainNodes)
			{
				Vector3 rotatedVector = node.WorldRotation * new Vector3(5, 0, 0);
				var lookAtVector = solver.IKTarget.WorldPosition - node.WorldPosition;
				Debug.DrawRay(node.WorldPosition, rotatedVector,Color.red,Time.deltaTime);
				Debug.DrawRay(node.WorldPosition, lookAtVector,Color.blue,Time.deltaTime);
				float resultAngle = Vector3.Angle(lookAtVector, rotatedVector);
				Debug.Log("Angle: " + resultAngle);
			}
		}
	#endif
	}
}
