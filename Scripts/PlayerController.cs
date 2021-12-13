using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
	private Animator anim;
	
	public float speed;
	public float gravity;
	public float rotSpeed;
	
	private float rot;
	private Vector3 moveDirection;
	
	// Start is called before the first frame update
    void Start()
    {
		controller = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
	
	void Move()
	{
		if(controller.isGrounded)
		{
			if(Input.GetKey(KeyCode.W))
			{
				moveDirection = Vector3.forward * speed;
				anim.SetInteger("transition",1);
			}
			
			if(Input.GetKeyUp(KeyCode.W))
			{
				moveDirection = Vector3.zero;
				anim.SetInteger("transition",0);
			}
			
			if(Input.GetKey(KeyCode.Space))
			{
				anim.SetInteger("transition",2);
			}
			
		}
		
		//virar o rosto
		rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
		transform.eulerAngles = new Vector3 (0, rot, 0);
		
		//definir gravidade e garantir rotação no eixo local (e não no global)
		moveDirection.y -= gravity * Time.deltaTime;
		moveDirection = transform.TransformDirection(moveDirection);
		
		//andar
		controller.Move(moveDirection * Time.deltaTime);
	}
		
}
