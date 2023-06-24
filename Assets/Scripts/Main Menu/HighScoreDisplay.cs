using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreDisplay : MonoBehaviour
{
	[SerializeField] private TMP_Text scoreText = null;

	private void Start()
	{
		scoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
	}
}
