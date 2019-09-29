using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class RegularExpressionMatching
    {
        // You can find this problem at: https://leetcode.com/problems/regular-expression-matching/
        // Author: Antonio Serrano Miralles
        // 29-09-2019
        public static void Main(string[] args)
        {
            string input = "caccccaccbabbcb";
            string pattern = "c*c*b*a*.*c*.a*a*a*";
            Console.WriteLine(IsMatch(input,pattern));
            Console.ReadKey(true);
        }

        public static bool IsMatch(string s, string p)
        {
            State first = null;
            State actual = null;
            for (int i = 0; i < p.Length - 4; i++)
            {
                for (int j = i; j < p.Length - 4; j++)
                {
                    if (p[j] == p[j + 2] && p[j + 1] == '*' && p[j + 3] == '*')
                    {
                        p = p.Substring(0,j)+p.Substring(j+2);
                        j--;
                    }
                }
            }

            if (p.Length == 0)
            {
                if (s.Length == 0) return true;
                else return false;
            }
            if (p.Length == 1)
            {
                if (s.Length != 1) return false;
                int code = (int)s[0];
                if ((p[0] == '.' && code >= 97 && code <= 122) || p[0] == s[0]) return true;
            } else //Create automaton
            {
                first = new State(false);
                actual = first;
                for (int i=0; i<p.Length-1; i++)
                {
                    if (p[i + 1] == '*')
                    {
                        State nextAux = new State(false);
                        actual.next.Add(nextAux);
                        actual.symbolNext.Add(p[i]);
                        nextAux.prev = actual;
                        nextAux.symbolRepeat = p[i];
                        State nextAux2 = new State(false);
                        nextAux.next.Add(nextAux2);
                        nextAux2.prev = nextAux;
                        nextAux.symbolNext.Add('>');
                        actual.next.Add(nextAux2);
                        actual.symbolNext.Add('>');
                        actual = nextAux2;
                        i++;
                    } else
                    {
                        actual.symbolNext.Add(p[i]);
                        State nextAux = new State(false);
                        nextAux.prev = actual;
                        actual.next.Add(nextAux);
                        actual = nextAux;
                    }
                }
                if (p[p.Length - 1] != '*')
                {
                    actual.symbolNext.Add(p[p.Length - 1]);
                    State nextAux3 = new State(false);
                    nextAux3.prev = actual;
                    actual.next.Add(nextAux3);
                    actual = nextAux3;
                }
                actual.final = true;

                //Check input in automaton
                return CheckInput(s, first);
            }
            return false;
        }

        public static bool CheckInput(string s, State initial)
        {
            if (s.Length == 0 && initial.final) return true;
            else if (s.Length == 0 && !initial.symbolNext.Contains('>')) return false;
            if (initial.symbolNext.Count == 0 && initial.symbolRepeat == '?') return false;
            if (initial.symbolRepeat == '?')
            {
                bool direct = false;
                bool lambda = false;
                if (s.Length > 0 && (initial.symbolNext[0] == s[0] || initial.symbolNext[0] == '.')) direct = true;
                if (initial.symbolNext.Count>1 && initial.symbolNext[1] == '>') lambda = true;
                if (direct && lambda)
                {
                    bool first = CheckInput(s.Substring(1), initial.next[0]);
                    if (first) return true;
                    else return CheckInput(s, initial.next[1]);
                }
                else if (direct)
                {
                    return CheckInput(s.Substring(1), initial.next[0]);
                }
                else if (lambda)
                {
                    return CheckInput(s, initial.next[1]);
                }
                else return false;
            } else
            {
                if (s.Length>0 && (s[0] == initial.symbolRepeat || initial.symbolRepeat == '.'))
                {
                    bool first = CheckInput(s.Substring(1), initial);
                    if (first) return first;
                    else
                    {
                        first = CheckInput(s.Substring(1), initial.next[0]);
                    }
                    if (first) return first;
                    return CheckInput(s, initial.next[0]);
                } else
                {
                    return CheckInput(s, initial.next[0]);
                }
            }
        }

        public class State
        {
            static int ID = 0;
            public string personalID;
            public List<Char> symbolNext = new List<char>();
            public Char symbolRepeat = '?';
            public List<State> next = new List<State>();
            public State prev = null;
            public bool final = false;

            public State(bool final)
            {
                this.final = final;
                ID++;
                personalID = "q"+ID.ToString();
            }
            
        }
    }
}
