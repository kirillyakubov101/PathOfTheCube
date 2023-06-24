using EndlessCube.Core;
using TMPro;
using UnityEngine;
using EndlessCube.Events;

namespace EndlessCube.Score
{
	public class ScoreHandler : MonoBehaviour
	{
		[SerializeField] TMP_Text scoreText = null;
		[SerializeField] float scoreMultipler = 5f;
		[SerializeField] private int scoreCheckpoint = 100;

		private float score;
		private int startCheckpoint;
		//private Coroutine current;

		public float Score { get => score; }

		public const string HIGHSCORE_KEY = "HighScore";

		

		private void Start()
		{
			startCheckpoint = scoreCheckpoint;
			//current = StartCoroutine(ScoreUpdate());
		}

		//private IEnumerator ScoreUpdate()
		//{
		//	while(true)
		//	{
		//		UpdateScore();
		//		UpdateScoreCheckpoint();
		//		yield return null;
		//	}
		//}

		private void Update()
		{
			if (!PlayerMovement.hasGameStarted) { return; }

			UpdateScore();
			UpdateScoreCheckpoint();
		}

		private void UpdateScoreCheckpoint()
		{
			if (Mathf.FloorToInt(score) >= scoreCheckpoint)
			{
				scoreCheckpoint += startCheckpoint;
				PlayerEvents.Instance.ChangeColor();
			}
		}

		private void UpdateScore()
		{
			score += Time.deltaTime * scoreMultipler;
			scoreText.text = Mathf.FloorToInt(score).ToString();
		}

		private void OnDestroy()
		{
			int currentHighScore = PlayerPrefs.GetInt(HIGHSCORE_KEY, 0);
			if (score > currentHighScore)
			{
				PlayerPrefs.SetInt(HIGHSCORE_KEY, Mathf.FloorToInt(score));
			}
		}
	}
}


