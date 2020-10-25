using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace FluffyAdventure {
    public class DiamondCounter : MonoBehaviour
    {
        // Start is called before the first frame update

        public Collision player;

        private int diamondAllCount;

        void Start()
        {
            diamondAllCount = GameObject.FindGameObjectsWithTag("Diamond").Count();
        }

        // Update is called once per frame
        void Update()
        {
            GetComponent<Text>().text = player.diamonds.ToString() + "/" + diamondAllCount;
        }
    }

}