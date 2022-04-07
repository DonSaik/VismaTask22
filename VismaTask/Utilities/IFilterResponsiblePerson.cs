using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaTask.Models;

namespace VismaTask.Utilities
{
    public interface IFilterResponsiblePerson
    {
        public List<Meeting> GetMeetingByResponsiblePerson(List<Meeting> meetingList, Person user);
    }
}
