using System.Collections;
using UnityEngine;
using EndlessCube.Level;
using System;

namespace EndlessCube.ColorHandler
{
	public class ColorManager : MonoBehaviour
	{
		[Header("Colors")]
		[SerializeField] private Color32[] backgroundColors = null;
		[SerializeField] private Color32[] groundColors = null;
		[SerializeField] private Color32[] obstacleColors = null;

		[Header("Params")]
		[SerializeField] private float smoothTime = 7f;
		[SerializeField] private Transform chunksParent = null;
		
		private int colorIndex = -1;
		private Coroutine current;
		private bool firstIteration = true;
		private Chunk[] chunks;
		private Color32 newGroundColor;

		public static event Action<Color32> OnColorChangeObstacle;


		public void WorldColorChange()
		{	
			//the array will fill only once
			if(firstIteration)
			{
				firstIteration = false;
				chunks = chunksParent.GetComponentsInChildren<Chunk>(true);
			}

			colorIndex++;

			//refresh index
			if (colorIndex >= backgroundColors.Length) { colorIndex = 0; }

			//refresh coroutine
			if(current != null)
			{
				StopCoroutine(current);
			}

			current = StartCoroutine(ChangeColorProcess());

		}

		private IEnumerator ChangeColorProcess()
		{
			float processTime = 0f;
			while(processTime <= 2f)
			{
				processTime += Time.deltaTime;

				SetBackgroundFogColor();
				SetChunksColor();
				OnColorChangeObstacle?.Invoke(obstacleColors[colorIndex]);
				yield return null;
			}
		}

		private void SetBackgroundFogColor()
		{
			Camera.main.backgroundColor = Color32.Lerp(Camera.main.backgroundColor, backgroundColors[colorIndex], Time.deltaTime * smoothTime);
			RenderSettings.fogColor = Color32.Lerp(RenderSettings.fogColor, backgroundColors[colorIndex], Time.deltaTime * smoothTime);
		}

		private void SetChunksColor()
		{
			foreach (Chunk ele in chunks)
			{
				newGroundColor = Color32.Lerp(ele.GroundMaterial.material.color, groundColors[colorIndex], Time.deltaTime * smoothTime);
				ele.GroundMaterial.material.SetColor("_BaseColor", newGroundColor);
			}
		}

	}
}


