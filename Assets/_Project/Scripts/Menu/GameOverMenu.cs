using TMPro;
using UnityEngine;

namespace Ottamind.Gossiper
{
    public class GameOverMenu : MonoBehaviour
    {
        public GameObject GameOverCanvas;

        public TextMeshProUGUI BlehCount;
        public TextMeshProUGUI OkayCount;
        public TextMeshProUGUI NiceCoount;
        public TextMeshProUGUI JuicyCoount;

        public TextMeshProUGUI FollowersGain;
        public TextMeshProUGUI Followers;


        public void GameOver(int blehCount, int okayCount, int niceCount, int juicyCount, int gain)
        {
            GameOverCanvas.SetActive(false);

            BlehCount.text = blehCount.ToString();
			OkayCount.text = okayCount.ToString();
			NiceCoount.text = niceCount.ToString();
			JuicyCoount.text = juicyCount.ToString();

            FollowersGain.text = gain.ToString();

            int followers = PlayerPrefs.GetInt("Followers",0);
            followers += gain;

			PlayerPrefs.SetInt("Followers", followers);
        }
    }
}
