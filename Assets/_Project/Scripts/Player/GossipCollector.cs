using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ottamind.Gossiper
{
    public class GossipCollector : MonoBehaviour
    {
        [SerializeField] private float m_Radius;
		[SerializeField] private float m_CaptureSpeed;
		[SerializeField] private float m_ReduceSpeed;
		private bool m_StartCapture;

		private float m_Timer;
		private Gossipers m_CurrentGossiper;

		[SerializeField] private List<Gossips> m_CapturedGossips;

		[SerializeField] private Image m_ProgressBar;

		private void Update()
		{
			if (m_StartCapture)
			{
				m_Timer += m_CaptureSpeed * Time.deltaTime;

				if (m_Timer >= m_CurrentGossiper.CaptureTime)
				{
					m_Timer = 0f;
					m_ProgressBar.fillAmount = m_Timer / m_CurrentGossiper.CaptureTime;
					m_StartCapture = false;
					m_CapturedGossips.Add(m_CurrentGossiper.Gossip);
					m_CurrentGossiper.GetGossip();
					m_CurrentGossiper = null; 
				}

				m_ProgressBar.fillAmount = m_Timer/m_CurrentGossiper.CaptureTime;
			}
			else if(m_Timer >= 0)
			{
				m_Timer -= m_ReduceSpeed * Time.deltaTime;
				m_ProgressBar.fillAmount = m_Timer / m_CurrentGossiper.CaptureTime;
			}

			//progress bar update
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.TryGetComponent(out Gossipers gossipers))
			{
				if (gossipers.Gossip == null)
					return;


				if (m_CurrentGossiper != gossipers)
				{
					m_CurrentGossiper = gossipers;
					m_Timer = 0;
				}	
				m_StartCapture = true;
			}
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			m_StartCapture = false;
		}

		
	}
}
