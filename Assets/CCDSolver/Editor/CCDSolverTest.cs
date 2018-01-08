using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace CCDSolver.UnitTests
{

	public class CCDSolverTest  {
		private CCDSolver _solver;
		
		private IIKNode _rootNode;
		private IIKNode _ikTarget;
		private List<IIKNode> _chainObjects;
		
		[SetUp]
		public void RunBeforeEveryTest()
		{
			_solver = new CCDSolver();
			_rootNode = Substitute.For<IIKNode>();
			_ikTarget = Substitute.For<IIKNode>();
			var chainNode1 = Substitute.For<IIKNode>();
			var chainNode2 = Substitute.For<IIKNode>();
			_chainObjects = new List<IIKNode>(){chainNode1, chainNode2};
		}

		[Test]
		public void CanAddRootObjectToSolver()
		{
			_solver.AddRootNode(_rootNode);
			Assert.AreEqual(_rootNode, _solver.RootNode);
		}
		
		[Test]
		public void CanAddTarget()
		{
			_solver.AddIKTarget(_ikTarget);
			Assert.AreEqual(_ikTarget, _solver.IKTarget);
		}

		[Test]
		public void CanInsertChainObjectsToSolver()
		{
			_solver.InsertChainObject(0, _chainObjects[0]);
			_solver.InsertChainObject(1, _chainObjects[1]);
			Assert.AreEqual(_chainObjects[0], _solver.ChainNodes[0]);
			Assert.AreEqual(_chainObjects[1], _solver.ChainNodes[1]);
		}

		
	}

}
