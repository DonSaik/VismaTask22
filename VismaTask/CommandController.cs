using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaTask.Data;
using VismaTask.Models;
using VismaTask.Utilities;

namespace VismaTask
{
    public class CommandController : ICommandController
    {
        private Person user = null;
        private List<Meeting> meetingList = new List<Meeting>();
        private IDataAccess access = new DataAcessJson();
        public void DisplayCommands()
        {
            foreach(Command command in Enum.GetValues(typeof(Command)))
            {
                if(command != Command.readMeeting)
                    Console.WriteLine($"{(int)command} - {command}");
            }
        }
        public void AddPerson()
        {
            IVerifyAttendee verifyAttendee = new VerifyAttendee();
            Console.WriteLine("Select meeting number");
            int meetingId = Convert.ToInt32(Console.ReadLine());
            if(meetingList.Count <= meetingId)
            {
                Console.WriteLine("There is no such meeting");
                return;
            }
            Attendee attendee = new Attendee();
            Console.WriteLine("Attendee name");
            attendee.Name = Console.ReadLine();
            attendee.dateTime = DateTime.Now;

            if(verifyAttendee.ExistsInMeeting(meetingList[meetingId], attendee))
            {
                Console.WriteLine("Exists in meeting");
                return;
            }
            if(verifyAttendee.IsIntersecting(meetingList, meetingList[meetingId], attendee))
            {
                Console.WriteLine("Attendee is intersecting");
            }
            else
            {
                meetingList[meetingId].Attendees.Add(attendee);
                if (access.CreateMeeting(meetingList))
                {
                    Console.WriteLine("Attendee added");
                }
                else
                {
                    Console.WriteLine("Failed to add attendee");
                }

            }

        }

        public void CreateMeeting()
        {
            if(user != null)
            {
                var meeting = MeetingIntput();
                if (meeting == null)
                {
                    Console.WriteLine("I am sorry. Inccorect data.");
                    return;
                }
                meeting.ResponsiblePerson = user;
                if(meetingList == null)
                {
                    meetingList= new List<Meeting>();
                }
                meetingList.Add(meeting);
                if (access.CreateMeeting(meetingList))
                {
                    Console.WriteLine("Meeting created");
                }
                else
                {
                    Console.WriteLine("Failed to create meeting");
                }

            }
            else
            {
                Console.WriteLine($"Please state who is using app before creating meeting in {Command.changeCurrentUser} ");
            }

        }

        public void DeleteMeeting()
        {
            if (user != null)
            {
                Console.WriteLine("State which meeting to delete by its id");
                int itemDelete = Convert.ToInt32(Console.ReadLine());
                if(itemDelete <= meetingList.Count)
                    if (meetingList[itemDelete].ResponsiblePerson.Name.Equals(user.Name))
                    {
                        meetingList.RemoveAt(itemDelete);
                        if (access.CreateMeeting(meetingList))
                        {
                            Console.WriteLine("Meeting Delteted");
                        }
                        else
                        {
                            Console.WriteLine("Failed to delete meeting");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You are not responsible for this meeting");
                    }
            }
            else
            {
                Console.WriteLine($"Please state who is using app before deleting meeting. You can state user at {Command.changeCurrentUser} command");
            }
        }

        public void DeletePerson()
        {
            throw new NotImplementedException();
        }
        public void OutputMeeting()
        {
            meetingList = access.GetMeetingList();
            if (meetingList == null)
            {
                Console.WriteLine("Something went wrong");
            }
            else if (meetingList.Count == 0)
            {
                Console.WriteLine("There is no meetings");
            }
            else
            {
                OutputMeetingList(meetingList);  
            }

        }

        private void OutputMeetingList(List<Meeting> meetings)
        {
            for (int i = 0; i < meetings.Count; i++)
            {

                Console.WriteLine($"ID {i} { MeetingToString(meetings[i])}");
            }
        }

        private void OutputFilteredMeetingList(List<Meeting> meetings)
        {
            int i;
            foreach (Meeting meeting in meetings)
            {
                i = 0;
                while (!meetingList[i].Equals(meeting))
                {
                    i++;
                }
                Console.WriteLine($"ID {i} { MeetingToString(meeting)}");
            }
        }

        public void ReadMeeting()
        {
            meetingList = access.GetMeetingList();
        }
        public void ChangeUser()
        {
            Console.WriteLine("Please state your name");
            user = new Person();
            user.Name = Console.ReadLine();
            Console.WriteLine("User changed");
        }

        private Meeting MeetingIntput()
        {
            var meeting = new Meeting();
            Console.WriteLine("Name:");
            meeting.Name = Console.ReadLine();
            Console.WriteLine("Description:");
            meeting.Description = Console.ReadLine();
            meeting.Attendees = new List<Attendee>();

            Console.WriteLine("Select category: ");
            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                Console.WriteLine($"{(int)category} - {category}");
            }
            try 
            {
                meeting.Category = MeetingCategoryInput();
            }
            catch (Exception ex)
            {
                return null;
            }
            

            Console.WriteLine("Select meeting type: ");
            foreach (MeetingType type in Enum.GetValues(typeof(MeetingType)))
            {
                Console.WriteLine($"{(int)type} - {type}");
            }
            try
            {
                meeting.Type = MeetingTypeInput();
            }
            catch (Exception ex)
            {
                return null;
            }
            

            Console.WriteLine("Start date \"yyyy-MM-dd HH:mm\"");
            try
            {
                meeting.StartDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                return null;
            }
            Console.WriteLine("End date \"yyyy-MM-dd HH:mm\"");
            try
            {
                meeting.EndDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                return null;
            }
            if (meeting.EndDate.CompareTo(meeting.StartDate) < 0)
            {
                return null;
            }
            return meeting;
        }

        private Category MeetingCategoryInput()
        {
            string getCategory = Console.ReadLine();
            Category category;
            category = (Category)Enum.Parse(typeof(Category), getCategory);
            return category;
        }
        private MeetingType MeetingTypeInput()
        {
            string getMeeting= Console.ReadLine();
            MeetingType type;
            type = (MeetingType)Enum.Parse(typeof(MeetingType), getMeeting);
            return type;
        }
        private string MeetingToString(Meeting meeting)
        {
            string str = $" Name: {meeting.Name} " +
                $"Desciption {meeting.Description} " +
                $"Responsible person {meeting.ResponsiblePerson.Name} " +
                $"Category {meeting.Category} " +
                $"Type {meeting.Type} " +
                $"Start date {meeting.StartDate} " +
                $"End date {meeting.EndDate} " +
                $"Attendees: {meeting.Attendees.Count}";
            foreach (Attendee item in meeting.Attendees)
            {
                str += $"{item.Name}"; 
            }
            return str;
        }

        public void FilterMeeting()
        {
            Console.WriteLine("Filters: ");
            foreach (MeetFilter filter in Enum.GetValues(typeof(MeetFilter)))
            {
                Console.WriteLine($"{(int)filter} - {filter}");
            }
            MeetFilter selectedFilter = MeetFilter.byDescription;
            try
            {
                selectedFilter = (MeetFilter)Enum.Parse(typeof(MeetFilter), Console.ReadLine());
            }
            catch (Exception ex)
            {
                selectedFilter = MeetFilter.byDescription;
            }
            
            switch (selectedFilter)
            {
                case MeetFilter.byDescription:
                    IFilterDescription filterByDescription = new FilterMeetingData();
                    Console.WriteLine("Filter by description. Please provide description.");
                    string descripctionFilter = Console.ReadLine();

                    OutputFilteredMeetingList(
                        filterByDescription.FilterDescription(meetingList, descripctionFilter));
                    break;

                case MeetFilter.byCategory:
                    IFilterByCategory filterByCategory = new FilterMeetingData();
                    foreach (Category item in Enum.GetValues(typeof(Category)))
                    {
                        Console.WriteLine($"{(int)item} - {item}");
                    }
                    Console.WriteLine("Filter by category. Please provide category ");
                    Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine());

                    OutputFilteredMeetingList(
                        filterByCategory.GetMeetingByCategory(meetingList, category));
                    break;
                case MeetFilter.byResponsiblePerson:
                    IFilterResponsiblePerson filterByResponsiblePeron = new FilterMeetingData();
                    Person user = new Person();
                    Console.WriteLine("Filter by responsible person. Please provide name ");
                    user.Name = Console.ReadLine();

                    OutputFilteredMeetingList(
                        filterByResponsiblePeron.GetMeetingByResponsiblePerson(meetingList, user));
                    break;
            }
            
            
        }
    }
}
