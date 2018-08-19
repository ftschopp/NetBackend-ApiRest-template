using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Api.Models
{
    public class CustomerModel
    {
        public CustomerModel(Guid id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}