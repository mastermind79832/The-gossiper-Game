using UnityEngine;
using Ottamind.Gossiper.Core;
using UnityEngine.Windows;

namespace Ottamind.Gossiper
{
    public class PlayerController : MonoSingletonGeneric<PlayerController>
    {
        [SerializeField] private float m_MoveSpeed;

        private Vector3 m_Direction;

		public SpriteRenderer m_Renderer;

		private bool m_IsCrouched;
		public bool IsCrouched { get { return m_IsCrouched; } }

		[SerializeField] private Animator m_Animator;	

		private void Start()
		{
			m_Direction = Vector3.zero;
			m_IsCrouched = false;
		}

		void Update()
		{
			GetInput();
			Movement();

		}

		private void Movement()
		{

			if (m_Direction.x > 0)
			{
				m_Renderer.flipX = true;
			}
			else
			{
				m_Renderer.flipX = false;
			}

			if (m_Direction == Vector3.zero)
				m_Animator.SetBool("IsMoveing", false);
			else
			{
				m_Animator.SetBool("IsMoveing", true);
			}
			transform.position += m_MoveSpeed * Time.deltaTime * m_Direction;


		}

		private void GetInput()
		{
			m_Direction.x = UnityEngine.Input.GetAxis("Horizontal");
			m_Direction.y = UnityEngine.Input.GetAxis("Vertical");

			//if(Input.GetKey(KeyCode.LeftControl))
			//{

			//}
		}

	}
}
