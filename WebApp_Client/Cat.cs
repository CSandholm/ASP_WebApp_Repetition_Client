﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApp_Client
{
	public class Cat
	{
		public int Id { get; set; }
		[Required,
		MaxLength(25)]
		public string Name { get; set; }
		[Required,
		MaxLength(25)]
		public string Color { get; set; }
		[Required,
		MaxLength(100),
		Display(Name = "Owner's Name")]
		public string OwnerName { get; set; }
		[Required]
		public int Age { get; set; }
		[Required,
		Display(Name = "Image URL")]
		public string ImageUrl { get; set; }

		public Cat(string name, string color, string ownerName, int age, string imageUrl)
		{
			Name = name;
			Color = color;
			OwnerName = ownerName;
			Age = age;
			ImageUrl = imageUrl;
		}
		public Cat()
		{

		}
	}
}
