using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;

namespace CCDSolver.Components.UnitTests
{
	public class CCDSolverBehaviourTest  {
		private CCDSolverBehaviour _testNode;

		[SetUp]
		public void RunBeforeEveryTest()
		{
			_testNode = new GameObject("TestRoot").AddComponent<CCDSolverBehaviour>();
		}

		[TearDown]
		public void RunAfterEveryTest()
		{
			if (_testNode != null)
			{
				Object.DestroyImmediate(_testNode.gameObject);
			}
		}

		[Test]
		public void CCDSolverShouldBeAddedAsChainObject()
		{
			InvokeAwake();
			InvokeStart();
			var solver = _testNode.Solver as CCDSolver;
			var node = GetIKNode();
			Assert.Contains(node, solver.ChainNodes);
		}

		[Test]
		public void CCDSolverShouldBeRegisteredAsFirstObjectInChain()
		{
			InvokeAwake();
			InvokeStart();
			Assert.AreEqual(0, _testNode.ChainIndex);
		}

		[Test]
		public void CCDSolverShouldBeRegisteredAsRootNode()
		{
			InvokeAwake();
			InvokeStart();
			var solver = _testNode.Solver as CCDSolver;
			var node = GetIKNode();
			Assert.AreEqual(solver.RootNode, node);
		}

		private IIKNode GetIKNode()
		{
			IIKNode node = (IIKNode) _testNode.GetType()
				.GetProperty("IKNode", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(_testNode, new object[] { });
			return node;
		}

		private void InvokeStart()
		{
			MethodInfo dynMethod = _testNode.GetType().GetMethod("Start", BindingFlags.NonPublic | BindingFlags.Instance);
			dynMethod.Invoke(_testNode, new object[] { });
		}

		private void InvokeAwake()
		{
			MethodInfo dynMethod = _testNode.GetType().GetMethod("Awake", BindingFlags.NonPublic | BindingFlags.Instance);
			dynMethod.Invoke(_testNode, new object[] { });
		}
	}

}
