using System;
using System.Reflection;
using System.Collections;

namespace Ceriv.Atributos
{
    [AttributeUsage(AttributeTargets.Class)]
    class EntityAttribute : Attribute
    {
        private string storeProcedure;

        public EntityAttribute(string value)
        {
            this.storeProcedure = value;
        }

        public string StoreProcedure
        {
            get { return storeProcedure; }
            set { storeProcedure = value; }
        }

    }

    [AttributeUsage(AttributeTargets.Class)]
    class TableAttribute : Attribute
    {
        private string table;

        private int version;

        public TableAttribute(string name)
        {
            this.table = name;
            this.version = 0;
        }

        public string Table
        {
            get { return table; }
            set { table = value; }
        }

        public int Version
        {
            get { return version; }
            set { version = value; }
        }

        public override string ToString()
        {
            string value = "Author : " + Version;
            if (version != 0)
            {
                value += " Version : " + Version.ToString();
            }
            return value;
        }
    }
    [AttributeUsage(AttributeTargets.Field)]
    class ColumnAttribute : Attribute
    {
        private string column;
        private bool primaryKey;
        
        private string oneToMany;
        private string manyToOne;        

        public ColumnAttribute(string name)
        {
            this.column = name;
            PrimaryKey = false;
            oneToMany = null;
            manyToOne = null;
        }

        public string Column
        {
            get { return column; }
            set { column = value; }
        }
        
        public bool PrimaryKey
        {
            get { return primaryKey; }
            set { primaryKey = value; }
        }

        public string OneToMany
        {
            get { return oneToMany; }
            set { oneToMany = value; }
        }

        public string ManyToOne
        {
            get { return manyToOne; }
            set { manyToOne = value; }
        }

        public override string ToString()
        {
            return Column;
        }
    }
}
