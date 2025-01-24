using UnityEngine;

namespace Ottamind.Gossiper
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float m_MoveSpeed;

        private Vector3 m_Direction;
		private void Start()
		{
			m_Direction = Vector3.zero;
		}

		void Update()
		{
			Input();
			Movement();

		}

		private void Movement()
		{
			transform.position += m_MoveSpeed * m_Direction * Time.deltaTime;
		}

		private void Input()
		{
			m_Direction.x = UnityEngine.Input.GetAxis("Horizontal");
			m_Direction.y = UnityEngine.Input.GetAxis("Vertical");
		}

	}
}
