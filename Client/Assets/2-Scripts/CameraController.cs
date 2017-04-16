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


		private float x = 0.0f;
		private float y = 0.0f;
		private float yMinLimit = -20;
		private float yMaxLimit = 80;
		private float xSpped = 250;
		private float ySpeed = 120;

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



			// 
			if(Input.GetMouseButton(0) && Input.GetMouseButton(1))				
			{
				x += Input.GetAxis("Mouse X") * xSpped * 0.02f;
				y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

				y = ClampAngle(y, yMinLimit, yMaxLimit);

				var rotation = Quaternion.Euler(y, x, 0);
				//var pRotation = Quaternion.Euler(0, x, 0);

				transform.rotation = rotation;
				targetTransform.rotation = rotation;
				//targetTransform.rotation = pRotation;
			}


        }

		float ClampAngle(float angle, float min, float max)
		{
			if (angle < -360)
				angle += 360;
			if (angle > 360)
				angle -= 360;
			return Mathf.Clamp(angle, min, max);
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