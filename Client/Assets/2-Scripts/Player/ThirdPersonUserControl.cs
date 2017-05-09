using FIProject;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;


namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]

    [RequireComponent(typeof(GamePlayer))]
    public class ThirdPersonUserControl : NetworkBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.

        public GamePlayer GamePlayer
        {
            get; set;
        }

        //private Vector3 offsetCamera;
        private CameraController cameraController;

        private GameClient gameClient;


        private void Start()
        {
            if (!isLocalPlayer)
            {
                return;
            }

            DataMaster.GamePlayer = gameObject;

            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;

                //offsetCamera = m_Cam.transform.position - transform.position;
                cameraController = Camera.main.GetComponent<CameraController>();
                cameraController.SetTarget(transform);
                //cameraController.SetFirstPersonView(transform);

                //cameraController.FouseOnPlayer(transform);
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();

            gameClient = GameObject.Find("GameClient").GetComponent<GameClient>();
        }


        private void Update()
        {
            if (!isLocalPlayer || BlockMovement())
            {
                return;
            }

            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            if (!isLocalPlayer || BlockMovement()) 
            {
                return;
            }

            // read inputs
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            bool crouch = Input.GetKey(KeyCode.C);


            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v * m_CamForward + h * m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v * Vector3.forward + h * Vector3.right;
            }
#if !MOBILE_INPUT
            // walk speed multiplier
            if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;


            cameraController.FollowTarget();
            //UpdateCameraTransform();
        }


        //public void UpdateCameraTransform()
        //{
        //    m_Cam.position = transform.position + offsetCamera;
        //}


        void OnTriggerEnter(Collider other)
        {
            if (!isServer)
            {
                return;
            }

            Debug.Log("OnTriggerEnter other.gameObject.tag:" + other.gameObject.tag);

            RpcJump2AnotherServer(other.gameObject.tag);
            Debug.Log("Jumping to another server...");
        }


        [ClientRpc]
        void RpcJump2AnotherServer(string jumpTag)
        {
            string servIP = Util.JumpTag2ServIP(jumpTag);
            int servPort = Util.JumpTag2ServPort(jumpTag);
            string cookie = Util.JumpTag2Cookie(jumpTag);
            gameClient.ConnectGameServer(servIP, servPort, cookie);
        }


        bool BlockMovement()
        {
			GameObject objChatInputField = GameObject.FindWithTag("ChatInputField");
			if (null != objChatInputField)
            {
				return objChatInputField.GetComponent<InputField>().isFocused;
            }

           
            return false;
        }

    }
}