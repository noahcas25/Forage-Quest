using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarecrow : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private CharacterController _charController;
    [SerializeField] private Animator _anim;
    [SerializeField] private float _speed;
    [SerializeField] private float _gravityScale;
    [SerializeField] private float _gravityValue;

    private float _velocity;
    private Vector3 _direction;
    private float _turnSmoothVelocity;

    private void Update() {
        Movement();
    }

    private void Movement() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        _direction = new Vector3(horizontal, 0f, vertical);

        bool groundedPlayer = _charController.isGrounded;
        if (groundedPlayer && _velocity < 0)
            _velocity = 0f;

        _velocity -= _gravityValue * _gravityScale * Time.deltaTime;
        

        float velocityZ = Vector3.Dot(_direction.normalized, transform.forward);
        float velocityX = Vector3.Dot(_direction.normalized, transform.right);
        
        _anim.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
        _anim.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);

        if(_direction.magnitude >= 0.1f) {
            _direction.Normalize();

            float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y + 30;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, .1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        } 

        _direction.y = _velocity;
        _charController.Move(_direction * Time.deltaTime * _speed);
        _camera.position = new Vector3(transform.position.x+4f, transform.position.y + 6f, transform.position.z-8f);
    }
}
