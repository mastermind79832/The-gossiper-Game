using UnityEngine;

namespace Ottamind.Gossiper
{
    [CreateAssetMenu(fileName = "Gossips", menuName = "Scriptable Objects/Gossips")]
    public class Gossips : ScriptableObject
    {
        public string Gossip;
        public GossipType GossipType;
    }
}
