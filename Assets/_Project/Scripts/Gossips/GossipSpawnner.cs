using System.Collections.Generic;
using UnityEngine;

namespace Ottamind.Gossiper
{
    public class GossipSpawnner : MonoBehaviour
    {
        [SerializeField] private GossipList m_GossipList;

        [SerializeField] private List<Gossipers> m_GossiperList;
        [SerializeField] private List<Transform> m_SpawnPointList;


		private void Start()
		{
			SpawnGossipers();
		}

		private void SpawnGossipers()
        {
            foreach (Transform spawnPoint in m_SpawnPointList)
            {
                Gossipers gossiper= Instantiate(
                    m_GossiperList[Random.Range(0,m_GossiperList.Count)], 
                    spawnPoint.position, 
                    Quaternion.identity);

                gossiper.Gossip = m_GossipList.Gossips[Random.Range(0,m_GossipList.Gossips.Count)];
            }
        }
	}
}
