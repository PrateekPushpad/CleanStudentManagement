using CleanStudentManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Models
{
    public class GroupViewModel
    {
        public GroupViewModel()
        {
            
        }
        public GroupViewModel(Group group)
        {
            Id = group.Id;
            Name = group.Name;
            Description = group.Description;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Group ConverttoGroup(GroupViewModel groupViewModel)
        {
            return new Group 
            { 
                Id = groupViewModel.Id,
                Name = groupViewModel.Name,
                Description = groupViewModel.Description
            };
        }
    }
}
