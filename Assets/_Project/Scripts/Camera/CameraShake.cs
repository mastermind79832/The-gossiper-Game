using Ottamind.Gossiper.Core;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

namespace Ottamind.Gossiper
{
    public class CameraShake : MonoSingletonGeneric<CameraShake>
    {

		[SerializeField] private CinemachineBasicMultiChannelPerlin m_MultiChannelPerlin;

        private Coroutine m_ShakingCamera;
        private float m_Time;
        private float m_Ampliture;

		private void Start()
		{
			StopShaking();
		}

		public void Shake(float ampliture, float time)
        {
            StopShaking();

            m_Ampliture = ampliture;
            m_Time = time;
            m_ShakingCamera = StartCoroutine(StartShakingCamera());
        }

        IEnumerator StartShakingCamera()
        {
            EnableShaking();
            yield return new WaitForSeconds(m_Time);
            DisableShaking();
        }

		private void DisableShaking()
		{
			m_MultiChannelPerlin.AmplitudeGain = 0;
		}

		private void EnableShaking()
		{
			m_MultiChannelPerlin.AmplitudeGain = m_Ampliture;
		}

		public void StopShaking()
        {
            if (m_ShakingCamera == null)
                return;

            DisableShaking();
            StopCoroutine(m_ShakingCamera);

        }
	}
}
