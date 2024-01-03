// See https://aka.ms/new-console-template for more information
using SchoolApp.Models;
using SchoolApp.Repositories;
using SchoolApp.UnitOfWork;
using System;

    SchoolContext context = new SchoolContext();
    IUnitOfWorkSchool unitOfWorkSchool = new UnitOfWorkSQL(context);

    bool exit = false;

    while (!exit)
    {
        Console.WriteLine("MENU:");
        Console.WriteLine("1 - Ajouter une section");
        Console.WriteLine("2 - Ajouter un étudiant");
        Console.WriteLine("3 - Liste des sections");
        Console.WriteLine("4 - Liste des etudiants ");
        Console.WriteLine("5 - Quitter");

        Console.Write("Entrez votre choix  : ");
        string userInput = Console.ReadLine();

        switch (userInput)
        {
            case "1":
                Console.Write("Nom de la section : ");
                string sectionName = Console.ReadLine();

                Section newSection = new Section { Name = sectionName };

                bool sectionAdded = unitOfWorkSchool.SectionRepository.Save(newSection, s => s.Name.Equals(sectionName));

                if (!sectionAdded)
                {
                    Console.WriteLine("La section existe déjà.");
                }
                else
                {
                    Console.WriteLine("Section créée avec succès.");
                }
                break;

            case "2":

                Console.WriteLine("Prénom de l'étudiant:  ");
                string name = Console.ReadLine();
                Console.WriteLine("Nnom  de l'étudiant:  ");
                string firstname = Console.ReadLine();
                Console.WriteLine("Résultat de l'année académique : ");
                string yearResult = Console.ReadLine();
                Console.WriteLine("Section de l'étudiant:  ");
                string section = Console.ReadLine();

                Section sectionFind = unitOfWorkSchool.SectionRepository.SearchFor(s => s.Name.Equals(section)).FirstOrDefault();

                if (sectionFind == null)
                {
                    Console.WriteLine("Cette section n'existe pas ");
                    break;
                }
          


                Student student = new Student
                {
                    Name = name,
                    Firstname = firstname,
                    Section = sectionFind,
                    YearResult = long.Parse(yearResult)

                };

                bool rslt = unitOfWorkSchool.StudentRepository.Save(student, stud =>  stud.Name.Equals(name) && stud.Firstname.Equals(firstname) ) ;

                if (!rslt)
                {
                    Console.WriteLine("Étudiant existe déjà !");
                }
                else
                {
                    Console.WriteLine("l'Étudiant a été rajouté avec succès !");
                }
                break;

            case "3":
                Console.WriteLine("Liste des sections : ");

                foreach(Section sect in unitOfWorkSchool.SectionRepository.GetAll())
                {
                    Console.WriteLine(sect.Name);
                }
                break;

            case "4":
                Console.WriteLine(" Liste des etudiants  ");

                foreach(Student stu in unitOfWorkSchool.StudentRepository.GetAll())
                {
                    Console.WriteLine($" => {stu.Name}, {stu.Firstname}, section {stu.Section.Name}");
                }
                break;

            case "5":
                exit = true;
                break;

            default:
                Console.WriteLine("Choix invalide. Veuillez entrer 1, 2, 3, 4, ou 5.");
                break;
        }

        Console.WriteLine(); 
    }

    Console.WriteLine("Fin du programme.");
