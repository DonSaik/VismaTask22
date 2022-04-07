using Microsoft.VisualStudio.TestTools.UnitTesting;
using VismaTask.Utilities;
using VismaTask.Models;
using System;
using System.Collections.Generic;

namespace VismaTaskTest
{
    [TestClass]
    public class FilterMeetingDataTest
    {
        [TestMethod]
        public void FilterDescriptionTest()
        {

            IFilterDescription filter = new FilterMeetingData();
            List<Meeting> meetingList = getMeetingList();
            string filterDescription = ".NET";

            List<Meeting> expected = new List<Meeting>();
            expected.Add(meetingList[0]);
            expected.Add(meetingList[1]);

            List<Meeting> actual = filter.FilterDescription(meetingList, filterDescription);

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FilterByResponsiblePersonTest()
        {
            IFilterResponsiblePerson filter = new FilterMeetingData();
            List<Meeting> meetingList = getMeetingList();
            Person filterPerson= new Person();
            filterPerson.Name = "Jonas";

            List<Meeting> expected = new List<Meeting>();
            expected.Add(meetingList[0]);

            List<Meeting> actual = filter.GetMeetingByResponsiblePerson(meetingList, filterPerson);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilterByCategoryTest()
        {
            IFilterByCategory filter = new FilterMeetingData();
            List<Meeting> meetingList = getMeetingList();
            Category category = Category.CodeMonkey;

            List<Meeting> expected = new List<Meeting>();
            expected.Add(meetingList[0]);
            expected.Add(meetingList[2]);


            List<Meeting> actual = filter.GetMeetingByCategory(meetingList, category);

            CollectionAssert.AreEqual(expected, actual);
        }
        private List<Meeting> getMeetingList()
        {
            List<Meeting> meetingList = new List<Meeting>();

            Meeting meeting = new Meeting();
            meeting.Name = "Name";
            meeting.Description = "Jono .NET meetas";
            meeting.ResponsiblePerson = new Person();
            meeting.ResponsiblePerson.Name = "Jonas";
            meeting.Category = Category.CodeMonkey;
            meetingList.Add(meeting);

            meeting = new Meeting();
            meeting.Name = "Jonaiis";
            meeting.Description = "Donato .NET meetas";
            meeting.ResponsiblePerson = new Person();
            meeting.ResponsiblePerson.Name = "Donatas";
            meeting.Category = Category.Hub;
            meetingList.Add(meeting);

            meeting = new Meeting();
            meeting.Name = "Jonaiis";
            meeting.Description = "Petro Java meetas";
            meeting.ResponsiblePerson = new Person();
            meeting.ResponsiblePerson.Name = "Petras";
            meeting.Category = Category.CodeMonkey;
            meetingList.Add(meeting);

            return meetingList;
        }
    }
}