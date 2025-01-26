using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace Ottamind.Gossiper
{
    public class Patroling : MonoBehaviour
    {
        public List<Transform> Points = new List<Transform>();
		public float moveSpeed;

		private int currentIndex;
		private int dir;

		private void Start()
		{
			currentIndex = 1;
			transform.position = Points[0].position;
			dir = 1;
		}
		private void Update()
		{
			transform.position = Vector3.MoveTowards(transform.position, Points[currentIndex].position, moveSpeed * Time.deltaTime);

			if (transform.position == Points[currentIndex].position)
			{
				if (currentIndex + 1 >= Points.Count)
				{
					dir = -1;
				}
				if (currentIndex - 1 < 0)
				{
					dir = 1;
				}
				currentIndex += dir;
			}
		}
	}
}
