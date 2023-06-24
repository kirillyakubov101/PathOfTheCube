using System;
using UnityEngine;
using EndlessCube.Core;

namespace EndlessCube.Input
{
	public class SwipeHandler : MonoBehaviour
	{
		[SerializeField] private Vector3 direction;
		[SerializeField] private Vector2 direction2D;
		[SerializeField] private float minimumDistance = 0.2f;
		[SerializeField] private float maximumTime = 1f;
		[SerializeField, Range(0, 1)] private float directionThreshold = 0.9f;
        [SerializeField, Range(0, 1)] private float bottomThreshold = 0.75f;


        private Vector2 startPos, endPos;
		private float startTime, endTime;
		private PlayerMovement player;

		private void Awake()
		{
			player = FindObjectOfType<PlayerMovement>();
		}


		private void OnEnable()
		{
			InputManager.Instance.OnStartTouch += SwipeStart;
			InputManager.Instance.OnEndTouch += SwipeEnd;
		}

		private void OnDisable()
		{
			InputManager.Instance.OnStartTouch -= SwipeStart;
			InputManager.Instance.OnEndTouch -= SwipeEnd;
		}

		private void SwipeStart(Vector2 pos, float time)
		{
			startTime = time;
			startPos = pos;

		}

		private void SwipeEnd(Vector2 pos, float time)
		{
			endTime = time;
			endPos = pos;
			DetectSwipe();
		}

		private void DetectSwipe()
		{
			if (Vector3.Distance(startPos, endPos) >= minimumDistance && (endTime - startTime) <= maximumTime)
			{
				direction = endPos - startPos;
				direction2D = new Vector2(direction.x, direction.y).normalized;
				SwipeDirection(direction2D);
			}

		}

		private void SwipeDirection(Vector2 direction2D)
		{
			if (Vector2.Dot(Vector2.up, direction2D) > directionThreshold)
			{
				player.Jump();
			}

			else if (Vector2.Dot(Vector2.right, direction2D) > directionThreshold)
			{
				player.SetHorizontalInput(2);
			}

			else if (Vector2.Dot(Vector2.left, direction2D) > directionThreshold)
			{
				player.SetHorizontalInput(-2);
			}

			else if(Vector2.Dot(Vector2.down, direction2D) > bottomThreshold)
			{
				player.Slide();

            }

		}
	}
}


