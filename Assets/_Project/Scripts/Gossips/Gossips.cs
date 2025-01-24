using UnityEngine;

namespace Ottamind.Gossiper
{
    [CreateAssetMenu(fileName = "Gossips", menuName = "Scriptable Objects/Gossips")]
    public class Gossips : ScriptableObject
    {
        [SerializeField] private string Gossip;
        [SerializeField] private GossipType GossipType;
    }
}
