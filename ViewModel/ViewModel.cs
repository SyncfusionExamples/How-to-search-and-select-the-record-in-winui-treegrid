using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SfTreeGridDemo
{

    public class PersonViewModel : IDisposable
    {
        private static Random random = new Random(123123);
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public PersonViewModel()
        {            
            personDetails = this.CreateGenericPersonData(3, 4);
            cityCollection = new ObservableCollection<string>();
            foreach (var item in city)
            {
                CityCollection.Add(item);
            }         
        }

        private ObservableCollection<Person> personDetails;

        /// <summary>
        /// Gets or sets the person details.
        /// </summary>
        /// <value>The person details.</value>
        public ObservableCollection<Person> PersonDetails
        {
            get { return personDetails; }
        }

        private ObservableCollection<string> cityCollection;

        public ObservableCollection<string> CityCollection
        {
            get { return cityCollection; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="maxGenerations">The max generations.</param>
        public PersonViewModel(int count, int maxGenerations)
        {
            CreateGenericPersonData(count, maxGenerations);
        }

        /// <summary>
        /// Creates the child list.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="maxGenerations">The max generations.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns></returns>
        public ObservableCollection<Person> CreateChildList(int count, int maxGenerations)
        {
            ObservableCollection<Person> _children = new ObservableCollection<Person>();
            if (count > 0 && maxGenerations > 0)
            {
                _children = CreateGenericPersonData(count, maxGenerations - 1);
            }
            return _children;
        }

        /// <summary>
        /// Creates the generic person data.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="maxGenerations">The max generations.</param>
        /// <returns></returns>
        public ObservableCollection<Person> CreateGenericPersonData(int count, int maxGenerations)
        {
            var personList = new ObservableCollection<Person>();
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    var contactNo = contactNos[random.Next(0, contactNos.Count() - 1)];
                    var lastname = names2[random.Next(names2.GetLength(0))];
                    var emailId = names[random.Next(names.Length - 1)] + "@" + mail[random.Next(0, mail.Count() - 1)];
                    personList.Add(new Person(names1[random.Next(names1.GetLength(0))], lastname, new DateTime(random.Next(2008, 2012), random.Next(1, 12), random.Next(1, 28)), 30000d + random.Next(9) * 10000, city[random.Next(city.GetLength(0))], contactNo, emailId, this.CreateChildList(count, (int)Math.Max(0, maxGenerations - 1))));
                }
            }
            return personList;
        }

        #region Array Collection

        string[] city = new string[]
        {
            "NewYork",
            "San Francisco",
            "Delhi",
            "Brisbane",
            "Tokyo",
            "Rome",
            "Durban",
            "Canberra",
            "Sydney",
            "London",
            "Manchester",
            "Birmingham",
            "Liverpool",
            "Cardiff",
            "Adelaide",
            "Perth",
            "Zurich",
            "Madrid",
            "Barcelona"
        };

        private static string[] names1 = new string[]{
            "George","John","Thomas","James","Andrew","Martin","William","Zachary",
            "Millard","Franklin","Abraham","Ulysses","Rutherford","Chester","Grover","Benjamin",
            "Theodore","Woodrow","Warren","Calvin","Herbert","Franklin","Harry","Dwight","Lyndon",
            "Richard","Gerald","Jimmy","Ronald","George","Bill", "Barack", "Warner","Peter", "Larry"
        };

        private static string[] names2 = new string[]{
             "Washington","Adams","Jefferson","Madison","Monroe","Jackson","Van Buren","Harrison","Tyler",
             "Polk","Taylor","Fillmore","Pierce","Johnson","Lincoln","Johnson","Grant","Buchanan","Garfield",
             "Arthur","Cleveland","Harrison","McKinley","Roosevelt","Taft","Wilson","Harding","Coolidge",
             "Hoover","Truman","Eisenhower","Kennedy","Buchanan","Nixon","Ford","Carter","Reagan","Bush",
             "Clinton","Bush","Obama","Smith","Jones","Buchanan"
        };

        string[] mail = new string[]
        {
            "arpy.com", "sample.com", "rpy.com", "jourrapide.com"
        };

        string[] names = new string[]
        {
            "Hatomlor", "Anech",    "Polormundara", "Omemiaore-Yon",    "Moreng",   "Sernn",    "Dariech Jhon",
            "Vesrisum", "Tai'aty",  "Omat", "Drashther",    "Umm-que",  "Kinyer",   "Orothe",
            "Belawpol", "Sedlor*",  "Orgar",    "Serem",    "Oslory",   "Isia"
        };

        string[] contactNos = new string[] {
        "(833) 215-6503",
        "(855) 727-4387",
        "(844) 479-2783",
        "(855) 055-5922",
        "(899) 378-8810",
        "(833) 389-76618",
        "(855) 313-1072",
        "(899) 287-1193",
        "(844) 613-4240",
        "(833) 293-9651",
        "(899) 751-7249",
        "(833) 266-3598",
        "(855) 117-36707",
        "(811) 638-39931",
        "(833) 444-7832",
        "(899) 995-59379",
        "(899) 544-1240",
        "(811) 892-78532",
        "(844) 080-8130",
        "(899) 256-2942"
        };

        #endregion

           
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isdisposable)
        {
            
            if (PersonDetails != null)
            {
                PersonDetails.Clear();
            }
        }
    }
}
