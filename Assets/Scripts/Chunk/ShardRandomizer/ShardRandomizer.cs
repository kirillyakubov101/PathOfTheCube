using EndlessCube.Collision;
using UnityEngine;

public class ShardRandomizer : MonoBehaviour
{
	[SerializeField] private Shard[] shardsLeft;
	[SerializeField] private Shard[] shardsRight;

	private void OnEnable()
	{
		ShowShards();
	}

	private void OnDisable()
	{
		HideAllShards();
	}

	private void ShowShards()
	{
		int rand = Random.Range(0, 2);
		if(rand == 1)
		{
			ShowRandomArray(shardsLeft);
		}

		else
		{
			ShowRandomArray(shardsRight);
		}
	}

	private void HideAllShards()
	{
		foreach(Transform child in transform)
		{
			child.gameObject.SetActive(false);
		}
	}

	private void ShowRandomArray(Shard[] array)
	{
		foreach(var child in array)
		{
			child.gameObject.SetActive(true);
		}
	}




}
