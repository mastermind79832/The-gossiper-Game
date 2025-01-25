using TMPro;
using Unity.Cinemachine;
using UnityEngine;

namespace Ottamind.Gossiper
{
    public class MenuContrller : MonoBehaviour
    {
        public CinemachineCamera Camera;
        public GameObject Menu;
        public TextMeshProUGUI FollowerCount;

		private void Start()
		{
            FollowerCount.text = PlayerPrefs.GetInt("Followers", 0).ToString();
		}

		public void StartGame()
        {
            Camera.Priority = -1;
            Menu.SetActive(false);
        }
    }
}
