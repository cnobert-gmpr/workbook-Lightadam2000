using UnityEngine;

namespace Assignment_2
{
    

    public class Flipper : MonoBehaviour
    {
        private HingeJoint2D _joint;
        public bool _flippersActive = true;
        [SerializeField] private bool _flipper;


        void Awake()
        {
            _joint = GetComponent<HingeJoint2D>();
        }
        void Update()
        { 
            if (_flippersActive)
            {
                if (_flipper)
                    _joint.useMotor = Input.GetKey(KeyCode.D);
                else
                    _joint.useMotor = Input.GetKey(KeyCode.A);
            }
        }
        public void Deactivate()
        {
            _flippersActive = false;
        }
        public void Activate()
        {
            _flippersActive = true;
        }
    }
}