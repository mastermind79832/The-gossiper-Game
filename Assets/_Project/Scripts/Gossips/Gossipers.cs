using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Ottamind.Gossiper
{
    public class Gossipers : MonoBehaviour
    {
        [SerializeField] private Gossips m_Gossip;
        public Gossips Gossip { get { return m_Gossip; } set { m_Gossip = value; } }

        [SerializeField] private float m_CaptureTime;
        public float CaptureTime {  get { return m_CaptureTime; } }

        [SerializeField] private Transform m_SpeechBubble;

        private PlayerController m_PlayerController;

		private float m_Timer;

		[SerializeField] private Image m_ProgressBar;
        [SerializeField] private float m_DetectionRange;
		[SerializeField] private float m_DetectionSpeed;
		[SerializeField] private float m_ReductionSpeed;

		private void Start()
		{
			m_Timer = 0;
			UpdateProgressBar();
			m_PlayerController = PlayerController.Instance;
		}

		public void GetGossip( )
		{
			m_SpeechBubble.transform.DOMove(m_PlayerController.transform.position, 1f);
			Invoke(nameof(DelayDisable),1f);			
			m_Gossip = null;
		}

		private void DelayDisable()
		{
			m_SpeechBubble.gameObject.SetActive(false);
		}

		private void FixedUpdate()
		{
			float dist = Mathf.Abs(Vector2.Distance(transform.position,m_PlayerController.transform.position));
			Debug.Log(dist);
			if ( dist <= m_DetectionRange && !CheckIfHidden())
            {

				m_Timer += m_DetectionSpeed * Time.fixedDeltaTime;

				if (m_Timer >= 10)
				{
					m_Timer = 0f;
					Detected();
					UpdateProgressBar();
				}

				UpdateProgressBar();
			}
			else if (m_Timer >= 0)
			{
				m_Timer -= m_ReductionSpeed * Time.fixedDeltaTime;
				UpdateProgressBar();
			}

		}

		private void Detected()
		{
			//m_SpeechBubble.transform.DOMove(m_PlayerController.transform.position, 1f);
			m_PlayerController.GetComponentInChildren<GossipCollector>().Detected();
		}

		private bool CheckIfHidden()
		{
			bool isHidden = true;
			Vector2 dir = (m_PlayerController.transform.position - transform.position).normalized;

			RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 100f);
			Debug.Log(dir);
			Debug.DrawRay(transform.position,dir * 100f, Color.red);

			if (hit.collider != null && hit.collider.GetComponent<PlayerController>())
			{
				Debug.Log($"hit {hit.collider.name}");
				isHidden = false;
			}

			return isHidden;
		}

		private void UpdateProgressBar()
		{
			m_ProgressBar.fillAmount = m_Timer / 10;
		}

	}
}
