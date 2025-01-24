using UnityEngine;

namespace Ottamind.Gossiper
{
    public class Gossipers : MonoBehaviour
    {
        [SerializeField] private Gossips m_Gossip;
        public Gossips Gossip { get { return m_Gossip; } }

        [SerializeField] private float m_CaptureTime;
        public float CaptureTime {  get { return m_CaptureTime; } }

        [SerializeField] private Transform m_SpeechBubble; 

        public void GetGossip( )
        {
            m_SpeechBubble.gameObject.SetActive(false); 
            m_Gossip = null;
        }
    }
}
