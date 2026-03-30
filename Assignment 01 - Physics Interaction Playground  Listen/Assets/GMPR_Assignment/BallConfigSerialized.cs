namespace GMPR_Assignment.assignment1
{
    using UnityEngine;

    public class BallConfig : MonoBehaviour
    {
        [SerializeField] Rigidbody2D _BallVelocity;
        [SerializeField] Transform _BallSize;
        [Range(-10f, 10f)][SerializeField] float _xSpeed,  _ySpeed, _xSize=1,_ySize=1;
        void Awake()
        {
            if (_BallVelocity != null && _BallSize != null)
            {
                _BallVelocity = GetComponent<Rigidbody2D>();
                _BallSize = GetComponent<Transform>();
            }
        }

        private void OnValidate()
        {
            if( _BallVelocity != null && Application.isPlaying && _BallSize != null)
            {
                _BallVelocity.linearVelocity = new Vector2(_xSpeed, _ySpeed);
                _BallSize.localScale = new Vector2(_xSize, _ySize);
            }
        }


    }
}