using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaTask.Models;

namespace VismaTask.Utilities
{
    public class FilterMeetingData : IFilterDescription, IFilterResponsiblePerson, IFilterByCategory
    {
        public List<Meeting> FilterDescription(List<Meeting> meetingList, string filterString)
        {
            List<Meeting> filteredMeetings = new List<Meeting>();

          
            var meetingQuery =
                from meeting in meetingList
                where meeting.Description.Contains(filterString)
                select meeting;

            foreach (Meeting meeting in meetingQuery)
            {
                filteredMeetings.Add(meeting);
            }
            return filteredMeetings;
        }

        public List<Meeting> GetMeetingByCategory(List<Meeting> meetingList, Category cat)
        {
            List<Meeting> filteredMeetings = new List<Meeting>();

            var meetingQuery =
                from meeting in meetingList
                where meeting.Category == cat
                select meeting;

            foreach (Meeting meeting in meetingQuery)
            {
                filteredMeetings.Add(meeting);
            }
            return filteredMeetings;
        }

        public List<Meeting> GetMeetingByResponsiblePerson(List<Meeting> meetingList, Person user)
        {
            List<Meeting> filteredMeetings = new List<Meeting>();

            var meetingQuery =
                from meeting in meetingList
                where meeting.ResponsiblePerson.Name == user.Name
                select meeting;

            foreach (Meeting meeting in meetingQuery)
            {
                filteredMeetings.Add(meeting);
            }
            return filteredMeetings;
        }
    }
}
