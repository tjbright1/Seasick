#pragma strict

 class NavMeshHitResult{
     var result : boolean;
     var navMeshHit : NavMeshHit;
     
     function NavMeshHitResult(result : boolean, navMeshHit : NavMeshHit){
         this.result = result;
         this.navMeshHit = navMeshHit;
     }
 }

function Start () {
	
}

function raycastToNavmesh(screenPosition : Vector3) : NavMeshHitResult{
         var ray : Ray = Camera.mainCamera.ScreenPointToRay(screenPosition);
             
         var raycastHit : RaycastHit;
         if(Physics.Raycast(ray.origin, ray.direction, raycastHit)){
             var navMeshHit : NavMeshHit;
             var result = NavMesh.SamplePosition(raycastHit.point, navMeshHit, 1, 1);
                 return new NavMeshHitResult(result, navMeshHit);
         }
 }
 
function Update () {

}