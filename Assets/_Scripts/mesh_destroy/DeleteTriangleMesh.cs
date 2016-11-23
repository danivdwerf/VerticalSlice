using UnityEngine;
using System.Collections;

public class DeleteTriangleMesh : MonoBehaviour {

	// fuction for deleting the given triangle.
	public void deleteTri (int index)
    {
        //destroy MeshCollider
        Destroy(this.gameObject.GetComponent<MeshCollider>());
        //get mesh
        Mesh mesh = transform.GetComponent<MeshFilter>().mesh;
        //make array of triangle points
        int[] oldTriangles = mesh.triangles;
        //make array of triangle points mines the 3 points that make up the triangle
        int[] newTriangles = new int[mesh.triangles.Length - 3];

        //make counters
        int i = 0;
        int j = 0;

        //go trouh triangle poins
        while(j < mesh.triangles.Length)
        {
            //look if j is not the triangle
            if(j != index * 3)
            {
                //coppie old info to new info
                newTriangles[i++] = oldTriangles[j++];
                newTriangles[i++] = oldTriangles[j++];
                newTriangles[i++] = oldTriangles[j++];
            }
            else
            {
                //skip over the triangles you wanna delete
                j += 3;
            }
        }
        //put new points in the old mesh
        transform.GetComponent<MeshFilter>().mesh.triangles = newTriangles;
        //add the MeshCollider
        this.gameObject.AddComponent<MeshCollider>();
	}   
}
