using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace CCDSolver.UnitTests
{

	public class IKNodeTest  {
		private IIKNode _testNode;
		private Transform _testTransform;

		[SetUp]
		public void RunBeforeEveryTest()
		{
			_testTransform = new GameObject("TestIKNode").transform;
			_testNode = new IKNode(_testTransform);
			
		}

		[TearDown]
		public void RunAfterEveryTest()
		{
			Object.DestroyImmediate(_testTransform.gameObject);
		}

		[Test]
		public void CalculateAngleToOrthogonalPositionShouldReturn90()
		{
			var angle = _testNode.CalculateAngleToPosition( new Vector3(0,10,0));
			Assert.AreEqual(-90, angle);
		}
		
		[Test]
		public void CalculateAngleToPointInXLineShouldReturn0()
		{
			var angle = _testNode.CalculateAngleToPosition(new Vector3(10, 0, 0));
			Assert.AreEqual(0, angle);
		}
		
		[Test]
		public void CalculateAngleBetweenNodesInNegDiagonalShouldReturn135()
		{
			var angle = _testNode.CalculateAngleToPosition(new Vector3(-10, 10, 0));
			Assert.AreEqual(-135, angle);
		}
		
		[Test]
		public void CalculateAngleBetweenToNegativeOrthogonalPointShouldReturnNeg90()
		{
			var angle = _testNode.CalculateAngleToPosition(new Vector3(0, -10, 0));
			Assert.AreEqual(90, angle);
		}

		[Test]
		public void RotateTowardsPositionShouldAlignToTargetPosition()
		{
			_testNode.RotateTowardsPosition(new Vector3(2.4f, -5, 0));
			Assert.AreEqual(0, _testNode.CalculateAngleToPosition(new Vector3(2.4f, -5, 0)));
			_testNode.RotateTowardsPosition(new Vector3(0, -10, 0));
			Assert.AreEqual(0, _testNode.CalculateAngleToPosition(new Vector3(0f, -10, 0)));
			_testNode.RotateTowardsPosition(new Vector3(0, 10, 0));
			Assert.AreEqual(0, _testNode.CalculateAngleToPosition(new Vector3(0f, 10, 0)));
		}
	}

}
