using System.Collections;
using UnityEngine;
using EndlessCube.Pool;

namespace EndlessCube.Level
{
	public class Chunk : MonoBehaviour
	{
		[SerializeField] private Transform spawnPoint = null;
		[SerializeField] private float selfDisableTime = 2f;
		[SerializeField] private MeshRenderer groundMaterial = null;
		
		private Coroutine currentCoroutine;

		public MeshRenderer GroundMaterial { get=> groundMaterial; set => groundMaterial = value; }

		private void OnTriggerEnter(Collider other)
		{
			if(other.CompareTag("Player"))
			{
				if(currentCoroutine != null)
				{
					StopCoroutine(currentCoroutine);
				}
				currentCoroutine = StartCoroutine(ReturnToPullProcess());
				var newChunk =  PoolChunk.Instance.GetChunk();
				newChunk.transform.position = spawnPoint.position;
				newChunk.SetActive(true);
			}
			
		}

		private IEnumerator ReturnToPullProcess()
		{
			yield return new WaitForSeconds(selfDisableTime);
			
			PoolChunk.Instance.ReturnToPull(this.gameObject);
		}

		
	}
}


