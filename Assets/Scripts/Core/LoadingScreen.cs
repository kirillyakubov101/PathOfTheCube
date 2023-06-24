using EndlessCube.Core;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
	[SerializeField] GameObject screen = null;
	[SerializeField] float loadingTime = 0.1f;
	[SerializeField] CanvasGroup canvasGroup = null;

	private void OnEnable()
	{
		SceneManager.sceneLoaded += StartGame;
	}


	private void OnDisable()
	{
		SceneManager.sceneLoaded -= StartGame;
	}

	private void StartGame(Scene scene, LoadSceneMode mode)
	{
		StartCoroutine(StartGameProcess());
	}

	private IEnumerator StartGameProcess()
	{
		while(canvasGroup.alpha > 0f)
		{
			canvasGroup.alpha -= Time.deltaTime * loadingTime;
			yield return null;
		}
		yield return null;
		PlayerMovement.hasGameStarted = true;
		screen.SetActive(false);
	}
    
}
