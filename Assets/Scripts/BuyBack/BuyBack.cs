using UnityEngine;
using EndlessCube.Events;
using EndlessCube.Score;
using TMPro;
using UnityEngine.UI;
using EndlessCube.Core;

namespace EndlessCube.BuyBackOption
{
	public class BuyBack : MonoBehaviour
	{
		[SerializeField] private ShardsCounter shardsCounter = null;
		[SerializeField] private ScoreHandler scoreHandler = null;
		[SerializeField] private float percentOfScore = 0.2f;
		[SerializeField] private TMP_Text buyBackText = null;
		[SerializeField] private Button buyBackBtn = null;

		private int buyBackCost;
		private bool wasUsedOnce = false;

		private void OnEnable()
		{
			CalculateBuyBack();
		}

		private void CalculateBuyBack()
		{
			buyBackCost = (int)(percentOfScore * scoreHandler.Score);

			if (buyBackCost > shardsCounter.GetShards())
			{
				buyBackBtn.interactable = false;
				ShowBuyBackPrice();
			}
			else if(wasUsedOnce)
			{
				buyBackBtn.interactable = false;
				buyBackText.text = "No Buyback!";
			}

			else if(buyBackCost <= shardsCounter.GetShards())
			{
				ShowBuyBackPrice();
			}
		}

		private void ShowBuyBackPrice()
		{
			buyBackText.text = $"Buyback for ({buyBackCost}) Shards";
		}

		public void BuyBackIntoGame()
		{
			wasUsedOnce = true;
			shardsCounter.BuyBackCostReduction(buyBackCost);
			PlayerEvents.Instance.ContinueGame();
			PlayerHealth.Instance.EnableInvisibility();
		}
	}
}


