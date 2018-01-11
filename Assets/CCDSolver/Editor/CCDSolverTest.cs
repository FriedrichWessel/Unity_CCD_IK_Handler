using System;
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
		private ITransformNode _ikTarget;
		private List<IIKNode> _chainObjects;
		
		[SetUp]
		public void RunBeforeEveryTest()
		{
			_solver = new CCDSolver();
			_rootNode = Substitute.For<IIKNode>();
			_rootNode.WorldPosition.Returns(new Vector3(0, 0, 0));
			_ikTarget = Substitute.For<ITransformNode>();
			var chainNode1 = Substitute.For<IIKNode>();
			chainNode1.WorldPosition.Returns(new Vector3(5, 1, 0));
			var chainNode2 = Substitute.For<IIKNode>();
			chainNode2.WorldPosition.Returns(new Vector3(5, 5, 0));
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
		public void ChangeIKTargetShouldOrientChildNodesTowardsHandle()
		{
			_solver.AddIKTarget(_ikTarget);
			_solver.InsertChainObject(0,_chainObjects[0]);
			_solver.InsertChainObject(1,_chainObjects[1]);
			var ikHandlePosition = new Vector3(10, 0, 0);
			_ikTarget.PositionChanged += Raise.Event<Action<Vector3>>(ikHandlePosition);
			_chainObjects[0].Received().RotateTowardsPosition(ikHandlePosition);
			_chainObjects[1].Received().RotateTowardsPosition(ikHandlePosition);
		}

		[Test]
		public void CanInsertChainObjectsToSolver()
		{
			_solver.InsertChainObject(0, _chainObjects[0]);
			_solver.InsertChainObject(1, _chainObjects[1]);
			Assert.AreEqual(_chainObjects[0], _solver.ChainNodes[0]);
			Assert.AreEqual(_chainObjects[1], _solver.ChainNodes[1]);
		}

		[Test]
		public void InsertLastChainObjectFirstShouldEnhanceTheList()
		{
			_solver.InsertChainObject(1, _chainObjects[1]);
			_solver.InsertChainObject(0, _chainObjects[0]);
			Assert.AreEqual(_chainObjects[0], _solver.ChainNodes[0]);
			Assert.AreEqual(_chainObjects[1], _solver.ChainNodes[1]);
			Assert.AreEqual(2,_solver.ChainNodes.Count);
		}


	}

}
