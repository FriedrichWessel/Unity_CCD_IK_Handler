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
		public void RotateTowardsPositionShouldRotateWorldRotationAroundDifferenceAngle()
		{
			_testNode.RotateTowardsPosition(new Vector3(0, -10, 0));
			Assert.AreEqual(new Vector3(0,0,90), _testNode.WorldRotation.eulerAngles);
		}

		[Test]
		public void UpdatePositionShouldTriggerPositionChangedEvent()
		{
			bool called = false;
			_testNode.PositionChanged += newPosition => { called = true; };
			_testNode.UpdatePosition(new Vector3(10, 0, 0));
			Assert.IsTrue(called);
		}

		[Test]
		public void PositionChangedEventShouldDeliverNewPositionValues()
		{
			bool called = false;
			_testNode.PositionChanged += newPosition =>
			{
				called = true;
				Assert.AreEqual(new Vector3(10,0,0),newPosition );
			};
			_testNode.UpdatePosition(new Vector3(10, 0, 0));
			Assert.IsTrue(called);
		}

		[Test]
		public void UpdatePositionShouldChangeWorldPositionToGivenValue()
		{
			var testPosition = new Vector3(10, 14, 2.4f);
			_testNode.UpdatePosition(testPosition);
			Assert.AreEqual(testPosition, _testNode.WorldPosition);
		}

		[Test]
		public void UdpateRotationShouldChangeWorldRotationToGivenValue()
		{
			var testRotation = Quaternion.Euler(10, 2.4f, 13.8f);
			_testNode.UpdateRotation(testRotation);	
			Assert.IsTrue(Mathf.Approximately(testRotation.w, _testNode.WorldRotation.w));
			Assert.IsTrue(Mathf.Approximately(testRotation.x, _testNode.WorldRotation.x));
			Assert.IsTrue(Mathf.Approximately(testRotation.y, _testNode.WorldRotation.y));
			Assert.IsTrue(Mathf.Approximately(testRotation.z, _testNode.WorldRotation.z));
		}
	}

}
