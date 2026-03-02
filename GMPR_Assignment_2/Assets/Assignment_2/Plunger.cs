using UnityEngine;
using System.Collections;
namespace Assignment_2
{

    
    public class Plunger : MonoBehaviour
    {   
        private float yFinal; 
        private Transform _position;
        private Rigidbody2D _bodyType;
        private bool _plungerActive = true;
        void Awake()
        {
            _position = GetComponent<Transform>();
            _bodyType = GetComponent<Rigidbody2D>();
            
        }
        void Update()
        {
            if (_plungerActive)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    yFinal += 0.0005f;
                    _position.position = new Vector2(2.311f, (-0.800f - yFinal));

                }

                if (Input.GetKeyUp(KeyCode.S))
                {
                    _bodyType.bodyType = RigidbodyType2D.Dynamic;
                    StartCoroutine(BodyChange());
                }
            }
        }
        private IEnumerator BodyChange()
        {
            yield return new WaitForSeconds(2);

            yFinal = 0.0005f;
            _bodyType.bodyType = RigidbodyType2D.Kinematic;
        }
        public void Decactivate()
        {
            _plungerActive = false;
        }
        public void Activate()
        {
            _plungerActive = true;
        }
            
    }
}