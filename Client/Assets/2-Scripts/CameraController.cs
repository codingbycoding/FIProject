using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FIProject
{
    public class CameraController : MonoBehaviour
    {

        //private bool isHoldingMouseY;
        private int cameraLevel;

        private Vector3 offsetTargetPosition;
        private Vector3 offsetPosition;
        private Transform targetTransform = null;
        // Use this for initialization
        void Start()
        {
            //isHoldingMouseY = false;
            cameraLevel = 0;
            offsetPosition = new Vector3(0, 1, -1);
            Debug.Log("CameraController Start()");
        }

        // Update is called once per frame
        void Update()
        {
            //if (Input.GetMouseButtonDown(1))
            //{
            //    isHoldingMouseY = true;

            //    if (cameraLevel++ % 2 == 0)
            //    {
            //        transform.position += offsetPosition;
            //    }
            //    else
            //    {
            //        transform.position -= offsetPosition;
            //    }

            //}



            if (Input.GetAxis("Mouse ScrollWheel") < 0 && cameraLevel > -1)
            {
                cameraLevel--;
                transform.position -= offsetPosition;
                UpdateTargetOffset();
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0 && cameraLevel < 1)
            {
                cameraLevel++;
                transform.position += offsetPosition;
                UpdateTargetOffset();
            }


        }

        private void FixedUpdate()
        {

        }


        private void OnGUI()
        {

        }


        public void SetTarget(Transform targetTransform)
        {
            this.targetTransform = targetTransform;
            UpdateTargetOffset();
        }

        private void UpdateTargetOffset()
        {
            if(null != targetTransform)
            {
                offsetTargetPosition = transform.position - targetTransform.position;
            }
            
        }

        public void FollowTarget()
        {
            transform.position = targetTransform.position + offsetTargetPosition;
            ////Camera.main.transform.LookAt(transform);
            //transform.rotation = transform.rotation;
        }

        public void SetFirstPersonView(Transform avatarTransform)
        {

        }

        public void FouseOnPlayer(Transform avatarTransform)
        {
            transform.position = avatarTransform.position + new Vector3(0, 2, -3);
            transform.rotation = avatarTransform.rotation;
        }
        
    }

}