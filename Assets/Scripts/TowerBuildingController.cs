using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class TowerBuildingController : MonoBehaviour
    {
        [SerializeField] private GameObject towerPrefab;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private int maxTowersPerPhase;
        [SerializeField] private string logOutput;

        private int towersPlaced;
        private bool canPlaceTowers = true;

        private List<TowerController> towerList = new List<TowerController>();

        void Update()
        {
            if (!canPlaceTowers || towersPlaced >= maxTowersPerPhase) return;

            if (Input.GetMouseButtonDown(0)) 
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer))
                {
                    Vector3 spawnPos = hit.point;
                    spawnPos.y += towerPrefab.GetComponent<BoxCollider>().size.y / 2 * towerPrefab.transform.localScale.y;
                    TowerController towerController = Instantiate(towerPrefab, spawnPos, Quaternion.identity, transform).GetComponent<TowerController>();
                    towerList.Add(towerController);
                    towersPlaced++;
                }
            }
        }

        public void EnterBuildingPhase()
        {
            towersPlaced = 0;
            canPlaceTowers = true;
        }

        public void EnterEnemyPhase()
        {
            canPlaceTowers = false;
            Debug.Log(logOutput + towerList.Count);
        }
    }
}
