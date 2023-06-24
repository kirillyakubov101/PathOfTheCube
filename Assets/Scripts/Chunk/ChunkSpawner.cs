using EndlessCube.Level;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EndlessCube.Pool
{
    public class ChunkSpawner : MonoBehaviour
    {
		[SerializeField] private int chunkAmount = 10;
        [SerializeField] private List<Chunk> chunksPrefabs = new List<Chunk>();


		private void Awake()
		{
			chunksPrefabs = Resources.LoadAll<Chunk>("").ToList();
		}

		private void Start()
		{
			FillRandomChunks();
		}

		private void FillRandomChunks()
		{
			for (int i = 0; i < chunkAmount; i++)
			{
				int randIndex = RandomizeIndex();
				GameObject randomChunk = chunksPrefabs[randIndex].gameObject;
				PoolChunk.Instance.AddChunks(randomChunk);
			}
		}

		private int RandomizeIndex()
		{
			return Random.Range(0, chunksPrefabs.Count);
		}
	}
}


