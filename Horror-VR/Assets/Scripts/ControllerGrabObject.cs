

using System.Collections;
using UnityEngine;
namespace control
{
    public class ControllerGrabObject : MonoBehaviour
    {
        private SteamVR_TrackedObject trackedObj;

        private GameObject collidingObject;
        private GameObject objectInRightHand;
        private GameObject objectInLeftHand;

        private SteamVR_Controller.Device Controller
        {
            get { return SteamVR_Controller.Input((int)trackedObj.index); }
        }

        void Awake()
        {
            trackedObj = GetComponent<SteamVR_TrackedObject>();
        }

     


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
                Skinburncontrol.grabbed = true;
                if (collidingObject)
                {
                    if (objectInLeftHand == null)
                    {
                        GrabObjectRight();
                        StartCoroutine(LongVibrationR(0.5f, 10000));
                    }
                    
                }
            }

            if (SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).GetHairTriggerDown())
            {

                Keypress.keypressL = true;
                Skinburncontrol.grabbed = true;
                if (collidingObject)
                {
                    if (objectInRightHand == null)
                    {
                        GrabObjectLeft();
                        StartCoroutine(LongVibrationL(0.5f, 10000));
                    }   
                }
            }


            if (SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost)).GetHairTriggerUp())
            {
                Keypress.keypress = false;

                ReleaseObjectRight();

                //if (objectInRightHand)
                //{
                //    ReleaseObjectRight();

                //}
            }

            if (SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).GetHairTriggerUp())
            {
                Keypress.keypressL = false;


                ReleaseObjectLeft();

                //if (objectInLeftHand)
                //{
                //    ReleaseObjectLeft();
                    
                //}
            }

        }


        IEnumerator LongVibrationL(float length, ushort strength)
        {
            for (float i = 0; i < length; i += Time.deltaTime)
            {
                SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).TriggerHapticPulse(strength);
                yield return null; //every single frame for the duration of "length" you will vibrate at "strength" amount
            }
        }

        IEnumerator LongVibrationR(float length, ushort strength)
        {
            for (float i = 0; i < length; i += Time.deltaTime)
            {
                SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost)).TriggerHapticPulse(strength);
                yield return null; //every single frame for the duration of "length" you will vibrate at "strength" amount
            }
        }

        private void GrabObjectRight()
        {
            objectInRightHand = collidingObject;
            collidingObject = null;
            var joint = AddFixedJoint();
            joint.connectedBody = objectInRightHand.GetComponent<Rigidbody>();

        }

        private void GrabObjectLeft()
        {
            objectInLeftHand = collidingObject;
            collidingObject = null;
            var joint = AddFixedJoint();
            joint.connectedBody = objectInLeftHand.GetComponent<Rigidbody>();

        }



        private FixedJoint AddFixedJoint()
        {
            FixedJoint fx = gameObject.AddComponent<FixedJoint>();
            fx.breakForce = 20000;
            fx.breakTorque = 20000;
            return fx;
        }

        private void ReleaseObjectRight()
        {
            if (GetComponent<FixedJoint>())
            {
                GetComponent<FixedJoint>().connectedBody = null;
                Destroy(GetComponent<FixedJoint>());
                objectInRightHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
                objectInRightHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;

            }
            

            objectInRightHand = null;
        }

        private void ReleaseObjectLeft()
        {
            if (GetComponent<FixedJoint>())
            {
                GetComponent<FixedJoint>().connectedBody = null;
                Destroy(GetComponent<FixedJoint>());
                objectInLeftHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
                objectInLeftHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;

            }


            objectInLeftHand = null;
        }
    }
}
