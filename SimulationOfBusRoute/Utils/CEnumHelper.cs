using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;


namespace SimulationOfBusRoute.Utils
{
    public static class CEnumHelper
    {
        //public static IDictionary<string, int> ToDescriptionsDictionary(this Enum enumeration)
        //{
        //    Dictionary<string, int> descriptionsDictionary = new Dictionary<string, int>();

        //    FieldInfo currFieldInfo;
        //    DescriptionAttribute currAttribute;

        //    Type enumType = enumeration.GetType();

        //    foreach (Enum value in Enum.GetValues(enumType))
        //    {
        //        currFieldInfo = enumType.GetField(value.ToString());
        //        currAttribute = Attribute.GetCustomAttribute(currFieldInfo, typeof(DescriptionAttribute)) as DescriptionAttribute;

        //        if (currAttribute == null)
        //        {
        //            continue;
        //        }

        //        descriptionsDictionary.Add(currAttribute.Description, Convert.ToInt32(value));
        //    }

        //    return descriptionsDictionary;
        //}

        //public static IDictionary<string, int> ToDescriptionsDictionary(this Type enumType)
        //{
        //    Dictionary<string, int> descriptionsDictionary = new Dictionary<string, int>();

        //    FieldInfo currFieldInfo;
        //    DescriptionAttribute currAttribute;

        //    foreach (Enum value in Enum.GetValues(enumType))
        //    {
        //        currFieldInfo = enumType.GetField(value.ToString());
        //        currAttribute = Attribute.GetCustomAttribute(currFieldInfo, typeof(DescriptionAttribute)) as DescriptionAttribute;

        //        if (currAttribute == null)
        //        {
        //            continue;
        //        }

        //        descriptionsDictionary.Add(currAttribute.Description, Convert.ToInt32(value));
        //    }

        //    return descriptionsDictionary;
        //}

        //public static List<string> ToDescriptionsList(this Type enumType)
        //{
        //    List<string> descriptionsList = new List<string>();

        //    FieldInfo currFieldInfo;
        //    DescriptionAttribute currAttribute;

        //    foreach (Enum value in Enum.GetValues(enumType))
        //    {
        //        currFieldInfo = enumType.GetField(value.ToString());
        //        currAttribute = Attribute.GetCustomAttribute(currFieldInfo, typeof(DescriptionAttribute)) as DescriptionAttribute;

        //        if (currAttribute == null)
        //        {
        //            continue;
        //        }

        //        descriptionsList.Add(currAttribute.Description);
        //    }

        //    return descriptionsList;
        //}

        public static List<KeyValuePair<string, int>> ToDescriptionsList(this Type enumType)
        {
            List<KeyValuePair<string, int>> descriptionsList = new List<KeyValuePair<string, int>>();

            FieldInfo currFieldInfo;
            DescriptionAttribute currAttribute;

            foreach (Enum value in Enum.GetValues(enumType))
            {
                currFieldInfo = enumType.GetField(value.ToString());
                currAttribute = Attribute.GetCustomAttribute(currFieldInfo, typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (currAttribute == null)
                {
                    continue;
                }

                descriptionsList.Add(new KeyValuePair<string, int>(currAttribute.Description, Convert.ToInt32(value)));
            }

            return descriptionsList;
        }
    }
}
