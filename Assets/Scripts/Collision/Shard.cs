using System.Collections;
using UnityEngine;

namespace EndlessCube.Collision
{
    public class Shard : MonoBehaviour
    {
        [SerializeField] private Transform centerPoint = null;
        [SerializeField] private float rotationSpeed = 2f;
        [SerializeField] private MeshRenderer meshRenderer = null;
        [SerializeField] private int points = 10;

        private Coroutine current;
        private bool firstIteration = true;

		private void Awake()
		{
            firstIteration = false;
        }

		private void Start()
        {
            current = StartCoroutine(RotateSelf());
            
        }

		private void OnEnable()
		{
            if(!firstIteration)
			{
                meshRenderer.enabled = true;
            }
           
           

            if (current != null)
			{
                StopCoroutine(current);
                current = StartCoroutine(RotateSelf());
            }
           else
			{
                current = StartCoroutine(RotateSelf());
                
            }

        }

		private IEnumerator RotateSelf()
		{
            while(true)
			{
                transform.RotateAround(centerPoint.position, Vector3.up, Time.deltaTime * rotationSpeed);
                yield return null;
			}
		}

		public void GetHit()
		{
            meshRenderer.enabled = false;
        }


      
		
    }
}

