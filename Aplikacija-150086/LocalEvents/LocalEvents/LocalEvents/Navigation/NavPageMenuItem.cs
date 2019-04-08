using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalEvents.Navigation
{

    public class NavPageMenuItem
    {
        public NavPageMenuItem()
        {
            TargetType = typeof(Events.MainPage);
        }

        public int Id { get; set; }
        
        public string ImageSource { get; set; }

        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}