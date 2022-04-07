using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaTask.Models;

namespace VismaTask.Data
{
    public interface IReadMeeting
    {
        public List<Meeting> GetMeetingList();
    }
}
