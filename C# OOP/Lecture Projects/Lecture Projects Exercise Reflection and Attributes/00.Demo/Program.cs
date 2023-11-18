using System.Reflection;

namespace _00.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Person);

            PropertyInfo propertyInfo = type.GetProperty("age");

            //MethodInfo methodInfo = type.GetMethod("GetName");

            FieldInfo fieldInfo = type.GetField("name", BindingFlags.Instance | BindingFlags.NonPublic);

            MemberInfo[] memberInfos = type.GetMember("GetName");

            Person instance = Activator.CreateInstance(type, new object[] { "Ivan", 34 }) as Person;
            Person instance2 = (Person)Activator.CreateInstance(type, "Tosho", 34);

            Person instance3 = Activator.CreateInstance(type, "Pesho", 34) as Person;

            fieldInfo.SetValue(instance, "Georgi");

            //Console.WriteLine(methodInfo.Invoke(instance, new object[] {"ASD"}));
            ;
        }
    }

    public class Person
    {
        private string name;

        public Person(string name, int age)
        {
            this.name = name;
            Age = age;
        }

        public int Age { get; set; }

        public string GetName() => name;

        public string GetName(string fullName) => fullName;
    }
}