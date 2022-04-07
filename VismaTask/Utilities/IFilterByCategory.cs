using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaTask.Models;

namespace VismaTask.Utilities
{
    public interface IFilterByCategory
    {
        public List<Meeting> GetMeetingByCategory(List<Meeting> meetingList, Category cat);
    }
}
