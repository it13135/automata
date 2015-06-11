using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace automata
{
    public class State
    {
        public List<int>  stateNos{ get; set; }
        private List<Transition> transitions = new List<Transition>();
        public List<Transition> Transitions
        {
            get
            {
                return transitions;
            }
        }
        public Point Center;

        public List<char> getSymbols()
        {
            return (from t in transitions select t.Symbol).ToList();
        }

        public bool isStartState { get; set; }
        public bool isEndState { get; set; }
        private Automaton automaton;
        public void SetAutomaton(Automaton _automaton)
        {
            automaton = _automaton;
        }

        public String stateString()
        {
            return String.Join(",", stateNos);
        }
        public List<State> getClosure()
        {
            throw new System.NotImplementedException();
        }

        public State()
        {
            stateNos = new List<int>();
        }

        public State(List<int> _stateNos)
        {
            stateNos = _stateNos;
        }
        public void addStateNo(int stateNo)
        {
            if (!stateNos.Contains(stateNo))
                stateNos.Add(stateNo);
        }
        public void addTransition(Transition _transition)
        {
            transitions.Add(_transition);
        }
        public void SetInitial()
        {
            isStartState = true;
        }
        public void SetFinal()
        {
            isEndState = true;
        }
        /// <summary>
        /// Εύρεση μίας επόμενης κατάστασης βάσει του χαρακτήρα εισαγωγής
        /// </summary>
        /// <param name="_char">Ο χαρακτήρας που προκαλεί τη μετάβαση</param>
        /// <returns>Την επόμενη κατάσταση</returns>
        public State NextState(char _char)
        {
            State nextState = (from tr in transitions where (tr.Symbol == _char) select tr.NextState).FirstOrDefault();
            return nextState;
        }

        /// <summary>
        /// Εύρεση των επόμενων καταστάσεων βάσει του χαρακτήρα εισαγωγής
        /// </summary>
        /// <param name="_char">Ο χαρακτήρας που προκαλεί τη μετάβαση</param>
        /// <returns>Μια λίστα με τις επόμενες καταστάσεις</returns>
        public List<State> NextStates(char _char)
        {
            List<State> nextStates = (from tr in transitions where (tr.Symbol == _char) select tr.NextState).ToList();
            return nextStates;
        }

        public List<State> getNextStates(char _char)
        {
            List<State> nextStates = new List<State>();
            List<State> eClosure = geteClosure();
            foreach (State state in eClosure)
            {
                nextStates = nextStates.Union(state.NextStates(_char)).ToList();
            }

            List<State> nextStateList = NextStates(_char);
            foreach (State state in nextStateList)
            {
                nextStates = nextStates.Union(state.geteClosure()).ToList();
            }
            nextStates = nextStates.Distinct().ToList();
            return nextStates;
        }

        public List<State> eClosureDirect()
        {
            List<State> eClosures = (from tr in transitions where (tr.Symbol == 'ε' && tr.NextState != this) select tr.NextState).ToList();
            eClosures.Add(this);
            return eClosures;
        }

        /// <summary>
        /// Βρίσκει το eclosure της συγκεκριμένης κατάστασης
        /// </summary>
        /// <returns>Λίστα καταστάσεων</returns>
        public List<State> geteClosure()
        {
            return eClosure(this.automaton.States);
        }

        public List<State> eClosure(List<State> notVisitedYet)
        {
            List<State> eClosures = this.eClosureDirect().Where(x=>notVisitedYet.Contains(x)).ToList();
            notVisitedYet = notVisitedYet.Except(eClosures).ToList();
            if (notVisitedYet.Count() == 0)
                return eClosures;
            else
            {
                foreach (State directState in eClosures.Where(x => x != this))
                {
                    List<State> childEClosure = directState.eClosure(notVisitedYet);
                    eClosures = eClosures.Union(childEClosure).ToList();
                }
                return eClosures;
            }
        }

        public static State getState(List<State> states)
        {
            State res = new State();
            foreach (State state in states)
            {
                res.stateNos.Add(state.stateNos[0]);
            }
            return res;
        }

        public override string ToString()
        {
            String res = "";
            foreach (int stateNo in stateNos)
            {
                if (res != "")
                    res = res + ",";
                res = stateNo.ToString();
            }
            return res;
        }
    }
}
