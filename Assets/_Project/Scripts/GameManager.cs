using System;
using TMPro;
using UnityEngine;

namespace Ottamind.Gossiper
{
    public class GameManager : MonoBehaviour
    {
        public MenuContrller menu;
        public GameOverMenu gameOverMenu;

		public float TimeLimit;
		public TextMeshProUGUI timeDisplay;
		private float timer;
		private bool isTimerRun;

		public void Start()
		{
			PlayerController.Instance.CanMove = false;
		}

		public void StartGame()
		{
			PlayerController.Instance.CanMove = true;
			timer = TimeLimit;
			menu.StartGame();
		}

		public void Update()
		{

			if(!isTimerRun) return;

			timer -= Time.deltaTime;

			if (timer <= 0)
			{
				GameOver();
				isTimerRun = false;
			}
			
		}

		private void GameOver()
		{
			PlayerController.Instance.CanMove = false;
			var gossips = PlayerController.Instance.gossipCollector.m_CapturedGossips;

			//int blehcount = Array.FindAll()
			//gameOverMenu.GameOver();
		}
	}
}
