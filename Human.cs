using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;

namespace lab6
{
    internal class Human : IEnumerable, IHasName
    {
        public string Name 
        { 
            get; 
            set; 
        }

        public string Lastname
        {
            get;
            set;
        }

        public Human()
        { }
        public Human(string name, string lastname)
        {
            Name = name;
            Lastname = lastname;
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<CoupleAttribute> GetEnumerator()
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(GetType());
            foreach (Attribute attribute in attributes)
            {
                if (attribute is CoupleAttribute coupleAttribute)
                {
                    yield return coupleAttribute;
                }
            }
        }
        public static double RandomProbabillity()
        {
            Random r = new Random();
            return r.NextDouble();
        }
        public static IHasName Couple(Human human, Human human1)
        {
            bool human1Like = false;
            CoupleAttribute humanCase = new CoupleAttribute();
            foreach (CoupleAttribute attribute in human)
            {
                if (attribute.Pair == human1.GetType().Name)
                {
                    humanCase = attribute;
                    double rand = RandomProbabillity();
                    if (rand >= attribute.Probability)
                    {
                        human1Like = true;
                        Console.WriteLine(human1.GetType().GetProperty("Name").GetValue(human1) + " любить " + human.GetType().GetProperty("Name").GetValue(human));
                        break;
                    }
                    else
                    {
                        Console.WriteLine(human1.GetType().GetProperty("Name").GetValue(human1) + " не любить " + human.GetType().GetProperty("Name").GetValue(human));
                    }
                }
            }
            bool human2Like = false;
            CoupleAttribute human1Case = new CoupleAttribute();
            foreach (CoupleAttribute attribute in human1)
            {
                if (attribute.Pair == human.GetType().Name)
                {
                    human1Case = attribute;
                    double rand = RandomProbabillity();
                    if (rand >= attribute.Probability)
                    {
                        human2Like = true;
                        Console.WriteLine(human.GetType().GetProperty("Name").GetValue(human) + " любить " + human1.GetType().GetProperty("Name").GetValue(human1));
                        break;
                    }
                    else
                    {
                        Console.WriteLine(human.GetType().GetProperty("Name").GetValue(human) + " не любить " + human1.GetType().GetProperty("Name").GetValue(human1));
                    }
                }
            }
            object result = new object();
            object child = new object();
            if (human2Like && human1Like)
            {
                foreach (MethodInfo methodInfo in human1.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (methodInfo.ReturnType == typeof(System.String))
                    {
                        try
                        {
                            result = methodInfo.Invoke(human1, null);
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }


                Type type = Type.GetType("lab6." + humanCase.ChildType);
                if (type != null)
                {
                    child = Activator.CreateInstance(type);
                    PropertyInfo nameProperty = child.GetType().GetProperty("Name");
                    PropertyInfo lastnameProperty = child.GetType().GetProperty("Lastname");
                    if (nameProperty != null && lastnameProperty != null)
                    {
                        nameProperty.SetValue(child, result);
           
                        if (nameProperty.GetValue(child, null).ToString() == "Student" || nameProperty.GetValue(child, null).ToString() == "Botan")
                        {
                            lastnameProperty.SetValue(child, lastnameProperty.GetValue(child) + "ович");
                        }
                        else
                        {
                            lastnameProperty.SetValue(child, lastnameProperty.GetValue(child) + "івна");
                        }
                    }
                }
                return (IHasName)child;
            }
            else
            {
                return null;
            }


        }
        public static bool CheckCouple(Human human1, Human human2)
        {
            return (Woman(human1) && Woman(human2) || Man(human1) && Man(human2));
             
       
        }
        protected static bool Man(Human human)
        {
            return human is Student || human is Botan;
        }

        protected static bool Woman(Human human)
        {
            return human is Girl || human is PrettyGirl || human is SmartGirl;
        }
    }
}
