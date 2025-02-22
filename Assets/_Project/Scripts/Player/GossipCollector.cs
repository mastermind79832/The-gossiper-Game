using System;
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

		public List<Gossips> m_CapturedGossips;

		[SerializeField] private Image m_ProgressBar;
		private void Start()
		{
			m_Timer = 0;
			m_CapturedGossips = new List<Gossips>();
		}

		private void Update()
		{
			if (m_StartCapture)
			{
				m_Timer += m_CaptureSpeed * Time.deltaTime;

				if (m_Timer >= m_CurrentGossiper.CaptureTime)
				{
					m_Timer = 0f;
					UpdateProgressBar();
					m_StartCapture = false;
					m_CapturedGossips.Add(m_CurrentGossiper.Gossip);
					m_CurrentGossiper.GetGossip();
					m_CurrentGossiper = null;
				}

				UpdateProgressBar();
			}
			else if(m_Timer >= 0)
			{
				m_Timer -= m_ReduceSpeed * Time.deltaTime;
				UpdateProgressBar();
			}

			//progress bar update
		}

		private void UpdateProgressBar()
		{
			if (!m_CurrentGossiper)
				return;
			m_ProgressBar.fillAmount = m_Timer / m_CurrentGossiper.CaptureTime;
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

		internal void Detected()
		{
			if (m_CapturedGossips.Count > 0)
				m_CapturedGossips.RemoveAt(UnityEngine.Random.Range(0, m_CapturedGossips.Count));

			m_Timer = 0;
			UpdateProgressBar();
			CameraShake.Instance.Shake(2, 0.5f);
		}
	}
}
