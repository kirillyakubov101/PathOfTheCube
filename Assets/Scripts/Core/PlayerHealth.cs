using EndlessCube.Events;
using System.Collections;
using UnityEngine;

namespace EndlessCube.Core
{
	public class PlayerHealth : MonoBehaviour
	{
		[SerializeField] private Material m_FullLivesMat;
        [SerializeField] private Material m_TwoLivesMat;
        [SerializeField] private Material m_OneLifeMat;
		[SerializeField] private MeshRenderer m_Renderer;

        private int currentHealth;
		private readonly int maxHealth = 3;

		public static PlayerHealth Instance;

        private void Awake()
        {
            if(Instance == null) { Instance = this; }
			else
			{
				Destroy(Instance);
			}

        }

        private bool PostAdInvisibility = false;
	

		private void Start()
		{
			currentHealth = maxHealth;
		}

		public int CurrentHealth 
		{ 
			get => currentHealth;
			set
			{
                if (PostAdInvisibility) { return; }
                if (currentHealth == 1)
				{
					PlayerEvents.Instance.DeathBlow();
				}

				else
				{
					currentHealth -= value;
					ChangeLivesMat();

                }
			}
		}

		public void EnableInvisibility()
		{
			StartCoroutine(StartInvinisibility());
		}

		private IEnumerator StartInvinisibility()
		{
			float timer = 0f;
			PostAdInvisibility = true;
            currentHealth = maxHealth;
			ChangeLivesMat();

            while (timer < 2.2f)
			{
                timer += Time.deltaTime;
                yield return null;
			}
			PostAdInvisibility = false;

        }

		private void ChangeLivesMat()
		{
			Material[] tempMats = m_Renderer.materials;

            switch (currentHealth)
			{
				case 0:
				case 1:
					tempMats[1] = m_OneLifeMat; break;
				case 2:
                    tempMats[1] = m_TwoLivesMat; break;
				case 3:
                    tempMats[1] = m_FullLivesMat; break;

            }

			m_Renderer.materials = tempMats;


        }
	}
}


