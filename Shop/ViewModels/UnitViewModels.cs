using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.DBModels;

namespace Shop.UnitViewModels
{
    public class UnitEditViewModel
    {
        public string Name { get; set; }
    }
    public class UnitNameViewModel : UnitEditViewModel
    {
        public int IdUnit { get; set; }
    }

    public class UnitIndexViewModel
    {
        public List<UnitNameViewModel> getUnit { get; set; }
    }


    public class UnitParam
    {
        public int IdUnit { get; set; }
    }
    public class UnitAddOREditParam : UnitParam
    {
        public string Name { get; set; }
    }



}
