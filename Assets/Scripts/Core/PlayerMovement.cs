using EndlessCube.Events;
using System.Collections;
using UnityEngine;

namespace EndlessCube.Core
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private float forwardForce = 10f;
		[SerializeField] private float smoothMoveRoutine = 0.7f;

		public static bool hasGameStarted = false;
		private const float MIN_HORIZONTAL_BOUND = -4F;
		private const float MAX_HORIZONTAL_BOUND = 4F;

		private float inputX = 0f;
		private Vector3 temp;
		private Coroutine HorizontalMoveCoroutine;
		private Animator animator;
		private bool canJump = true;
		private bool canSlide = true;

		private readonly int jumpHash = Animator.StringToHash("jump");
        private readonly int slideHash = Animator.StringToHash("slide");

		private PlayerEvents m_playerEvents;

        private void Awake()
		{
			animator = GetComponent<Animator>();
            m_playerEvents = GetComponent<PlayerEvents>();

        }

		private void Update()
		{
			if (!hasGameStarted) { return; }
			transform.Translate(transform.forward * forwardForce * Time.deltaTime);
		}

		private IEnumerator MovePlayer()
		{
			Vector3 tempPos = Vector3.zero;
			while(transform.position.x != temp.x)
			{
				Vector3 desiredPosition = new Vector3(temp.x, transform.position.y, transform.position.z);
				transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothMoveRoutine * Time.deltaTime);
                tempPos = desiredPosition;
                yield return null;
			}

			transform.position = tempPos;

        }

		public void SetHorizontalInput(float inputX)
		{
			if (!hasGameStarted) { return; }
			if (inputX == 2 && this.inputX == 4) { return; }
			if (inputX == -2 && this.inputX == -4) { return; }

			this.inputX += inputX;
			this.inputX = Mathf.Clamp(this.inputX, MIN_HORIZONTAL_BOUND, MAX_HORIZONTAL_BOUND);
			temp = transform.position;
			temp.x = this.inputX;

			if (HorizontalMoveCoroutine != null)
			{
				StopCoroutine(HorizontalMoveCoroutine);
			}

			HorizontalMoveCoroutine = StartCoroutine(MovePlayer());
		}

		public void Jump()
		{
			if (!hasGameStarted) { return; }
			if (!canJump) { return; }
			canSlide = false;
            animator.ResetTrigger(jumpHash);
			animator.SetTrigger(jumpHash);
			m_playerEvents.JumpEvent();

        }

		public void Slide()
		{
            if (!hasGameStarted) { return; }
            if (!canSlide) { return; }
            canJump = false;
            animator.ResetTrigger(slideHash);
            animator.SetTrigger(slideHash);
            m_playerEvents.SlideEvent();
        }

		public void CannotSlide()
		{
            canSlide = false;
            canJump = false;
        }

		public void CanSlide()
		{
			canSlide = true;
			canJump = true;

        }
		
		public void CanJump()
		{
			canJump = true;
            canSlide = true;
        }

		public void CannotJump()
		{
			canJump = false;
            canSlide = false;
        }

		public void GameOver()
		{
			Time.timeScale = 0f;
			hasGameStarted = false;
		}

		public void ContinueGame()
		{
			Time.timeScale = 1f;
			hasGameStarted = true;
		}


	}
}

