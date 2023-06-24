using UnityEngine;
using Cinemachine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
	[SerializeField] private CinemachineVirtualCamera followCamera = null;
	[SerializeField] private float intensity;
	[SerializeField] private float shakeTime;

	private Coroutine currentCoroutine;

	//Unity event call
	public void ShakeCamera()
	{
		if (currentCoroutine != null)
		{
			StopCoroutine(currentCoroutine);
		}

		currentCoroutine = StartCoroutine(Shake());
	}

	private IEnumerator Shake()
	{
		CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannel = followCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
		cinemachineBasicMultiChannel.m_AmplitudeGain = intensity;

		yield return new WaitForSeconds(shakeTime);

		cinemachineBasicMultiChannel.m_AmplitudeGain = 0f;
	}
}
