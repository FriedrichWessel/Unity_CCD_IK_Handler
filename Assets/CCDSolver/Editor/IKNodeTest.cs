using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace CCDSolver.UnitTests
{

	public class IKNodeTest  {
		private IIKNode _testNode;

		[SetUp]
		public void RunBeforeEveryTest()
		{
			_testNode = new IKNode(Vector3.zero, Quaternion.identity);
			
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
		public void RotateTowardsPositionShouldRotateWorldRotationAroundDifferenceAngle()
		{
			_testNode.RotateTowardsPosition(new Vector3(0, -10, 0));
			Assert.AreEqual(new Vector3(0,0,90), _testNode.WorldRotation.eulerAngles);
		}
	}

}
