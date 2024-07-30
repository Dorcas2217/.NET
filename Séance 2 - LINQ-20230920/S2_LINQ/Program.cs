using LINQDataContext;

DataContext dc = new DataContext();


Student? jdepp = (from student in dc.Students
                  where student.Login == "jdepp"
                  select student).SingleOrDefault();

if (jdepp != null)
{
    Console.WriteLine(jdepp.Last_Name + jdepp.First_Name);
}

// Ecrire une requête pour présenter, pour chaque étudiant, le nom de l’étudiant, la date de naissance, le login et le résultat pour l’année de l’étudiant.
List<Student>? students = (from student in dc.Students select student).ToList();

/*if (students != null)
{
    foreach (Student student in students)
    {
        Console.WriteLine("Name :" + student.First_Name + ", BirthDate : " + student.BirthDate + ", Login: " + student.Login + ", Year_Result: " + student.Year_Result);

    }

}*/

var studentsL = from student in dc.Students
                         select new
                         {
                             FullName = student.Last_Name + " " + student.First_Name,
                             Id = student.Student_ID,
                             birthDate = student.BirthDate
                         };
/*if (studentsL != null)
{
    foreach (var student in studentsL)
    {
        Console.WriteLine(student);
    }
}*/
var Lstudents = from student in dc.Students
                select string.Join("\n|", student.First_Name, student.Section_ID, student.Last_Name, student.Login, student.BirthDate);

/*if (Lstudents != null)
{
    foreach (var student in Lstudents)
    {
        Console.WriteLine(student);

    }
}
*/

var Liststudents = from student in dc.Students
                   where student.BirthDate.Year < 1955
                   select new 
                   { LName = student.Last_Name, 
                   YearResult = student.Year_Result, 
                   Statut = (student.Year_Result > 12) ? "OK" : "KO" 
                   };

/*foreach (var stu in Liststudents)
{
    Console.WriteLine("{0} {1} {2}", stu.LName, stu.YearResult, stu.Statut);
}*/

//Ecrire une requête pour présenter le nom et le résultat annuel classé par résultats annuels décroissants de tous les étudiants qui ont obtenu un résultat inférieur ou égal à 3.
var res = from student in dc.Students
          where student.Year_Result <= 3
          orderby student.Year_Result descending
          select new
          {
              Name = student.First_Name,
              Year_result = student.Year_Result,
          };

foreach (var student in res)
{
    Console.WriteLine("{0} {1}", student.Name, student.Year_result);
}

// Donner le résultat annuel moyen pour l’ensemble des étudiants.
var res1 = dc.Students.Average(student => student.Year_Result);
Console.WriteLine("The average year result is {0}", res1);

//Donner le nombre de lignes qui composent la « table » STUDENT.
var res2 = dc.Students.Count();
Console.WriteLine("Number lines student {0}", res2);

//Donner pour chaque section, le résultat maximum (Max_Result) obtenu par les étudiants.
var maxResults = from student in dc.Students
                 group student by student.Section_ID into sectionGroup
                 select new
                 {
                     SectionID = sectionGroup.Key,
                     MaxResult = sectionGroup.Max(s => s.Year_Result)
                 };

foreach (var result in maxResults)
{
    Console.WriteLine("Section ID: {0}, Max Result: {1}", result.SectionID, result.MaxResult);
}

// Donner le résultat moyen (AVG_Result) et le mois en chiffre (BirtMonth) pour les étudiants né le même mois entre 1970 et 1985.
var res3 = from student in dc.Students
           where student.BirthDate.Year >= 1970 & student.BirthDate.Year <= 1985
           group student by student.BirthDate.Month into studentGroup
           select new
           {
               month = studentGroup.Key,
               avg = studentGroup.Average(s => s.Year_Result),
           };

foreach (var result in res3)
{
    Console.WriteLine("résultat moyen : {0}, pour les étudiants nés au mois : {1}", result.avg, result.month);
}

//Donner pour chaque cours le nom du professeur responsable ainsi que la section dont il fait partie.
var res4 = from c in dc.Courses
           join p in dc.Professors on c.Professor_ID equals p.Professor_ID
           join s in dc.Sections on p.Section_ID equals s.Section_ID
           select new
           {
               course_name = c.Course_Name,
               teacher = p.Professor_Name,
               section = s.Section_Name
           };


Console.WriteLine("\nCourse_name \t Section_name \t Professor_name");
    foreach (var result in res4)
    {
        Console.WriteLine($"{result.course_name}\t{result.section}\t{result.teacher}");
    }

// Donner pour toutes les sections les professeurs qui en sont membres.
var res5 = from p in dc.Professors
           join s in dc.Sections on p.Section_ID equals s.Section_ID
           group p by s.Section_Name into pGroup
           select new
           {
               section_name = pGroup.Key,
               teacher_name = pGroup.Select(pro=> pro.Professor_Name)
           };

Console.WriteLine("\nSection_name: \t Teacher_name");
foreach (var result in res5)
{
    Console.WriteLine($"\n{result.section_name}");
    foreach (var teacher_name in result.teacher_name)
    {
        Console.WriteLine($"Mr/Mme {teacher_name}");
    }
}
