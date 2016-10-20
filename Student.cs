﻿using System;
using System.Collections.Generic;

namespace Relations_classes_objets
{
	public class Student : Person
	{
		private List<Evaluation> Cours = new List<Evaluation>();        //Evaluation contient appreciation et note et //private donc uniquement accessible dans toute la classe
		private string _firstname;
		private string _lastname;
		public Student(string Firstname, string Lastname) : base(Firstname, Lastname)
		{
			this._firstname = Firstname;
			this._lastname = Lastname;
		}

		public void Add(Evaluation evaluation)          //evaluation doit etre du type Evaluation
		{
			Cours.Add(evaluation);
		}
		public double Average()
		{
			//for (int i = 0; i < Cours.Count; i++)
			//{
			//	Cours[i].Note();
			//}
			double average = 0;
			foreach (Evaluation e in Cours)
			{
				average += e.Note();
			}

			return average / Cours.Count;
		}
		public string Bulletin()
		{
			string bulletin = "Nom du cours" + "\tCode du cours" + "\tNbre ECTS" + "\tCote obtenue\n";
			//Dictionary<Activity, string> bulletin = new Dictionary<Activity, string>();
			foreach (Evaluation eval in Cours)
			{
				//aligne les informaions dans les colonnes du tableau du bulletin
				if (eval.Activity.Name.Length < 10)
				{
					bulletin += eval.Activity.Name + "\t\t" + eval.Activity.Code + "\t\t" + eval.Activity.ECTS + "\t\t" + eval.Note() + "\n";
				}
				else
				{
					bulletin += eval.Activity.Name + "\t" + eval.Activity.Code + "\t\t" + eval.Activity.ECTS + "\t\t" + eval.Note() + "\n";
				}
			}
			bulletin = string.Format("Bulletin de {0} {1} : \n\n{2}\nLa moyenne obtenue est de {3}\n\n\n\n",
			                          this._firstname, this._lastname, bulletin, Average());
			
			return bulletin;
		}

	}
}
