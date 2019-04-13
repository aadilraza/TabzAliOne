using RandomNameGeneratorLibrary;
using SchoolManagementSystem.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace SchoolManagementSystem.Data
{
    public class SchoolInitializer : DropCreateDatabaseIfModelChanges<SchoolEntities>
    {
        protected override void Seed(SchoolEntities context)
        {
            try
            {
                Random random = new Random();

                context.Database.ExecuteSqlCommand("INSERT INTO Cities VALUES (1, 'Adana'), (2, 'Adıyaman'), (3, 'Afyonkarahisar'), (4, 'Ağrı'), (5, 'Amasya'), (6, 'Ankara'), (7, 'Antalya'), (8, 'Artvin'), (9, 'Aydın'), (10, 'Balıkesir'), (11, 'Bilecik'), (12, 'Bingöl'), (13, 'Bitlis'), (14, 'Bolu'), (15, 'Burdur'), (16, 'Bursa'), (17, 'Çanakkale'), (18, 'Çankırı'), (19, 'Çorum'), (20, 'Denizli'), (21, 'Diyarbakır'), (22, 'Edirne'), (23, 'Elâzığ'), (24, 'Erzincan'), (25, 'Erzurum'), (26, 'Eskişehir'), (27, 'Gaziantep'), (28, 'Giresun'), (29, 'Gümüşhane'), (30, 'Hakkâri'), (31, 'Hatay'), (32, 'Isparta'), (33, 'Mersin'), (34, 'İstanbul'), (35, 'İzmir'), (36, 'Kars'), (37, 'Kastamonu'), (38, 'Kayseri'), (39, 'Kırklareli'), (40, 'Kırşehir'), (41, 'Kocaeli'), (42, 'Konya'), (43, 'Kütahya'), (44, 'Malatya'), (45, 'Manisa'), (46, 'Kahramanmaraş'), (47, 'Mardin'), (48, 'Muğla'), (49, 'Muş'), (50, 'Nevşehir'), (51, 'Niğde'), (52, 'Ordu'), (53, 'Rize'), (54, 'Sakarya'), (55, 'Samsun'), (56, 'Siirt'), (57, 'Sinop'), (58, 'Sivas'), (59, 'Tekirdağ'), (60, 'Tokat'), (61, 'Trabzon'), (62, 'Tunceli'), (63, 'Şanlıurfa'), (64, 'Uşak'), (65, 'Van'), (66, 'Yozgat'), (67, 'Zonguldak'), (68, 'Aksaray'), (69, 'Bayburt'), (70, 'Karaman'), (71, 'Kırıkkale'), (72, 'Batman'), (73, 'Şırnak'), (74, 'Bartın'), (75, 'Ardahan'), (76, 'Iğdır'), (77, 'Yalova'), (78, 'Karabük'), (79, 'Kilis'), (80, 'Osmaniye'), (81, 'Düzce');");

                var students = new List<Student>();
                for (int i = 0; i < 100; i++)
                {
                    students.Add(new Student
                    {
                        FirstName = RandomPersonNameExtensions.GenerateRandomFirstName(random),
                        LastName = RandomPersonNameExtensions.GenerateRandomLastName(random),
                        AddressLine1 = RandomPlaceNameExtensions.GenerateRandomPlaceName(random),
                        AddressLine2 = RandomPlaceNameExtensions.GenerateRandomPlaceName(random),
                        CityId = 35,
                        Email = "student" + i + "@gmail.com",
                        Phone = "0532" + string.Concat(Enumerable.Repeat(random.Next(1,10), 7)),
                        Notes = "Student no: " + i
                    });
                }
                students.ForEach(s => context.People.Add(s));

                var instructors = new List<Instructor>();
                for (int i = 0; i < 10; i++)
                {
                    instructors.Add(new Instructor
                    {
                        FirstName = RandomPersonNameExtensions.GenerateRandomFirstName(random),
                        LastName = RandomPersonNameExtensions.GenerateRandomLastName(random),
                        AddressLine1 = RandomPlaceNameExtensions.GenerateRandomPlaceName(random),
                        AddressLine2 = RandomPlaceNameExtensions.GenerateRandomPlaceName(random),
                        CityId = 35,
                        Email = "instructor" + i + "@iakademi.com",
                        Phone = "0532" + string.Concat(Enumerable.Repeat(i, 7)),
                        Notes = "Instructor no: " + i,
                        HireDate = DateTime.Parse("2003-1-1")
                    });
                }
                instructors.ForEach(i => context.People.Add(i));

                var microsoftCategory = new Category { Name = "Microsoft", Desription = "Microsoft courses" };
                var finansCategory = new Category { Name = "Finans & Muhasebe", Desription = "Finance & Accounting Courses" };
                context.Categories.Add(microsoftCategory);
                context.Categories.Add(finansCategory);

                var excel = new Course { CategoryId = 1, Title = "Excel", Duration = 55, Description = "Excel course" };
                var baslangicExcel = new Course { CategoryId = 1, Title = "Başlangıç Excel", Duration = 10, Description = "Beginner Excel course" };
                var ileriExcel = new Course { CategoryId = 1, Title = "İleri Excel", Duration = 20, Description = "Advanced Excel course" };
                var vbaExcel = new Course { CategoryId = 1, Title = "VBA Excel", Duration = 25, Description = "VBA course" };
                excel.SubCourses.Add(baslangicExcel);
                excel.SubCourses.Add(ileriExcel);
                excel.SubCourses.Add(vbaExcel);
                context.Courses.Add(excel);
               
                var rooms=new List<Room> {
                    new Room {
                        Id = 1,
                        Name = "Lab-1"
                    },
                    new Room {
                        Id = 2,
                        Name = "Lab-2"
                    },
                    new Room {
                        Id = 3,
                        Name = "Lab-3"
                    }
                };
                context.Rooms.AddRange(rooms);

                var courseOffering1 = new CourseOffering
                {
                    CourseId = 1,
                    Days = Model.Enums.Days.Friday| Model.Enums.Days.Sunday,
                    HourlyRate = 30,
                    StartDate = new DateTime(2017, 2, 2),
                    InstructorId = 101,
                    RoomId = 1,
                    State = Model.Enums.CourseOfferingState.Waiting,
                    StartTime = new TimeSpan(19, 00, 00),
                    EndTime = new TimeSpan(22, 00, 00)
                };
                var courseOffering2 = new CourseOffering
                {
                    CourseId = 2,
                    Days = Model.Enums.Days.Saturday | Model.Enums.Days.Thursday,
                    HourlyRate = 40,
                    StartDate = new DateTime(2017, 1, 2),
                    InstructorId = 102,
                    RoomId = 2,
                    State = Model.Enums.CourseOfferingState.Waiting,
                    StartTime = new TimeSpan(14, 00, 00),
                    EndTime = new TimeSpan(19, 00, 00)
                };
                context.CourseOfferings.Add(courseOffering1);
                context.CourseOfferings.Add(courseOffering2);
                context.SaveChanges();
            }
            catch (DbEntityValidationException)
            {

                throw;
            }
            base.Seed(context);
        }
    }
}
