﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPanel : MonoBehaviour
{
	public VrbColor cRef;

	public Image img;

	public Slider rs;
	public Text rt;

	public Slider gs;
	public Text gt;

	public Slider bs;
	public Text bt;

	public Slider a_s;
	public Text at;

	void OnEnable()
	{
		if (cRef != null)
		{
			rs.value = cRef.color.r;
			gs.value = cRef.color.g;
			bs.value = cRef.color.b;
			a_s.value = cRef.color.a;
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		img = transform.Find("ColorPanel/Image").GetComponent<Image>();

		rs = transform.Find("ColorPanel/RSlider").GetComponent<Slider>();
		gs = transform.Find("ColorPanel/GSlider").GetComponent<Slider>();
		bs = transform.Find("ColorPanel/BSlider").GetComponent<Slider>();
		a_s = transform.Find("ColorPanel/ASlider").GetComponent<Slider>();

		rt = transform.Find("ColorPanel/RValue").GetComponent<Text>();
		gt = transform.Find("ColorPanel/GValue").GetComponent<Text>();
		bt = transform.Find("ColorPanel/BValue").GetComponent<Text>();
		at = transform.Find("ColorPanel/AValue").GetComponent<Text>();
	}

    // Update is called once per frame
    void Update()
	{
		rt.text = rs.value.ToString();
		gt.text = gs.value.ToString();
		bt.text = bs.value.ToString();
		at.text = a_s.value.ToString();

		img.color = new Color(rs.value, gs.value, bs.value, a_s.value);
		cRef.color = img.color;
    }

	public void closeSelf()
	{
		gameObject.SetActive(false);
	}
}
