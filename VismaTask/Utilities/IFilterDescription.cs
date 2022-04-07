using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaTask.Models;

namespace VismaTask.Utilities
{
    public interface IFilterDescription
    {
        public List<Meeting> FilterDescription(List<Meeting> meetingList, string filterString);
    }
}
