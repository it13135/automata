using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace automata
{
    public static class AutomatonFactory
    {
        public static Automaton CreateFromFile(String fileName)
        {
            XElement root = XElement.Load(fileName);
            Automaton res = null;

            var type = (from ty in root.Descendants("type") select (string)ty).FirstOrDefault().ToString();
            var transitions = (from tr in root.Descendants("transition")
                               select new
                               {
                                   stateFrom = tr.Attribute("stateFrom").Value,
                                   symbol = tr.Attribute("symbol").Value,
                                   stateTo = tr.Attribute("stateTo").Value,
                                   stackIn = tr.Attribute("stackIn"),
                                   stackOut = tr.Attribute("stackOut")
                               });
            List<State> automatonStates = new List<State>();
            foreach (var item in transitions)
            {
                State stFrom;
                var sta = from au in automatonStates where (au.stateString() == item.stateFrom) select au;
                stFrom = sta.FirstOrDefault();
                if (stFrom == null)
                {
                    List<int> ints = item.stateFrom.Split(',').Select(int.Parse).ToList();
                    stFrom = new State(ints);
                    automatonStates.Add(stFrom);
                }

                State stTo;
                sta = from au in automatonStates where (au.stateString() == item.stateTo) select au;
                stTo = sta.FirstOrDefault();
                if (stTo == null)
                {
                    List<int> ints = item.stateTo.Split(',').Select(int.Parse).ToList();
                    stTo = new State(ints);
                    automatonStates.Add(stTo);
                }
                Transition tr = TransitionFactory.Create(type, item.stackOut, item.stackIn) ;//;new Transition();
                tr.Symbol = item.symbol[0];
                tr.NextState = stTo;
                stFrom.addTransition(tr);
            }

            var initialState = (from ty in root.Descendants("initialState") select (string)ty).FirstOrDefault().ToString();
            var initial = (from au in automatonStates where (au.stateString() == initialState) select au).FirstOrDefault();
            if (initial != null)
                initial.SetInitial();
            var finalStates = (from ty in root.Descendants("finalState") select (string)ty);
            foreach (var finalState in finalStates)
            {
                var final = (from au in automatonStates where (au.stateString() == finalState) select au).FirstOrDefault();
                if (final != null)
                    final.SetFinal();
            }
            
            switch (type)
            {
                case "NFA":
                    res = new NFA(automatonStates);
                    break;
                case "DFA":
                    res = new DFA(automatonStates);
                    break;
                case "PDA":
                    res = new PDA(automatonStates);
                    break;
            }
            return res;
        }
    }
}
