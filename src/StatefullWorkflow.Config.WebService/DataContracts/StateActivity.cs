using StatefullWorkflow.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace StatefullWorkflow.Config.WebService.DataContracts
{
    [DataContract]
    public class StateActivityDC
    {
        private StateActivity _activity;

        [DataMember]
        public int Id
        {
            get { return _activity.Id; }
            set { _activity.Id = value; }
        }

        [DataMember]
        public int WorkflowId
        {
            get { return _activity.WorkflowId; }
            set { _activity.WorkflowId = value; }
        }

        [DataMember]
        public int StateId
        {
            get { return _activity.StateId; }
            set { _activity.StateId = value; }
        }

        [DataMember]
        public string DisplayName
        {
            get { return _activity.DisplayName; }
            set { _activity.DisplayName = value; }
        }

        [DataMember]
        public IList<string> AuthorisedRoles
        {
            get { return _activity.AuthorisedRoles; }
            set { _activity.AuthorisedRoles = value; }
        }

        [DataMember]
        public IList<string> AuthorisedUsers
        {
            get { return _activity.AuthorisedUsers; }
            set { _activity.AuthorisedUsers = value; }
        }

        public StateActivityDC()
        {
        }

        public StateActivityDC(StateActivity activity)
        {
            _activity = activity;
        }
    }
}