using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
namespace FirstWebStore.Models
{
    public class FilterViewModel
    {
        public string SelectedName { get; set; }
        public FilterViewModel(string name) 
        {
            SelectedName = name;
        }
    }
}
