using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyAdventure
{
    public class HpStrip : MonoBehaviour
    {
        public int Value 
        {
            get
            {
                return _value;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    rectTransform.transform.localScale = new Vector3(value / 100f, 1, 1);
                    _value = value;
                }
            }
        }

        private int _value;

        private RectTransform rectTransform;

        // Start is called before the first frame update
        void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            Value = 100;
        }

    }

}
