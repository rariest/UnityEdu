using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigidbody : MonoBehaviour
{
    public float speed = 0.01f;

    public float speedX;
    public float speedY;
    public float speedZ;

    public float _speedX;
    public float _speedY;
    public float _speedZ;

    public float maxX = 1f;
    public float maxY = 1f;
    public float maxZ = 1f;

    public bool moveX = false; 
    public bool moveY = false;
    public bool moveZ = false;

    public bool _moveX = false; 
    public bool _moveY = false;
    public bool _moveZ = false;

    Vector3 oldPos = new Vector3();

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        oldPos = transform.position;
        speedX = moveX ? speed : 0f;
        speedY = moveY ? speed : 0f;
        speedZ = moveZ ? speed : 0f;
    }

    void FixedUpdate()
    {
        
       
        //range of movement
        if (rb.position.x > (oldPos.x + maxX)) {
            speedX = -System.Math.Abs(speedX);
        } 
        if (rb.position.x < (oldPos.x)) {
            speedX = System.Math.Abs(speedX);
        } 
        if (rb.position.y > (oldPos.y + maxY)) {
            speedY = -System.Math.Abs(speedY);
        } 
        if (rb.position.y < (oldPos.y)) {
            speedY = System.Math.Abs(speedY);
        } 
        if (rb.position.z > (oldPos.z + maxZ)) {
            speedZ = -System.Math.Abs(speedZ);
        } 
        if (rb.position.z < (oldPos.z)) {
            speedZ = System.Math.Abs(speedZ);
        } 

        //stop and resume on run
        if (!moveX && !_moveX) {
            _speedX = speedX;
            speedX = 0f; 
            _moveX = !_moveX;
        } 
        if (_moveX && moveX) {
            speedX = _speedX;
            _moveX = !_moveX;
        }
        if (moveX && _speedX==0) {
            speedX = speed;
            _speedX = speed;
            _moveX = false;
        }

        if (!moveY && !_moveY) {
            _speedY = speedY;
            speedY = 0f; 
            _moveY = !_moveY;
        } 
        if (_moveY && moveY) {
            speedY = _speedY;
            _moveY = !_moveY;
        }
        if (moveY && _speedY==0) {
            speedY = speed;
            _speedY = speed;
            _moveY = false;
        }

        if (!moveZ && !_moveZ) {
            _speedZ = speedZ;
            speedZ = 0f; 
            _moveZ = !_moveZ;
        } 
        if (_moveZ && moveZ) {
            speedZ = _speedZ;
            _moveZ = !_moveZ;
        }
        if (moveZ && _speedZ==0) {
            speedZ = speed;
            _speedZ = speed;
            _moveZ = false;
        }

        //move kinematic rb
        rb.MovePosition(new Vector3(rb.position.x + speedX*Time.deltaTime, rb.position.y + speedY*Time.deltaTime, rb.position.z + speedZ*Time.deltaTime));

        //rb.velocity = new Vector3(rb.velocity.x + speedX, rb.velocity.y + speedY, rb.velocity.z + speedZ); 

        //rb.AddForce(speedX,speedY,speedZ,ForceMode.Impulse);
        
    }
}
