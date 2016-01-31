 public var player : Transform;
 var thisTransform : Transform;

 var randomNumber : float;
 private var speed : float;// 10.0;

 var animator : Animator;

 var wayPoint : Vector3;
 private var dir : Vector3;
 private var dirFull : Vector3;

 var caught : boolean;
// var sacrifced : boolean:

 function Start () 
 {
		Wanders();
		thisTransform = this.transform;
		player = GameObject.FindGameObjectWithTag("Player").transform;
		speed =  Random.Range(7,10);
		animator = GetComponent("Animator");
		animator.SetBool("grabbed", false);
 }

 function Update ()
 {
 		if (player.GetComponent("Player").grabbed == true && player.GetComponent("Player").currentSacrifice == this.gameObject) 
		{
			this.transform.position = new Vector3 (player.transform.position.x, 1, player.transform.position.z + 7f);
			this.transform.rotation = Quaternion.Euler(Vector3(-90,player.transform.rotation.y * 100,0));
			//this.transform.eulerAngles = Vector3(-90,90,0);
			//dir = player.transform.position;
		}
 }
 
 function FixedUpdate()
 {
     
     // the directional vector to the target
  /*   	if(Vector3.Distance(player.position, thisTransform.position) < 10) 
     {
     		dir = (transform.position - player.position).normalized;
     		//transform.Rotate(0,randomNumber,0);

	 } else {*/
	 if(player.GetComponent("Player").currentSacrifice != this.gameObject)
	 {
	 dir = (wayPoint - transform.position).normalized;
	 randomNumber = Random.Range(-5,5);
	 //}
     var hit : RaycastHit;
     
     // check for forward raycast
     if (Physics.Raycast(transform.position, transform.forward, hit, 10)) // 20 is raycast distance
     {
         if (hit.transform != this.transform)
         {
             Debug.DrawLine (transform.position, hit.point, Color.white);
             
             dir += hit.normal * 20; // 20 is force to repel by
         }

     }
     
     // more raycasts    
     var leftRay = transform.position + Vector3(-0.125f, 0, 0);
     var rightRay = transform.position + Vector3(0.125f, 0, 0);
     
     // check for leftRay raycast
     if (Physics.Raycast(leftRay, transform.forward, hit, 10)) // 20 is raycast distance
     {
         if (hit.transform != this.transform)
         {
             Debug.DrawLine (leftRay, hit.point, Color.red);
             
             dir += hit.normal * 20; // 20 is force to repel by
         }

     }
     
     // check for rightRay raycast
     if (Physics.Raycast(rightRay, transform.forward, hit, 10)) // 20 is raycast distance
     {
         if (hit.transform != this.transform)
         {
             Debug.DrawLine (rightRay, hit.point, Color.green);
             
             dir += hit.normal * 20; // 20 is force to repel by
         }

     }
     
     // Movement
		//transform.position = transform.forward(transform.position, wayPoint, speed*Time.deltaTime);
		if((transform.position - wayPoint).magnitude < 5)
		{
			Wanders();
		}
     // rotation
     var rot = Quaternion.LookRotation (dir);
         
     //print ("rot : " + rot);
    transform.rotation = Quaternion.Slerp (transform.rotation, rot, Time.deltaTime * 1.5f);
     
     //position
     transform.position += transform.forward * (speed * Time.deltaTime); // 20 is speed
     transform.position.y = 0;
	 transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0.0F, 60.0F), 0, Mathf.Clamp(transform.position.z, 0.0F, 60.0F));

     }
 }
 function Wanders()
	{ 		
		wayPoint.x = Random.Range (0, 60);//, 0.85f, Random.Range(0, 65);
		wayPoint.z = Random.Range (0, 60);
		wayPoint.y = 0.5f;
	}

 function OnCollisionEnter (col: Collision) 
  {
  		if (col.gameObject.tag == "Player" && player.GetComponent("Player").grabbed == false && player.GetComponent("Player").currentSacrifice != this.gameObject) 
  		{
			//caught = true;
			player.GetComponent("Player").grabbed = true;
			player.GetComponent("Player").currentSacrifice = this.gameObject;
			animator.SetBool("grabbed", true);
			//this.transform.GetComponent(Animator).enabled = !enabled;
		} 
  }