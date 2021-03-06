﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VrbEditableFace : MonoBehaviour, IPointerClickHandler
{
	public VrbFace f;
	public Color colorLastFrame;
	public GameObject pc;
	public PlayerController pcpc;

	void OnEnable()
	{
		if (f != null)
		{
			gameObject.GetComponent<MeshRenderer>().material.color = f.matVrbc.color;
		}
		if (pc == null)
		{
			pc = GameObject.Find("PlayerController");
			pcpc = pc.GetComponent<PlayerController>();
		}
	}

	void Start()
	{
		
	}

    // Update is called once per frame
    void LateUpdate()
    {
		if (pcpc.performedSomeOperation)
		{
			//List<Vector3> v = f.fVectors;
			//for (int i= 0; i < v.Count; i++)
			//{
			//	Debug.LogWarning(i+": "+v[i]);
			//}
			//List<int> t = f.fTriangles;
			//for (int i = 0; i < t.Count; i++)
			//{
			//	Debug.LogWarning(i + ": " + t[i]);
			//}
			f.mesh.Clear();
			f.mesh.SetVertices(f.fVectors);
			f.mesh.SetTriangles(f.fTriangles, 0);
			f.mesh.SetColors(f.fColors);
			f.mesh.RecalculateNormals();
			GetComponent<MeshFilter>().mesh = f.mesh;
			f.meshCollider.sharedMesh = f.mesh;
		}

		if (colorLastFrame != f.vrbc.color)
		{
			colorLastFrame = f.vrbc.color;
			f.mesh.SetColors(f.fColors);
		}
	}

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		GameObject.Find("PlayerController").GetComponent<PlayerController>().select(f);
	}

	public void init()
	{
		f.mesh.SetVertices(f.fVectors);
		f.mesh.SetTriangles(f.fTriangles, 0);
		f.mesh.RecalculateNormals();
		f.meshCollider.sharedMesh = f.mesh;
		colorLastFrame = f.vrbc.color;
		f.mesh.SetColors(f.fColors);

		gameObject.GetComponent<MeshRenderer>().material.color = f.matVrbc.color;
	}
}
