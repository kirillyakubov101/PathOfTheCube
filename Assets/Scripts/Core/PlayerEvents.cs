using UnityEngine;
using UnityEngine.Events;

namespace EndlessCube.Events
{
	public class PlayerEvents : MonoBehaviour
	{
		[SerializeField] private UnityEvent OnCollision = null;
		[SerializeField] private UnityEvent OnDeath = null;
		[SerializeField] private UnityEvent onContinue = null;
		[SerializeField] private UnityEvent OnColorChange = null;
		[SerializeField] private UnityEvent OnShardCollect = null;
		[SerializeField] private UnityEvent onJump = null;
        [SerializeField] private UnityEvent onSlide = null;

        public static PlayerEvents Instance = null;

		private void Awake()
		{
			if(Instance == null)
			{
				Instance = this;
			}
			else
			{
				Destroy(this);
			}
		}

		private void Start()
		{
			Application.targetFrameRate = 60;
		}

		public void TakeHit()
		{
			OnCollision?.Invoke();
		}

		public void DeathBlow()
		{
			OnDeath?.Invoke();
		}

		public void ContinueGame()
		{
			onContinue?.Invoke();
		}

		public void ChangeColor()
		{
			OnColorChange?.Invoke();
		}

		public void CollectShard()
		{
			OnShardCollect?.Invoke();
		}

		public void JumpEvent()
		{
			onJump?.Invoke();

        }

		public void SlideEvent()
		{
			onSlide?.Invoke();
		}
	}
}


