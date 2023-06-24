using System.Collections.Generic;
using UnityEngine;

public class ObsRandomizer : MonoBehaviour
{
	private List<GameObject> obstacleList = new List<GameObject>();
	private List<GameObject> obstaclesToShow = new List<GameObject>();

	private int showAmount = 0;

	private void Awake()
	{
		PopulateList();	
	}

	private void OnEnable()
	{
		RandomzieShowCount();
		ShowRandomObs();
	}

	private void RandomzieShowCount()
	{
		showAmount = Random.Range(1, obstacleList.Count);
	}

	private void PopulateList()
	{
		foreach (Transform child in transform)
		{
			obstacleList.Add(child.gameObject);
			child.gameObject.SetActive(false);
		}
	}

	private void ShowRandomObs()
	{
		int showedObstacles = 0;
		obstaclesToShow.Clear();

		//hide all
		foreach (Transform child in transform)
		{
			child.gameObject.SetActive(false);
		}

		while (showedObstacles < showAmount)
		{
			int chosenObstacleIndex = Random.Range(0, obstacleList.Count);
			var chosenObstacle = obstacleList[chosenObstacleIndex];
			if (!obstaclesToShow.Contains(chosenObstacle))
			{
				showedObstacles++;
				obstaclesToShow.Add(chosenObstacle);
			}
		}

		foreach(GameObject child in obstaclesToShow)
		{
			child.SetActive(true);
		}
	}

	

}
