using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class Thunderbolts : MonoBehaviour
    {

        public List<GameObject> levelOne;
        public List<GameObject> levelTwo;
        public List<GameObject> levelThree;
        private GameManager _gameManager;
            
        public int FillLevel
        {
            get => Mathf.FloorToInt(GameManager.Instance.HammerPower);
            set => ActivateThunderbolts(value);
        }

        private void Start()
        {
            _gameManager = GameManager.Instance;
        }

        private void ActivateThunderbolts(int level)
        {
            foreach (GameObject o in levelOne) o.SetActive(false);
            foreach (GameObject o in levelTwo) o.SetActive(false);
            foreach (GameObject o in levelThree) o.SetActive(false);

            if (level >= _gameManager.gameManagerData.levelOneThunderbolt)
                foreach (GameObject o in levelOne)
                    o.SetActive(true);
            if(level >= _gameManager.gameManagerData.levelTwoThunderbolt)
                foreach (GameObject o in levelTwo)
                    o.SetActive(true);
            if(level >= _gameManager.gameManagerData.levelThreeThunderbolt)
                foreach (GameObject o in levelThree)
                    o.SetActive(true);
        }
        
    }
}