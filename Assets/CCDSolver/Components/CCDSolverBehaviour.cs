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
		}

		// Update is called once per frame
		void Update () {
			
		}
	}
}
