using UnityEngine;
using UnityEngine.InputSystem;

namespace assignment_3
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5;
        [SerializeField] private GameObject _projectilePrefab, _projectilePreFab2;
        [SerializeField] private float _projectileSpeed = 5, _projectileSpinVelocity = -2000;
        private InputAction _shipMovement, _fireAction, _fireSecondAction;
        // Update is called once per frame
        void Awake()
        {
            _shipMovement = InputSystem.actions.FindAction("Player/Move");
            //Mapped to Space Keyboard
            _fireAction = InputSystem.actions.FindAction("Player/Jump");
            //Mapped to Hold E key, everytime program restarts the action binding changes to hold down
            _fireSecondAction = InputSystem.actions.FindAction("Player/Interact");
        }

        void OnEnable()
        {
            _shipMovement?.Enable();

            if(_fireAction != null)
            {
                _fireAction.Enable();
                _fireAction.performed += FireButtonPressed;
                _fireAction.canceled += FireButtonReleased;
            }

            if (_fireSecondAction != null)
            {
                _fireSecondAction.Enable();
                _fireSecondAction.performed += FireButtonPressed2;
                _fireSecondAction.canceled += FireButtonReleased;
               
                
            }

        }
        void OnDisable()
        {
            _shipMovement?.Disable(); 
            _fireAction?.Disable();
            _fireSecondAction?.Disable();
        }
        private void Update()
        {
            float moveInput = _shipMovement.ReadValue<Vector2>().x;
            Vector3 shipPosition = transform.position + new Vector3(moveInput *_moveSpeed * Time.deltaTime, 0,0);
            shipPosition.x = Mathf.Clamp(shipPosition.x, -5.6f, 5.6f);
            transform.position = shipPosition;
        }

        private void FireButtonPressed(InputAction.CallbackContext context)
        {
            Vector3 projectileStartPosition = transform.GetChild(0).position;
            GameObject theProjectile =
                Instantiate(_projectilePrefab, projectileStartPosition, transform.rotation);
            
            Projectile projectileScript = theProjectile.GetComponent<Projectile>();
            projectileScript.Speed = _projectileSpeed;
            projectileScript.Direction = transform.up;
           
        }
        private void FireButtonReleased(InputAction.CallbackContext context)
        {
          
        }
        

        private void FireButtonPressed2(InputAction.CallbackContext context) 
        {
            Vector3 projectileStartPosition = transform.GetChild(1).position;
            GameObject theProjectile =
                Instantiate(_projectilePreFab2, projectileStartPosition, transform.rotation);
            Projectile projectileScript = theProjectile.GetComponent<Projectile>();
            projectileScript.Speed = _projectileSpeed;
            projectileScript.Direction = transform.up;
            projectileScript.SpinVelocity = _projectileSpinVelocity;
        }
    }
}

