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
        public string Id
        {
            get { return _activity.Id; }
            set
            {
                if (_activity == null) _activity = new StateActivity();
                _activity.Id = value;
            }
        }

        [DataMember]
        public string WorkflowId
        {
            get { return _activity.WorkflowId; }
            set
            {
                if (_activity == null) _activity = new StateActivity();
                _activity.WorkflowId = value;
            }
        }

        [DataMember]
        public string StateId
        {
            get { return _activity.StateId; }
            set
            {
                if (_activity == null) _activity = new StateActivity();
                _activity.StateId = value;
            }
        }

        [DataMember]
        public string DisplayName
        {
            get { return _activity.DisplayName; }
            set
            {
                if (_activity == null) _activity = new StateActivity();
                _activity.DisplayName = value;
            }
        }

        [DataMember]
        public IList<string> AuthorisedRoles
        {
            get { return _activity.AuthorisedRoles; }
            set
            {
                if (_activity == null) _activity = new StateActivity();
                _activity.AuthorisedRoles = value;
            }
        }

        [DataMember]
        public IList<string> AuthorisedUsers
        {
            get { return _activity.AuthorisedUsers; }
            set
            {
                if (_activity == null) _activity = new StateActivity();
                _activity.AuthorisedUsers = value;
            }
        }

        public StateActivityDC()
        {
            if (_activity == null)
            {
                _activity = new StateActivity();
            }
        }

        internal StateActivityDC(StateActivity activity)
        {
            _activity = activity;
        }

        internal StateActivity GetStateActivity()
        {
            return _activity;
        }
    }
}