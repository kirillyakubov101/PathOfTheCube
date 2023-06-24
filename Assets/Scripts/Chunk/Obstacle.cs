using EndlessCube.ColorHandler;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	private MeshRenderer meshRenderer;

	private void Awake()
	{
		meshRenderer = GetComponent<MeshRenderer>();
	}

	private void OnEnable()
	{
		ColorManager.OnColorChangeObstacle += ChangeColor;
	}

	private void OnDisable()
	{
		ColorManager.OnColorChangeObstacle -= ChangeColor;
	}

	private void ChangeColor(Color32 newColor)
	{
		meshRenderer.material.SetColor("_BaseColor", newColor);
	}
}
