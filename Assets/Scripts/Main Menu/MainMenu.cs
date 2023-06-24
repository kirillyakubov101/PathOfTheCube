using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using EndlessCube.Ads;
using TMPro;
using EndlessCube.BuyBackOption;

namespace EndlessCube.SceneControl
{
	public class MainMenu : MonoBehaviour
	{
		[SerializeField] private Slider progressSlider = null;
		[SerializeField] private GameObject loadingScreen = null;
		[SerializeField] private TMP_Text loadingPercent = null;
		[SerializeField] private BuyBack buyBack = null;

		public void BuyBackContinue()
		{
			buyBack.BuyBackIntoGame();
		}

		public void ContinueGame()
		{
			AdManager.instance.PlayRewardedAdd();
        }

		public void LoadScene(string sceneName)
		{
			Time.timeScale = 1f;
			StartCoroutine(LoadYourAsyncScene(sceneName));
		}

		private IEnumerator LoadYourAsyncScene(string sceneName)
		{
			loadingScreen.SetActive(true);
			AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

			while (!operation.isDone)
			{
				float progress = Mathf.Clamp01(operation.progress / 0.9f);
				progressSlider.value = progress;
				int progressPercent = Mathf.FloorToInt(progress) * 100;
				loadingPercent.text = $"{progressPercent} %";
				yield return null;
				
			}
		}

		public void QuitGame()
		{
			Application.Quit();
		}
	}
}

