using StatefullWorkflow.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace StatefullWorkflow.Config.WebService.DataContracts
{
    public static class DataContractExtensions
    {
        public static IList<StateActivityDC> ToDataContractList(this IList<StateActivity> source)
        {
            var list = new List<StateActivityDC>();
            foreach (var item in source)
            {
                list.Add(new StateActivityDC(item));
            }
            return list;
        }

        public static IList<StateDC> ToDataContractList(this IList<State> source)
        {
            var list = new List<StateDC>();
            foreach (var item in source)
            {
                list.Add(new StateDC(item));
            }
            return list;
        }

        public static IList<StateTransitionDC> ToDataContractList(this IList<StateTransition> source)
        {
            var list = new List<StateTransitionDC>();
            foreach (var item in source)
            {
                list.Add(new StateTransitionDC(item));
            }
            return list;
        }

        public static IList<StateActivity> ToRepoList(this IList<StateActivityDC> source)
        {
            var list = new List<StateActivity>();
            foreach (var item in source)
            {
                list.Add(item.GetStateActivity());
            }
            return list;
        }

        public static IList<State> ToRepoList(this IList<StateDC> source)
        {
            var list = new List<State>();
            foreach (var item in source)
            {
                list.Add(item.GetState());
            }
            return list;
        }

        public static IList<StateTransition> ToRepoList(this IList<StateTransitionDC> source)
        {
            var list = new List<StateTransition>();
            foreach (var item in source)
            {
                list.Add(item.GetStateTransition());
            }
            return list;
        }
    }
}