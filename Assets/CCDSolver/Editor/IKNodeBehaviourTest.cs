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
		public void ChainIndexShouldBeFourOnIfObjectHasThreeParentsAndRoot()
		{
			var p1 = new GameObject("P1");
			p1.AddComponent<IKChainElementBehaviour>();
			var p2 = new GameObject("P2");
			p2.AddComponent<IKChainElementBehaviour>();
			var p3 = new GameObject("P3");
			p3.AddComponent<IKChainElementBehaviour>();
			p1.transform.SetParent(_parent.transform);
			p2.transform.SetParent(p1.transform);
			p3.transform.SetParent(p2.transform);
			_testNode.transform.SetParent(p3.transform);
			
			InvokeStart();
			Assert.AreEqual(4, _testNode.ChainIndex);
		}

		[Test]
		public void ChainIndexShouldBeOneIfObjectHasOnlyRootAsParents()
		{
			InvokeStart();
			Assert.AreEqual(1, _testNode.ChainIndex);
		}

		[Test]
		public void ChainIndexShouldIgnoreParentsThatAreNotIKNodes()
		{
			var p1=new GameObject("p1");
			_parent.transform.SetParent(p1.transform);
			InvokeStart();
			Assert.AreEqual(1,_testNode.ChainIndex);
		}
		
		private void InvokeStart()
		{
			MethodInfo dynMethod = _testNode.GetType().GetMethod("Start", BindingFlags.NonPublic | BindingFlags.Instance);
			dynMethod.Invoke(_testNode, new object[] { });
		}
	}

}
