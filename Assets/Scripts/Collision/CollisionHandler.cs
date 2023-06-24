using EndlessCube.Events;
using UnityEngine;

namespace EndlessCube.Collision
{
	public class CollisionHandler : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Hazard"))
			{
				PlayerEvents.Instance.TakeHit();
				other.gameObject.SetActive(false);
			}
			else if(other.CompareTag("Shard"))
			{
				PlayerEvents.Instance.CollectShard();
				other.GetComponent<Shard>().GetHit();
			}

		}
	}
}

