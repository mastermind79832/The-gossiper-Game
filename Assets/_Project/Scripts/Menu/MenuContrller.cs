using Unity.Cinemachine;
using UnityEngine;

namespace Ottamind.Gossiper
{
    public class MenuContrller : MonoBehaviour
    {
        public CinemachineCamera Camera;
        public GameObject Menu;

        public void StartGame()
        {
            Camera.Priority = -1;
            Menu.SetActive(false);
            PlayerController.Instance.CanMove = true;
        }
    }
}
