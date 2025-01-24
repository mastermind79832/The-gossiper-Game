using System.Collections.Generic;
using UnityEngine;

namespace Ottamind.Gossiper
{
    [CreateAssetMenu(fileName = "GossipList", menuName = "Scriptable Objects/GossipList")]
    public class GossipList : ScriptableObject
    {
        public List<Gossips> Gossips;
    }
}
