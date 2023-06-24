using System.Collections.Generic;
using UnityEngine;

namespace EndlessCube.Pool
{
	public class PoolChunk : MonoBehaviour
	{
		[SerializeField] private Transform chunksParent = null;

		public static PoolChunk Instance { get; private set;}

		private Queue<GameObject> chunks = new Queue<GameObject>();

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


		public void AddChunks(GameObject chunkPrefab)
		{
			var newChunk = Instantiate(chunkPrefab);
			newChunk.transform.SetParent(chunksParent);
			newChunk.SetActive(false); //just have them as not active
			chunks.Enqueue(newChunk);
		}

		public GameObject GetChunk()
		{
			return chunks.Dequeue();
		}

		public void ReturnToPull(GameObject objectToReturn)
		{
			objectToReturn.SetActive(false);
			chunks.Enqueue(objectToReturn);
		}
	}
}


