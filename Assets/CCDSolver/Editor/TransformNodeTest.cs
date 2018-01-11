using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;

namespace CCDSolver.UnitTests
{
	public class TransformNodeTest  {
		private Transform _testTransform;
		private TransformNode _testNode;

		[SetUp]
		public void RunBeforeEveryTest()
		{
			_testTransform = new GameObject("TestTransform").transform;
			_testNode = new TransformNode(_testTransform);
			
		}

		[TearDown]
		public void RunAfterEverTest()
		{
			if (_testTransform != null)
			{
				Object.DestroyImmediate(_testTransform.gameObject);
			}
		}

		[Test]
		public void WorldPositionShouldMatchConnectedTransformWorldPosition()
		{
			_testTransform.position = new Vector3(11.3f, 10,14.5f);
			Assert.AreEqual(_testNode.WorldPosition, _testTransform.position);
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
