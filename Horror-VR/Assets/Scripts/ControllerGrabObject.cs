

using System.Collections;
using UnityEngine;
namespace control
{
    public class ControllerGrabObject : MonoBehaviour
    {
        private SteamVR_TrackedObject trackedObj;

        public Renderer rend;
        public bool grabbed;

        private GameObject collidingObject;
        private GameObject objectInHand;
        private SteamVR_Controller.Device Controller
        {
            get { return SteamVR_Controller.Input((int)trackedObj.index); }
        }

        void Awake()
        {
            trackedObj = GetComponent<SteamVR_TrackedObject>();
        }

        //void Start()
        //{
        //    rend = GetComponent<Renderer>();
        //    rend.material.shader = Shader.Find("SkinBurning");
        //    grabbed = false;
        //}


        public void OnTriggerEnter(Collider other)
        {
            SetCollidingObject(other);
        }

        public void OnTriggerStay(Collider other)
        {
            SetCollidingObject(other);
        }

        public void OnTriggerExit(Collider other)
        {
            if (!collidingObject)
            {
                return;
            }

            collidingObject = null;
        }

        private void SetCollidingObject(Collider col)
        {
            if (collidingObject || !col.GetComponent<Rigidbody>())
            {
                return;
            }

            collidingObject = col.gameObject;
        }

        void Update()
        {
            if (SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost)).GetHairTriggerDown())
            {

                Keypress.keypress = true;
                 Debug.Log("pressed");
                if (collidingObject)
                {
                    GrabObject();
                    //if (collidingObject.tag == "burn")
                    //{
                    StartCoroutine(LongVibration(0.5f, 10000));
                    //   // grabbed = true;
                    //}
                }
            }

            if (SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).GetHairTriggerDown())
            {

                Keypress.keypressL = true;
                Debug.Log("pressed");
                if (collidingObject)
                {
                    GrabObject();
                    //if (collidingObject.tag == "burn")
                    //{
                    StartCoroutine(LongVibration(0.5f, 10000));
                    //   // grabbed = true;
                    //}
                }
            }


            if (SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost)).GetHairTriggerUp())
            {
                Keypress.keypress = false;

                if (objectInHand)
                {
                    ReleaseObject();
                }
            }

            if (SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).GetHairTriggerUp())
            {
                Keypress.keypressL = false;

                if (objectInHand)
                {
                    ReleaseObject();
                }
            }

            //if (grabbed == true)
            //{
            //    float fallaway = 0;
            //    fallaway = fallaway + 0.01f;
            //    rend.material.SetFloat("_Threshold", fallaway);
            //}
            ////else grabbed = false;

        }


        IEnumerator LongVibration(float length, ushort strength)
        {
            for (float i = 0; i < length; i += Time.deltaTime)
            {
                Controller.TriggerHapticPulse(strength);
                yield return null; //every single frame for the duration of "length" you will vibrate at "strength" amount
            }
        }

        private void GrabObject()
        {
            objectInHand = collidingObject;
            collidingObject = null;
            var joint = AddFixedJoint();
            joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
        }

        private FixedJoint AddFixedJoint()
        {
            FixedJoint fx = gameObject.AddComponent<FixedJoint>();
            fx.breakForce = 20000;
            fx.breakTorque = 20000;
            return fx;
        }

        private void ReleaseObject()
        {
            if (GetComponent<FixedJoint>())
            {
                GetComponent<FixedJoint>().connectedBody = null;
                Destroy(GetComponent<FixedJoint>());
                objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
                objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
            }

            objectInHand = null;
        }
    }
}
