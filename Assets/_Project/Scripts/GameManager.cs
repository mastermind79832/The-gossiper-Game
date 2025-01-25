using System;
using TMPro;
using UnityEngine;

namespace Ottamind.Gossiper
{
    public class GameManager : MonoBehaviour
    {
        public MenuContrller menu;
        public GameOverMenu gameOverMenu;
		public GameObject gameplayCanvas;

		public float TimeLimit;
		public TextMeshProUGUI timeDisplay;
		private float timer;
		private bool isTimerRun;

		public GossipTypeList GossipList;

		public void Start()
		{
			PlayerController.Instance.CanMove = false;
		}

		public void StartGame()
		{
			PlayerController.Instance.CanMove = true;
			timer = TimeLimit;
			menu.StartGame();
			isTimerRun = true;
			gameplayCanvas.SetActive(true);
		}

		public void Update()
		{

			if(!isTimerRun) return;

			timer -= Time.deltaTime;
			
			timeDisplay.text = timer.ToString();

			if (timer <= 0)
			{
				GameOver();
				isTimerRun = false;
			}
			
		}

		private void GameOver()
		{
			PlayerController.Instance.CanMove = false;
			isTimerRun=false;
			var gossips = PlayerController.Instance.gossipCollector.m_CapturedGossips;
			gameplayCanvas.SetActive(true);

			int blehCount = 0;
			int okayCount = 0;
			int niceCount = 0;
			int juicyCount = 0;
			int gain = 0;

			foreach (var gossip in gossips)
			{
				int score = GossipList.GetScore(gossip.GossipType);
				gain += score;
				switch (gossip.GossipType)
				{
					case GossipType.Bleh: blehCount++; break;
						case GossipType.Okaay: okayCount++; break;
						case GossipType.Nice: niceCount++; break;
						case GossipType.Juicy: juicyCount++; break;
				}
			}



			gameOverMenu.GameOver(blehCount, okayCount, niceCount, juicyCount, gain);
		}
	}
}
