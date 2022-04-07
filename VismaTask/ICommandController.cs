using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaTask
{
    public interface ICommandController
    {
        public void DisplayCommands();
        public void CreateMeeting();
        public void DeleteMeeting();
        public void AddPerson();
        public void FilterMeeting();
        public void ReadMeeting();
        public void ChangeUser();
        public void OutputMeeting();
    }
}
