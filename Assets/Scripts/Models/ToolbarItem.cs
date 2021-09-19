using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    public class ToolbarItem : MonoBehaviour
    {
        [SerializeField] private GameObject itemPrefab;
        private List<GameObject> items = new List<GameObject>();

        public void Repaint(float value)
        {
            var count = (int)(value / 10);
            if (count > items.Count)
            {
                var length = count - items.Count;
                for (var i = items.Count; i <= length; i++)
                {
                    items.Add(Instantiate(itemPrefab, transform.position + transform.right * transform.localScale.x * 1.1f * i, transform.rotation,
                        transform));
                }
            }
            else
            {
                for (var i = 0; i < items.Count; i++)
                {
                    items[i].SetActive(i < count);
                }
            }
        }

    }
}
