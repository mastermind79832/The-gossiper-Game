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
            m_SpeechBubble.gameObject.SetActive(false); 
            m_Gossip = null;
        }

		private void Update()
		{
			float dist = Mathf.Abs(Vector3.Distance(transform.position,m_PlayerController.transform.position));
			Debug.Log(dist);
			if ( dist <= m_DetectionRange)// && !CheckIfHidden())
            {

				m_Timer += m_DetectionSpeed * Time.deltaTime;

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
				m_Timer -= m_ReductionSpeed * Time.deltaTime;
				UpdateProgressBar();
			}

		}

		private void Detected()
		{
			m_PlayerController.GetComponent<GossipCollector>().Detected();
		}

		private bool CheckIfHidden()
		{
			bool isHidden = true;

			Debug.Log(m_PlayerController.transform.position);
			RaycastHit2D hit = Physics2D.Raycast(transform.position, (m_PlayerController.transform.position - transform.position).normalized,100f );
			Debug.DrawRay(transform.position,m_PlayerController.transform.position - transform.position);
			//Debug.Log(hit.point);
			if (hit.collider != null && hit.collider.GetComponentInParent<PlayerController>())
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
