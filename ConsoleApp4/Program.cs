using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        internal class Caffe : IEnumerator<Employee>
        {
            protected List<Employee> team;
            public string Name { get; set; }
            protected int _position = -1;

            public Employee Current { get { return team[_position]; } }

            object IEnumerator.Current { get; }

            public Caffe(string name, List<Employee> team)
            {
                Name = name;
                this.team = team;
            }
            public Caffe(string name, uint size = 0)  //uint - чтобы не писать try catch для отрицательного размера
            {
                Name = name;
                team = new List<Employee>((int)size);
            }

            public void PushEmployee(Employee NewEmployee)
            {
                team.Add(NewEmployee);
            }

            public void PopEmployee()
            {
                if (team.Count >= 1) team.RemoveAt(team.Count - 1);
            }

            public IEnumerator<Employee> GetEnumerator()
            {
                return team.GetEnumerator();
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (_position < team.Count)
                {
                    _position++;
                    return true;
                }
                return false;

            }
            public void Reset()
            {
                _position = -1;
            }
        }

        internal class Employee
        {
            public string Name { get; set; }
            public string Post { get; set; }
            public double Salary { get; set; }
    


            public Employee(string name, string post, double salary)
            {
                Name = name;
                Post = post;
                if (salary >= 0) Salary = salary;    
            }

            public override string ToString()
            {
                return $"Name: {Name}, Post: {Post}, Salary: {Salary}";
            }
         }


        static void Main(string[] args)
        {
            Caffe Oblaka = new Caffe("Skies");


            Oblaka.PushEmployee(new Employee("Oleg", "manager", 1000));
            Oblaka.PushEmployee(new Employee("Bob", "barmen", 800));
            Oblaka.PushEmployee(new Employee("Helga", "cleaner", 500));

            foreach (var employer in Oblaka)
                Console.WriteLine(employer);
            Console.WriteLine();
        }
    }
}
