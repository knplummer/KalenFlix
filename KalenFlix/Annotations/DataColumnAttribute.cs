using System;
using System.Collections.Generic;
using System.Linq;

namespace KalenFlix.Annotations
{
    [AttributeUsage(AttributeTargets.Property)]
    class DataColumnAttribute : Attribute
    {
        protected List<string> _valueNames { get; set; }

        public List<string> ValueNames
        {
            get
            {
                return _valueNames;
            }
            set
            {
                _valueNames = value;
            }
        }

        public DataColumnAttribute()
        {
            _valueNames = new List<string>();
        }

        public DataColumnAttribute(params string[] valueNames)
        {
            _valueNames = valueNames.ToList();
        }
    }
}