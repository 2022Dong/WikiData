﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
/*Dongyun Huang 30042104
 5/4/2023

Programming Criteria:
    6.1 Create a separate class file to hold the four data items of the Data Structure (use the Data Structure Matrix as a guide).
    Use private properties for the fields which must be of type “string”. The class file must have separate setters and getters,
    add an appropriate IComparable for the Name attribute. Save the class as “Information.cs”. 
 */
namespace WikiData
{
    internal class Information : IComparable<Information>
    {
        #region ATTRIBUTES
        // Attributes for setting getters and setters, must be private.
        private string name;
        private string category;
        private string structure;
        private string definition;
        // Assesor methods, must be public.
        public string getName() // Read
        {
            return name;
        }
        public void setName(string newName) // Modify
        {
            name = newName.ToLower();
        }
        public string getCategory()
        {
            return category;
        }
        public void setCategory(string newCategory)
        {
            category = newCategory;
        }
        public string getStructure()
        {
            return structure;
        }
        public void setStructure(string newStructure)
        {
            structure = newStructure;
        }
        public string getDefinition()
        {
            return definition;
        }
        public void setDefinition(string newDefinition)
        {
            definition = newDefinition;
        }
        #endregion

        // Implement the generic CompareTo method with the Wiki
        // class as the Type parameter.
        public int CompareTo(Information compareName)
        {
            return name.CompareTo(compareName.name); // equal is 0.
        }

        // Default constructor
        public Information()
        { }

        // 2nd constructors --- same name but uniqure signature.
        public Information(string newName)
        {
            name = newName;  // this.xxxx is no necessary
            category = "";
            structure = "";
            definition = "";
        }
        public Information(string newName, string newCateory, string newStructure, string newDefinition)
        {
            name = newName;
            category = newCateory;
            structure = newStructure;
            definition = newDefinition;
        }
    }
}
