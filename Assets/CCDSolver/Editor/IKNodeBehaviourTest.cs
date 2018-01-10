using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;

namespace CCDSolver.Components.UnitTests
{

	public class IKNodeBehaviourTest  {
		private IKNodeBehaviour _testNode;
		private CCDSolverBehaviour _parent;

		[SetUp]
		public void RunBeforeEveryTest()
		{
			var go = new GameObject("TestNode");
			_testNode = go.AddComponent<IKNodeBehaviour>();
			go = new GameObject("RootNode");
			_parent = go.AddComponent<CCDSolverBehaviour>();
			_testNode.transform.SetParent(_parent.transform);
		}

		[TearDown]
		public void RunAfterEveryTest()
		{
			GameObject.DestroyImmediate(_parent.gameObject);
		}
		
		[Test]
		public void ChainIndexShouldBeThreeOnIfObjectHasThreeParentsAndRoot()
		{
			var p1 = new GameObject("P1");
			var p2 = new GameObject("P2");
			var p3 = new GameObject("P3");
			p1.transform.SetParent(_parent.transform);
			p2.transform.SetParent(p1.transform);
			p3.transform.SetParent(p2.transform);
			_testNode.transform.SetParent(p3.transform);
			
			MethodInfo dynMethod = _testNode.GetType().GetMethod("Start", BindingFlags.NonPublic | BindingFlags.Instance);
			dynMethod.Invoke(_testNode, new object[]{});
			Assert.AreEqual(3, _testNode.ChainIndex);
		}

		[Test]
		public void ChainIndexShouldBeZeroIfObjectHasOnlyRootAsParents()
		{
			MethodInfo dynMethod = _testNode.GetType().GetMethod("Start", BindingFlags.NonPublic | BindingFlags.Instance);
			dynMethod.Invoke(_testNode, new object[]{});
			Assert.AreEqual(0, _testNode.ChainIndex);
		}
	}

}
