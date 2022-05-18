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

        public Human()
        { }
        public Human(string name)
        {
            Name = name;
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
        public double RandomProbabillity()
        {
            Random r = new Random();
            return r.NextDouble();
        }
        public IHasName Couple(Human human, Human human1)
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
                        Console.WriteLine(human.GetType().Name + " любить " + human1.GetType().Name);
                        break;
                    }
                    else
                    {
                        Console.WriteLine(human.GetType().Name + " не любить " + human1.GetType().Name);
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
                        Console.WriteLine(human1.GetType().Name + " любить " + human.GetType().Name);
                        break;
                    }
                    else
                    {
                        Console.WriteLine(human1.GetType().Name + " не любить " + human.GetType().Name);
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


                Type type = Type.GetType(GetType().Namespace + "." + humanCase.ChildType);
                if (type != null)
                {
                    child = Activator.CreateInstance(type);
                    PropertyInfo nameProperty = child.GetType().GetProperty("Name");
                }
                return (IHasName)child;
            }
            else
            {
                return null;
            }


        }
        public static void CheckCouple(Human human, Human human1)
        {
            if (Woman(human) && Woman(human1) || Man(human) && Man(human1))
                throw new MatchGender("Стать обох людей співпадає");
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
