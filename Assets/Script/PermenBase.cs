using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgilPermenUtama
{
    public class PermenBase : MonoBehaviour
    {
        public float RotationX = -90f, RotationY = 0f, RotationZ = 0f, kecepatan = 6.5f;
        private void Start()
        {
            this.gameObject.transform.rotation = Quaternion.Euler(RotationX, RotationY, RotationZ);
        }

        private void LateUpdate()
        {
            this.gameObject.transform.Translate(-Vector3.forward * Time.deltaTime * kecepatan);
        }
    }
}
