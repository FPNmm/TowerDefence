using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class TowerBuildingController : MonoBehaviour
    {
        public GameObject towerPrefab;
        public LayerMask groundLayer;

        void Update()
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer))
                {
                    Vector3 spawnPos = hit.point;
                    spawnPos.y += towerPrefab.GetComponent<BoxCollider>().bounds.extents.y;
                    Instantiate(towerPrefab, hit.point, Quaternion.identity, transform);
                }
            }
        }
    }
}
