using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaTask.Models;

namespace VismaTask.Data
{
    public class DataAcessJson : IDataAccess
    {
        ICreateMeeting createMeeting = new CrudMeeting();
        IReadMeeting readMeeting = new CrudMeeting();
        public bool CreateMeeting(List<Meeting> meetingList)
        {
            try
            {
                createMeeting.CreateMeeting(meetingList);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public List<Meeting> GetMeetingList()
        {
            List<Meeting> meetingList;
            try
            {
                 meetingList= readMeeting.GetMeetingList();
            }
            catch (Exception ex)
            {
                return null;
            }
            return meetingList;
        }
    }
}
