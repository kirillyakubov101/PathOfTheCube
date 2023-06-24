using TMPro;
using UnityEngine;

namespace EndlessCube.BuyBackOption
{
	public class ShardsCounter : MonoBehaviour
	{
		[SerializeField] TMP_Text shardsText = null;

		private int shardsAmount = 0;

		public void IncrementShardsCount()
		{
			shardsAmount++;
			shardsText.text = shardsAmount.ToString();
		}

		public int GetShards()
		{
			return shardsAmount;
		}

		public void BuyBackCostReduction(int amount)
		{
			shardsAmount -= amount;
			shardsText.text = shardsAmount.ToString();
		}
	}
}


