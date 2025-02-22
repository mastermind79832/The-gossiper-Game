using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ottamind.Gossiper.Persistant
{
    public class CoinDataManager
    {
		private const string STR_COINS = "Coins";

		[SerializeField] private int m_Coins;
		public int Coins { get { return m_Coins; } }

		public event Action<int> OnCoinsChanged;

		public void SaveCoins(int coins)
		{
			m_Coins += coins;
			PlayerPrefs.SetInt(STR_COINS, m_Coins);
			OnCoinsChanged?.Invoke(m_Coins);
		}

		public void NewInstall()
		{
			SaveCoins(0);
		}

		public void Initialize()
		{
			m_Coins = PlayerPrefs.GetInt(STR_COINS);
		}
	}
}
