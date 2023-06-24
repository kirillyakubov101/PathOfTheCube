using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EndlessCube.Input
{
	[DefaultExecutionOrder(-1)]
	public class InputManager : MonoBehaviour
	{
		public static InputManager Instance;
		private Controls controls;

		public event Action<Vector2, float> OnStartTouch;
		public event Action<Vector2, float> OnEndTouch;

		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				Destroy(this);
			}

			controls = new Controls();
		}

		private void OnEnable()
		{
			controls.Enable();
			controls.Main.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
			controls.Main.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
		}

		private void OnDisable()
		{
			controls.Disable();
		}

		private void StartTouchPrimary(InputAction.CallbackContext context)
		{
			Vector2 screenPosition = controls.Main.PrimaryPosition.ReadValue<Vector2>();
			Vector3 position = Camera.main.ScreenToViewportPoint(screenPosition);
			float time = (float)context.startTime;

			OnStartTouch?.Invoke(position, time);
		}

		private void EndTouchPrimary(InputAction.CallbackContext context)
		{
			Vector2 screenPosition = controls.Main.PrimaryPosition.ReadValue<Vector2>();
			Vector3 position = Camera.main.ScreenToViewportPoint(screenPosition);
			float time = (float)context.time;

			OnEndTouch?.Invoke(position, time);
		}
	}
}


