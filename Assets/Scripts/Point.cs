using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Point : MonoBehaviour
{

    public List<Point> neighbors;
    public List<Wall> children;
    public float x, y, z;
    public GameObject _wall;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        this.x = gameObject.transform.position.x;
        this.y = gameObject.transform.position.y;
        this.z = gameObject.transform.position.z;
		FindNeighbors();
        foreach (Point p in neighbors)
        {
            CreateWall(this, p);
        }
    }

    void AddNeighbor(Point Neighbor)
    {
        this.neighbors.Add(Neighbor);
        Neighbor.neighbors.Add(this);
    }

	List<Point> FindNeighbors(){
		List<Point> found = new List<Point>();
		/*	This is supposed to fire a raycast in all directions
			and return a list comprised of the first hit in all directions.
			But I ran outta time so neighbors have to be assigned manually.
			Sorry. */

		return found;
	}

    void CreateWall(Point A, Point B)
    {

        Vector3 Origin;
        float xCompare = A.x - B.x;
        float yCompare = A.y - B.y;
        float Distance = new Vector3(xCompare, yCompare, 0).magnitude;

		//Do a check to see if the walls share a different set of changes.
		//TODO: Need to write a script for diagnonal walls in next update

        if (xCompare == 0)
        {
            Origin = new Vector3(A.x, (A.y + B.y) / 2, A.z);

            //Calculate the origin point
            Origin = new Vector3((A.x + B.x) / 2, A.y, A.z);

            //Create a new wall object
            GameObject wall = Instantiate(_wall, Origin, Quaternion.identity) as GameObject;

            //Fetch the wall's data
            Wall newWall = wall.GetComponent<Wall>();

            //Apply the new wall to both parents
            newWall.AddParents(A, B);
            children.Add(newWall);
            B.children.Add(newWall);

            //Scale the wall to equal the distance between both parents
            //Note that if they are the same X, the distance calculated is between Y.
            newWall.ScaleSelf(new Vector3(1, Distance, 1));
        }

        if (yCompare == 0)
        {
            //Calculate the origin point
            Origin = new Vector3((A.x + B.x) / 2, A.y, A.z);

            //Create a new wall object
            GameObject wall = Instantiate(_wall, Origin, Quaternion.identity) as GameObject;

            //Fetch the wall's data
            Wall newWall = wall.GetComponent<Wall>();

            //Apply the new wall to both parents
            newWall.AddParents(A, B);
            children.Add(newWall);
            B.children.Add(newWall);

            //Scale the wall to equal the distance between both parents
            //Note that if they are the same Y, the distance calculated is between X.
            newWall.ScaleSelf(new Vector3(Distance, 1, 1));
        }

        // Distance = new Vector3(A.x - B.x, A.y - B.y, A.z - B.z);
        // Vector3 Origin = new Vector3(Distance.x/2, Distance.y/2, Distance.z/2);
        //Use Half of Distance to instantiate a new Wall object
        //Use the magnitude to scale the new object
        //Add point B to neighbors and new Wall to children	



    }





}



