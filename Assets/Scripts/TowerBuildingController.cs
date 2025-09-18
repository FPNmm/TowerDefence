using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class TowerBuildingController : MonoBehaviour
    {
        public GameObject towerPrefab;
        public LayerMask groundLayer;
        public int maxTowersPerPhase;

        private int towersPlaced;
        private bool canPlaceTowers = true;

        void Update()
        {
            if (!canPlaceTowers || towersPlaced >= maxTowersPerPhase) return;

            if (Input.GetMouseButtonDown(0)) 
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer))
                {
                    Vector3 spawnPos = hit.point;
                    spawnPos.y += towerPrefab.GetComponent<BoxCollider>().bounds.extents.y;
                    Instantiate(towerPrefab, hit.point, Quaternion.identity, transform);
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
        }
    }
}
