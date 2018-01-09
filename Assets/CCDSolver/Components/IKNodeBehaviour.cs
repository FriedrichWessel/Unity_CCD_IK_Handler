using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCDSolver.Components
{
	public class IKNodeBehaviour : MonoBehaviour
	{

		protected CCDSolverBehaviour RootNode { get; private set; }
		protected IIKNode IKNode { get; private set; }
		public int ChainIndex { get; private set; }

		// Use this for initialization
		protected  virtual void Start ()
		{
			RootNode = gameObject.GetComponentInParent<CCDSolverBehaviour>();
			if (RootNode == null)
			{
				throw new MissingComponentException(string.Format("IKNodeBehaviour {0} needs a CCDSolverBehaviour in parent hirachy", gameObject.name));
			}
			IKNode = new IKNode(transform.position, transform.rotation);
			CalculateChainIndex();
		}

		private void CalculateChainIndex()
		{
			var parentTransform = this.transform.parent;
			while (parentTransform != null)
			{
				ChainIndex++;
				parentTransform = parentTransform.parent;
			}
		}

		// Update is called once per frame
		void Update () {
			
		}
	}
}
