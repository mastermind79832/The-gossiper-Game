using Ottamind.Gossiper.Core;
using UnityEngine;

namespace Ottamind.Gossiper.Persistant
{
    /// <summary>
    /// locator for all scripts in the persistant scene
    /// </summary>
    public class PersistantServiceLocator : MonoSingletonGeneric<PersistantServiceLocator>
    {
        [SerializeField] private SceneService m_SceneService;
        public SceneService SceneService { get { return m_SceneService; } }

        [SerializeField] private Camera m_Camera;
        public Camera Camera { get { return m_Camera;} }

		override protected void Awake()
		{
            base.Awake();
			Application.targetFrameRate = 90;

		}

	}
}
